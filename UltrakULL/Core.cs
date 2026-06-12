using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
using HarmonyLib;
using Newtonsoft.Json;
using TMPro;
using UnityEngine.TextCore;
using UnityEngine.TextCore.LowLevel;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;
using System.Linq;
using BepInEx;
using BepInEx.Configuration;

namespace UltrakULL
{
    public static class Core
    {
        public static Font VcrFont;
        public static GameObject ultrakullLogo = null;

        public static volatile bool updateAvailable;
        public static volatile bool updateFailed;
        
        public static bool GlobalFontReady;
        public static bool TMPFontReady;
        
        public static Font GlobalFont;
        public static Font MuseumFont;
        public static TMP_FontAsset GlobalFontTMP;
        public static TMP_FontAsset MuseumFontTMP;
        public static TMP_FontAsset CJKFontTMP;
        public static TMP_FontAsset JaFontTMP;
        public static TMP_FontAsset ArabicFontTMP;
        public static TMP_FontAsset HebrewFontTMP;
        public static Material GlobalFontTMPOverlayMat;
        public static Material CJKFontTMPOverlayMat;
        public static Material jaFontTMPOverlayMat;
        public static Sprite[] CustomRankImages;

        // Custom fonts loaded from external files
        public static TMP_FontAsset CustomMainFontTMP;
        public static TMP_FontAsset CustomMuseumFontTMP;
        public static TMP_FontAsset CustomTerminalFontTMP;
        public static TMP_FontAsset CustomSecretTerminalFontTMP;
        
        // Materials for custom TMP fonts (overlay)
        public static Material CustomMainFontTMPOverlayMat;
        public static Material CustomMuseumFontTMPOverlayMat;
        public static Material CustomTerminalFontTMPOverlayMat;
        public static Material CustomSecretTerminalFontTMPOverlayMat;

        public static bool UseFontFallback;
        private static bool fallbackHookRegistered;

        private static bool ultrakullDropdownExpanded = false;

        public static Sprite ArabicUltrakillLogo;

		public static bool wasLanguageReset = false;
        
        private static readonly HttpClient Client = new HttpClient();
        
        //Encapsulation function to patch all of the front end.
        public static void PatchFrontEnd(GameObject frontEnd)
        {
            MainMenu.Patch(frontEnd);
            Options options = new Options(ref frontEnd);
        }

        public static async Task CheckForUpdates()
        {
            string rssUrl = "https://github.com/ClearwaterUK/UltrakULL/releases.atom";
            // Increase timeout to 10 seconds for better reliability
            Client.Timeout = TimeSpan.FromSeconds(10);
            // Add User-Agent header to avoid being blocked by GitHub
            if (!Client.DefaultRequestHeaders.Contains("User-Agent"))
            {
                Client.DefaultRequestHeaders.Add("User-Agent", "UltrakULL-Update-Checker/1.0");
            }

            try
            {
                string rssContent = await Client.GetStringAsync(rssUrl);
                var doc = new System.Xml.XmlDocument();
                doc.LoadXml(rssContent);

                // Create namespace manager for Atom
                var nsManager = new System.Xml.XmlNamespaceManager(doc.NameTable);
                nsManager.AddNamespace("atom", "http://www.w3.org/2005/Atom");

                // Get latest release entry using namespace
                var latest = doc.SelectSingleNode("//atom:entry[1]", nsManager);
                if (latest == null)
                    throw new Exception("No releases found in RSS feed");

                string title = latest.SelectSingleNode("atom:title", nsManager)?.InnerText ?? "";
                string updated = latest.SelectSingleNode("atom:updated", nsManager)?.InnerText ?? "";

                // Parse version from title (usually the tag)
                string versionString = title.TrimStart('v', 'V');
                // Remove any suffix after hyphen (e.g., "-beta.2") or plus (e.g., "+build")
                int hyphenIndex = versionString.IndexOf('-');
                if (hyphenIndex >= 0)
                    versionString = versionString.Substring(0, hyphenIndex);
                int plusIndex = versionString.IndexOf('+');
                if (plusIndex >= 0)
                    versionString = versionString.Substring(0, plusIndex);
                // Ensure version string is valid for Version class
                Logging.Message("Latest version from RSS (cleaned): " + versionString);
                Logging.Message("Current local version: " + MainPatch.GetVersion());

                Version onlineVersion = new Version(versionString);
                // Clean local version similarly
                string localVersionString = MainPatch.GetVersion();
                localVersionString = localVersionString.TrimStart('v', 'V');
                hyphenIndex = localVersionString.IndexOf('-');
                if (hyphenIndex >= 0)
                    localVersionString = localVersionString.Substring(0, hyphenIndex);
                plusIndex = localVersionString.IndexOf('+');
                if (plusIndex >= 0)
                    localVersionString = localVersionString.Substring(0, plusIndex);
                Version localVersion = new Version(localVersionString);

                // Simple version compare - update available if online version is newer
                updateAvailable = localVersion.CompareTo(onlineVersion) < 0;

                if (updateAvailable)
                    Logging.Warn("UPDATE AVAILABLE!");
                else
                    Logging.Message("No newer version detected. Assuming current version is up to date.");

                updateFailed = false;
            }
            catch (TaskCanceledException)
            {
                Logging.Error("Update check timed out after 10 seconds.");
                updateAvailable = false;
                updateFailed = true;
            }
            catch (HttpRequestException hre)
            {
                Logging.Error("Network error while checking for updates: " + hre.Message);
                updateAvailable = false;
                updateFailed = true;
            }
            catch (Exception e)
            {
                Logging.Error("Unable to check for updates via RSS feed.");
                Logging.Error(e.ToString());
                updateAvailable = false;
                updateFailed = true;
            }
        }


        //Patches all text strings in the pause menu.
        public static void PatchPauseMenu(ref GameObject canvasObj)
        {
            try
            {
                GameObject pauseMenu = GetGameObjectChild(canvasObj, "PauseMenu");

                //Title
                TextMeshProUGUI pauseText = GetTextMeshProUGUI(GetGameObjectChild(pauseMenu, "Text"));
                pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

                //Resume
                TextMeshProUGUI continueText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Resume"), "Text"));
                continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

                //Checkpoint
                TextMeshProUGUI checkpointText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Checkpoint"), "Text"));
                checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;
                //SKIP button 
                if (GetCurrentSceneName().Contains("Intermission"))
                {
                    TextMeshProUGUI skipText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Checkpoint (1)"), "Text"));
                    skipText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_skip;
                }
                //Restart mission
                TextMeshProUGUI restartText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Restart Mission"), "Text"));
                restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

                //Options
                TextMeshProUGUI optionsText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Options"), "Text"));
                optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

                //Quit
                TextMeshProUGUI quitText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(pauseMenu, "Quit Mission"), "Text"));
                quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;

                //Quit+Restart windows
                GameObject pauseDialogs = GetGameObjectChild(canvasObj, "PauseMenuDialogs");

                //Quit
                GameObject quitDialog = GetGameObjectChild(GetGameObjectChild(pauseDialogs, "Quit Confirm"), "Panel");
                TextMeshProUGUI quitDialogText = GetTextMeshProUGUI(GetGameObjectChild(quitDialog, "Text (2)"));
                quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

                TextMeshProUGUI quitDialogTooltip = GetTextMeshProUGUI(GetGameObjectChild(quitDialog, "Text (1)"));
                quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                TextMeshProUGUI quitDialogYes = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(quitDialog, "Confirm"), "Text"));
                quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

                TextMeshProUGUI quitDialogNo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(quitDialog, "Cancel"), "Text"));
                quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;

                //Restart
                GameObject restartDialog = GetGameObjectChild(GetGameObjectChild(pauseDialogs, "Restart Confirm"), "Panel");

                TextMeshProUGUI restartDialogText = GetTextMeshProUGUI(GetGameObjectChild(restartDialog, "Text"));
                restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

                TextMeshProUGUI restartDialogTooltip = GetTextMeshProUGUI(GetGameObjectChild(restartDialog, "Text (1)"));
                restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

                TextMeshProUGUI restartDialogYes = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(restartDialog, "Confirm"), "Text"));
                restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

                TextMeshProUGUI restartDialogNo = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(restartDialog, "Cancel"), "Text"));
                restartDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmNo;
            }
            catch (Exception e)
            {
                Logging.Error("Failed to patch pause menu.");
                Logging.Error(e.ToString());
            }
        }
        
        private static string FindFontFile(string directory, string baseName)
        {
            if (string.IsNullOrEmpty(baseName))
            {
                Logging.Message($"FindFontFile: baseName is null or empty");
                return null;
            }

            // Если имя уже содержит расширение, проверим как есть
            string fullPath = Path.Combine(directory, baseName);
            Logging.Message($"FindFontFile: checking exact path '{fullPath}'");
            if (File.Exists(fullPath))
            {
                Logging.Message($"FindFontFile: found exact file '{fullPath}'");
                return fullPath;
            }

            // Попробуем добавить распространённые расширения шрифтов
            string[] extensions = { ".ttf", ".otf", ".ttc", ".woff", ".woff2" };
            foreach (var ext in extensions)
            {
                string path = Path.Combine(directory, baseName + ext);
                Logging.Message($"FindFontFile: checking path '{path}'");
                if (File.Exists(path))
                {
                    Logging.Message($"FindFontFile: found file with extension '{ext}' at '{path}'");
                    return path;
                }
            }

            // Не найдено
            Logging.Message($"FindFontFile: no file found for '{baseName}' in directory '{directory}'");
            return null;
        }

        /// <summary>
        /// Creates a TMP_FontAsset from a font file path.
        /// </summary>
        /// <param name="fontPath">Full path to the font file (TTF, OTF, etc.)</param>
        /// <param name="samplingPointSize">Sampling point size for the font atlas (default 90)</param>
        /// <param name="padding">Padding between glyphs in the atlas (default 9)</param>
        /// <param name="renderMode">Glyph render mode (default SDFAA)</param>
        /// <param name="atlasWidth">Width of the atlas texture (default 1024)</param>
        /// <param name="atlasHeight">Height of the atlas texture (default 1024)</param>
        /// <param name="atlasPopulationMode">Atlas population mode (default Dynamic)</param>
        /// <returns>TMP_FontAsset if successful, null otherwise</returns>
        private static TMP_FontAsset CreateTMPFontFromFile(string fontPath,
            int samplingPointSize = 90,
            int padding = 9,
            GlyphRenderMode renderMode = GlyphRenderMode.SDFAA,
            int atlasWidth = 1024,
            int atlasHeight = 1024,
            AtlasPopulationMode atlasPopulationMode = AtlasPopulationMode.Dynamic)
        {
            if (string.IsNullOrEmpty(fontPath) || !File.Exists(fontPath))
            {
                Logging.Error($"CreateTMPFontFromFile: font file not found or path empty: {fontPath}");
                return null;
            }

            try
            {
                // Load Unity Font from file
                Font unityFont = new Font(fontPath);
                if (unityFont == null)
                {
                    Logging.Error($"CreateTMPFontFromFile: failed to create Unity Font from {fontPath}");
                    return null;
                }

                Logging.Message($"CreateTMPFontFromFile: creating TMP font asset from {Path.GetFileName(fontPath)}");
                TMP_FontAsset tmpFont = TMP_FontAsset.CreateFontAsset(
                    unityFont,
                    samplingPointSize,
                    padding,
                    renderMode,
                    atlasWidth,
                    atlasHeight,
                    atlasPopulationMode
                );

                // If failed, try without parameters (simpler method)
                if (tmpFont == null)
                {
                    Logging.Warn($"CreateTMPFontFromFile: first attempt failed, trying without parameters...");
                    tmpFont = TMP_FontAsset.CreateFontAsset(unityFont);
                }

                if (tmpFont == null)
                {
                    Logging.Error($"CreateTMPFontFromFile: TMP_FontAsset.CreateFontAsset returned null for {fontPath}");
                    return null;
                }

                Logging.Message($"CreateTMPFontFromFile: successfully created TMP font asset '{tmpFont.name}'");
                return tmpFont;
            }
            catch (Exception e)
            {
                Logging.Error($"CreateTMPFontFromFile: exception while processing {fontPath}: {e.Message}");
                Logging.Error(e.ToString());
                return null;
            }
        }

        public static void LoadCustomFonts()
        {
            UseFontFallback = LanguageManager.CurrentLanguage?.metadata?.fonts?.UseFallback ?? false;

            // Reset custom font fields before loading
            CustomMainFontTMP = null;
            CustomMuseumFontTMP = null;
            CustomTerminalFontTMP = null;
            CustomSecretTerminalFontTMP = null;
            CustomMainFontTMPOverlayMat = null;
            CustomMuseumFontTMPOverlayMat = null;
            CustomTerminalFontTMPOverlayMat = null;
            CustomSecretTerminalFontTMPOverlayMat = null;

            if (LanguageManager.CurrentLanguage?.metadata?.fonts == null)
            {
                Logging.Message("No custom fonts defined in language metadata.");
                return;
            }

            var fonts = LanguageManager.CurrentLanguage.metadata.fonts;
            
            // Debug log font fields
            Logging.Message($"Custom font fields - MainFont: '{fonts.MainFont}', MuseumFont: '{fonts.MuseumFont}', TerminalFont: '{fonts.TerminalFont}', SecretTerminalFont: '{fonts.SecretTerminalFont}'");
            
            // Check if any font field is non-empty
            if (string.IsNullOrEmpty(fonts.MainFont) &&
                string.IsNullOrEmpty(fonts.MuseumFont) &&
                string.IsNullOrEmpty(fonts.TerminalFont) &&
                string.IsNullOrEmpty(fonts.SecretTerminalFont))
            {
                Logging.Message("All custom font fields are empty, skipping custom font loading.");
                return;
            }

            string langName = LanguageManager.CurrentLanguage.metadata.langName;
            string fontsPath = Path.Combine(Paths.ConfigPath, "ultrakull", "fonts", langName);
            
            Logging.Message($"Custom fonts directory path: {fontsPath}");
            if (!Directory.Exists(fontsPath))
            {
                Logging.Message($"Custom fonts directory not found: {fontsPath}");
                return;
            }

            Logging.Message($"Loading custom fonts from: {fontsPath}");


            void LoadFont(string fontName, string label, Action<TMP_FontAsset> setFont, Action<Material> setOverlay)
            {
                if (string.IsNullOrEmpty(fontName))
                    return;

                Logging.Message($"Attempting to load {label}: '{fontName}'");
                string fontPath = FindFontFile(fontsPath, fontName);
                if (fontPath == null)
                {
                    Logging.Warn($"Custom {label} file not found: {fontName} (searched with extensions .ttf, .otf, .ttc, .woff, .woff2)");
                    return;
                }

                Logging.Message($"Found {label} file at: {fontPath}");
                TMP_FontAsset tmpFont = CreateTMPFontFromFile(fontPath);
                if (tmpFont == null)
                {
                    Logging.Error($"CreateTMPFontFromFile returned null for {label}");
                    return;
                }

                ApplyFallbackMetrics(tmpFont);
                setFont(tmpFont);
                // Create overlay material for this font
                if (GlobalFontTMPOverlayMat != null)
                {
                    Material overlay = new Material(GlobalFontTMPOverlayMat) { name = $"{tmpFont.name}_Overlay" };
                    setOverlay(overlay);
                    Logging.Message($"Created overlay material for {label}: {overlay.name}");
                }
                else
                {
                    Logging.Warn($"GlobalFontTMPOverlayMat is null, cannot create overlay material for {label}");
                }
                Logging.Message($"Loaded custom {label} TMP: {fontName} (from {Path.GetFileName(fontPath)})");
            }

            LoadFont(fonts.MainFont,           "MainFont",           f => CustomMainFontTMP = f,           m => CustomMainFontTMPOverlayMat = m);
            LoadFont(fonts.MuseumFont,         "MuseumFont",         f => CustomMuseumFontTMP = f,         m => CustomMuseumFontTMPOverlayMat = m);
            LoadFont(fonts.TerminalFont,       "TerminalFont",       f => CustomTerminalFontTMP = f,       m => CustomTerminalFontTMPOverlayMat = m);
            LoadFont(fonts.SecretTerminalFont, "SecretTerminalFont", f => CustomSecretTerminalFontTMP = f, m => CustomSecretTerminalFontTMPOverlayMat = m);

            if (!fallbackHookRegistered)
            {
                SceneManager.sceneLoaded += AddFontAsFallbackFont;
                fallbackHookRegistered = true;
            }

            void AddFontAsFallbackFont(Scene scene, LoadSceneMode mode)
            {
                if (!UseFontFallback)
                    return;

                var allFontAsset = UnityEngine.Resources.FindObjectsOfTypeAll<TMP_FontAsset>()
                    .Except(new[] { CustomMainFontTMP, CustomMuseumFontTMP, CustomTerminalFontTMP, CustomSecretTerminalFontTMP });

                foreach (var fontAsset in allFontAsset)
                {
                    string name = fontAsset.name?.ToLower();
                    if (string.IsNullOrEmpty(name))
                        continue;

                    if (name.Contains("tahoma"))
                        AddFallback(fontAsset, CustomTerminalFontTMP);
                    else if (name.Contains("bittypix"))
                        AddFallback(fontAsset, CustomSecretTerminalFontTMP);
                    else if (name.Contains("garaldus") || name.Contains("garamond") || name.Contains("museum"))
                        AddFallback(fontAsset, CustomMuseumFontTMP);
                    else
                        AddFallback(fontAsset, CustomMainFontTMP);
                }
            }
        }

        /// <summary>
        /// Reloads custom fonts based on the current language.
        /// Call this after changing language.
        /// </summary>
        public static void ReloadCustomFonts()
        {
            LoadCustomFonts();
        }

        private static void AddFallback(TMP_FontAsset primary, TMP_FontAsset fallback)
        {
            if (primary == null || fallback == null || primary == fallback)
                return;
            if (primary.fallbackFontAssetTable == null)
                primary.fallbackFontAssetTable = new List<TMP_FontAsset>();
            if (!primary.fallbackFontAssetTable.Contains(fallback))
                primary.fallbackFontAssetTable.Add(fallback);
        }

        private static void ApplyFallbackMetrics(TMP_FontAsset font)
        {
            if (font == null)
                return;

            var fonts = LanguageManager.CurrentLanguage?.metadata?.fonts;
            if (fonts == null || (fonts.FallbackScale == 1f && fonts.FallbackBaselineOffset == 0f))
                return;

            var fi = font.faceInfo;
            fi.scale *= fonts.FallbackScale;
            fi.baseline += fonts.FallbackBaselineOffset;
            font.faceInfo = fi;
        }

        public static void LoadFonts()
        {
            Logging.Message("Loading font resource bundle...");
            //Will load from the same directory that the dll is in.
            AssetBundle fontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder,"ullfont.resource"));

            AssetBundle extraFontBundle = AssetBundle.LoadFromFile(Path.Combine(MainPatch.ModFolder, "arabfonts","arabfonts"));

            if (extraFontBundle == null)
            {
                Logging.Error("Failed to load Arabic / Hebrew fonts. :( (No extra AssetBundle found!)");
            }
            else
            {
                Logging.Message("Extra Fonts Asset Bundle has been loaded...");

                TMP_FontAsset arabicFontAsset = extraFontBundle.LoadAsset<TMP_FontAsset>("segoeui SDF Arabic");
				TMP_FontAsset hebrewFontAsset = extraFontBundle.LoadAsset<TMP_FontAsset>("segoeui SDF Hebrew");
				Sprite arabicLogo = extraFontBundle.LoadAsset<Sprite>("2023_improved_logo.png");

                Sprite rankD = extraFontBundle.LoadAsset<Sprite>("RankD.png");
                Sprite rankC = extraFontBundle.LoadAsset<Sprite>("RankC.png");
                Sprite rankB = extraFontBundle.LoadAsset<Sprite>("RankB.png");
                Sprite rankA = extraFontBundle.LoadAsset<Sprite>("RankA.png");
                Sprite rankS = extraFontBundle.LoadAsset<Sprite>("RankS.png");
                Sprite rankSS = extraFontBundle.LoadAsset<Sprite>("RankSS.png");
                Sprite rankSSS = extraFontBundle.LoadAsset<Sprite>("RankSSS.png");
                Sprite rankU = extraFontBundle.LoadAsset<Sprite>("RankU.png");

                CustomRankImages = new Sprite[8];
				CustomRankImages[0] = rankD;
				CustomRankImages[1] = rankC;
				CustomRankImages[2] = rankB;
				CustomRankImages[3] = rankA;
				CustomRankImages[4] = rankS;
				CustomRankImages[5] = rankSS;
				CustomRankImages[6] = rankSSS;
				CustomRankImages[7] = rankU;

				if (arabicFontAsset == null)
                {
                    Logging.Warn("There is no Arabic font in this AssetBundle!?");
                }
                else
                {
                    Logging.Message("Arabic Font has been loaded.");
                    ArabicFontTMP = arabicFontAsset;
                }

                if (arabicLogo == null)
                {
					Logging.Warn("There is no Arabic logo in this AssetBundle!?");
				}
                else
                {
                    ArabicUltrakillLogo = arabicLogo;
                }

				if (hebrewFontAsset == null)
				{
					Logging.Warn("There is no Hebrew font in this AssetBundle!?");
				}
				else
				{
					Logging.Message("Hebrew Font has been loaded.");
					HebrewFontTMP = hebrewFontAsset;
				}
			}

			if (fontBundle == null)
            {
                Logging.Error("FAILED TO LOAD");
            }
            else
            {
                Logging.Message("Font bundle loaded.");
                Logging.Message("Loading fonts from bundle...");
                
                Font font1 = fontBundle.LoadAsset<Font>("VCR_OSD_MONO_EXTENDED");
                Font font2 = fontBundle.LoadAsset<Font>("EBGaramond-Regular");
                TMP_FontAsset font1TMP = fontBundle.LoadAsset<TMP_FontAsset>("VCR_OSD_MONO_EXTENDED_TMP");
                TMP_FontAsset font2TMP = fontBundle.LoadAsset<TMP_FontAsset>("EBGaramond-Regular_TMP");
                Material font1TMPTopMat = fontBundle.LoadAsset<Material>("VCR_OSD_MONO_EXTENDED_TMP_Overlay_Material");
                
                TMP_FontAsset cjkFontTMP = fontBundle.LoadAsset<TMP_FontAsset>("NotoSans-CJK_TMP");
                TMP_FontAsset jafontTMP = fontBundle.LoadAsset<TMP_FontAsset>("JF-Dot-jiskan16s-2000_TMP");
                Material cjkFontTMPTopMat = fontBundle.LoadAsset<Material>("NotoSans-CJK_TMP_Overlay_Material");
                Material jaFontTMPTopMat = fontBundle.LoadAsset<Material>("JF-Dot-jiskan16s-2000_TMP_Overlay_Material");
                if (font1 && font2)
                {
                    Logging.Warn("Normal fonts loaded.");
                    GlobalFont = font1;
                    MuseumFont = font2;
                    GlobalFontReady = true;
                }
                else
                {
                    Logging.Error("FAILED TO LOAD NORMAL FONTS");
                    GlobalFontReady = false;
                }
                if(font1TMP && font2TMP && cjkFontTMP && jafontTMP && font1TMPTopMat && cjkFontTMPTopMat && jaFontTMPTopMat)
                {
                    Logging.Warn("Normal TMP fonts loaded.");
                    GlobalFontTMP = font1TMP;
                    MuseumFontTMP = font2TMP;
                    CJKFontTMP = cjkFontTMP;
                    JaFontTMP = jafontTMP;
                    GlobalFontTMPOverlayMat = font1TMPTopMat;
                    CJKFontTMPOverlayMat = cjkFontTMPTopMat;
                    jaFontTMPOverlayMat = jaFontTMPTopMat;
                    
                    TMPFontReady = true;
                }
                else
                {
                    Logging.Error("FAILED TO LOAD TMP FONTS");
                    TMPFontReady = false;
                }
                
                // Load custom fonts after standard fonts and materials are ready
                Logging.Message("Loading custom fonts...");
                LoadCustomFonts();
            }
        }
        
        public static void HandleSceneSwitch(Scene scene,ref GameObject canvas)
        {

            //Logging.Message("Switching scenes...");
            string levelName = GetCurrentSceneName();
            if(levelName == "Intro" || levelName == "Bootstrap")
            { 
                //Don't do anything if we're still booting up the game.
                //Logging.Warn("In intro, not hooking yet");
                return;
            }
            
            //Each scene (level) has an object called Canvas. Most game objects are there.
            GameObject canvasObj = GetInactiveRootObject("Canvas");
            if (!canvasObj)
            {
                Logging.Fatal("UNABLE TO FIND CANVAS IN CURRENT SCENE");
                return;
            }
            else
            {
                TextMeshProFontSwap.ClearFontSwapCache();
                TextFontSwap.TextFontSwapper.ClearCache();

                switch (levelName)
                {
                    case "Intro": { break; }
                    case "Main Menu":
                        {
                            if (Core.wasLanguageReset)
                            {
                                Core.wasLanguageReset = false;
                                MonoSingleton<HudMessageReceiver>.Instance.SendHudMessage("<color=orange>The currently set language file could not be loaded.\nLanguage has been reset to English to avoid problems.</color>");
                            }

                            PatchFrontEnd(canvasObj);

                            if (ultrakullLogo != null)
                            {
                                GameObject.Destroy(ultrakullLogo);
                                ultrakullLogo = null;
                            }

                            ultrakullLogo = new GameObject("UltrakULL_Dropdown");
                            ultrakullLogo.transform.SetParent(canvasObj.transform, false);

                            RectTransform rootRect = ultrakullLogo.AddComponent<RectTransform>();
                            rootRect.anchorMin = new Vector2(1, 1);
                            rootRect.anchorMax = new Vector2(1, 1);
                            rootRect.pivot = new Vector2(1, 1);
                            rootRect.anchoredPosition = new Vector2(-20, -20);
                            rootRect.sizeDelta = new Vector2(250, 30);

                            Image buttonImage = ultrakullLogo.AddComponent<Image>();
                            buttonImage.color = new Color(0.2f, 0.2f, 0.2f, 0.7f);
                            Button button = ultrakullLogo.AddComponent<Button>();

                            GameObject buttonTextObj = new GameObject("ButtonText");
                            buttonTextObj.transform.SetParent(ultrakullLogo.transform, false);
                            RectTransform buttonTextRect = buttonTextObj.AddComponent<RectTransform>();
                            buttonTextRect.anchorMin = Vector2.zero;
                            buttonTextRect.anchorMax = Vector2.one;
                            buttonTextRect.offsetMin = Vector2.zero;
                            buttonTextRect.offsetMax = Vector2.zero;

                            TextMeshProUGUI buttonText = buttonTextObj.AddComponent<TextMeshProUGUI>();
                            buttonText.text = "UltrakULL ▼";
                            buttonText.alignment = TextAlignmentOptions.MidlineRight;
                            buttonText.fontSize = 16;
                            buttonText.color = Color.white;

                            GameObject panel = new GameObject("DropdownPanel");
                            panel.transform.SetParent(ultrakullLogo.transform, false);
                            RectTransform panelRect = panel.AddComponent<RectTransform>();
                            panelRect.anchorMin = new Vector2(1, 1);
                            panelRect.anchorMax = new Vector2(1, 1);
                            panelRect.pivot = new Vector2(1, 1);
                            panelRect.anchoredPosition = new Vector2(0, -30);
                            panelRect.sizeDelta = new Vector2(rootRect.sizeDelta.x, updateAvailable ? 170 : 130);

                            Image panelBg = panel.AddComponent<Image>();
                            panelBg.color = new Color(0f, 0f, 0f, 0.75f);

                            GameObject panelTextObj = new GameObject("PanelText");
                            panelTextObj.transform.SetParent(panel.transform, false);
                            RectTransform panelTextRect = panelTextObj.AddComponent<RectTransform>();
                            panelTextRect.anchorMin = new Vector2(0, 0);
                            panelTextRect.anchorMax = new Vector2(1, 1);
                            panelTextRect.offsetMin = new Vector2(5, 5);
                            panelTextRect.offsetMax = new Vector2(-5, -5);

                            TextMeshProUGUI panelText = panelTextObj.AddComponent<TextMeshProUGUI>();
                            panelText.text = "<color=white>UltrakULL loaded.\nVersion: " + MainPatch.GetVersion() + "\nCurrent locale: " + LanguageManager.CurrentLanguage.metadata.langName;
                            panelText.alignment = TextAlignmentOptions.TopRight;
                            panelText.fontSize = 16;
                            panelText.color = Color.white;


                            if (updateAvailable)
                            {
                                panelText.text += "\n<color=green>UPDATE AVAILABLE!</color>";

                                GameObject updateLink = new GameObject("UpdateLink", typeof(RectTransform), typeof(TextMeshProUGUI), typeof(Button));
                                updateLink.transform.SetParent(panel.transform, false);

                                RectTransform linkRect = updateLink.GetComponent<RectTransform>();
                                linkRect.anchorMin = new Vector2(1, 1);
                                linkRect.anchorMax = new Vector2(1, 1);
                                linkRect.pivot = new Vector2(1, 1);
                                linkRect.anchoredPosition = new Vector2(-5, -90);
                                linkRect.sizeDelta = new Vector2(150, 24);

                                TextMeshProUGUI linkText = updateLink.GetComponent<TextMeshProUGUI>();
                                linkText.font = GlobalFontTMP;
                                linkText.text = "<u><color=white>VIEW UPDATE</color></u>";
                                linkText.alignment = TextAlignmentOptions.TopRight;
                                linkText.fontSize = 16;
                                linkText.raycastTarget = true;

                                Button updateButton = updateLink.GetComponent<Button>();
                                updateButton.onClick.AddListener(() =>
                                {
                                    Application.OpenURL("https://github.com/ClearwaterUK/UltrakULL/releases/latest");
                                });
                            }


                            if (!updateAvailable && updateFailed)
                            {
                                panelText.text += "\n<color=red>Unable to check for updates.\nCheck console for info.</color>";
                            }

                            CanvasGroup panelGroup = panel.AddComponent<CanvasGroup>();
                            panelGroup.alpha = 0f;
                            panelGroup.interactable = false;
                            panelGroup.blocksRaycasts = false;

                            button.onClick.AddListener(() =>
                            {
                                ultrakullDropdownExpanded = !ultrakullDropdownExpanded;
                                panelGroup.alpha = ultrakullDropdownExpanded ? 1f : 0f;
                                panelGroup.interactable = ultrakullDropdownExpanded;
                                panelGroup.blocksRaycasts = ultrakullDropdownExpanded;
                                buttonText.text = ultrakullDropdownExpanded ? "UltrakULL ▲" : "UltrakULL ▼";
                            });

                            break;
                        }

                    default:
                        {
                            if (isUsingEnglish())
                            {
                                Logging.Warn("Current language is English, not patching.");
                                return;
                            }

                            Logging.Message("Regular scene");
                            Logging.Message("Attempting to patch base elements");
                            try { PatchPauseMenu(ref canvasObj); } catch (Exception e) { Console.WriteLine(e.ToString()); }
                            try { Cheats.PatchCheatConsentPanel(ref canvasObj); ; } catch (Exception e) { Console.WriteLine(e.ToString()); }
                            try { Sandbox.PatchAlterMenu(); } catch (Exception e) { Console.WriteLine(e.ToString()); }
                            try { HUDMessages.PatchDeathScreen(ref canvasObj); } catch (Exception e) { Console.WriteLine(e.ToString()); }
                            try { LevelStatWindow.PatchStats(ref canvasObj); } catch (Exception e) { Console.WriteLine(e.ToString()); }
                            try { HUDMessages.PatchMisc(ref canvasObj); } catch (Exception e) { Console.WriteLine(e.ToString()); }
                            try { Options options = new Options(ref canvasObj); } catch (Exception e) { Console.WriteLine(e.ToString()); }

                            Logging.Message("Base elements patched");
                        }


                        if (levelName.Contains("Tutorial"))
                        {
                            Logging.Message("Tutorial");
                        }
                        else if (AngryLevel.IsAngryCustomLevel() == true)
                        {
                            Logging.Message("Angry Custom Level");
                            AngryLevel.PatchAngry();
                        }
                        else if (levelName.Contains("-S"))
                        {
                            Logging.Message("Secret");
                            SecretLevels secretLevels = new SecretLevels(ref canvasObj);
                        }
                        if (levelName.Contains("0-") & !levelName.Contains("-E"))
                        {
                            Logging.Message("Prelude");
                            Prelude preludePatchClass = new Prelude(ref canvasObj);
                        }
                        else if ((levelName.Contains("1-") & !levelName.Contains("-E")) || (levelName.Contains("2-") & !levelName.Contains("-E")) || (levelName.Contains("3-") & !levelName.Contains("-E")))
                        {
                            Logging.Message("Act 1");
                            Act1.PatchAct1(ref canvasObj);
                        }
                        else if ((levelName.Contains("4-") & !levelName.Contains("-E")) || (levelName.Contains("5-") & !levelName.Contains("-E")) || (levelName.Contains("6-") & !levelName.Contains("-E")))
                        {
                            Logging.Message("Act 2");
                            Act2.PatchAct2(ref canvasObj);
                        }
                        else if ((levelName.Contains("7-") & !levelName.Contains("-E")) || (levelName.Contains("8-") & !levelName.Contains("-E")) || (levelName.Contains("9-") & !levelName.Contains("-E")))
                        {
                            Logging.Message("Act 3");
                            if (LanguageManager.CurrentLanguage.act3 != null)
                            {
                                Act3.PatchAct3(ref canvasObj);
                            }
                            else
                            {
                                Logging.Warn("Category is not found in the language file!");
                            }
                        }
                        else if (levelName.Contains("P-"))
                        {
                            Logging.Message("Prime");
                            PrimeSanctum primeSanctumClass = new PrimeSanctum();
                        }
                        else if (levelName.Contains("-E"))
                        {
                            Logging.Message("Encore");
                            if (LanguageManager.CurrentLanguage.encore != null)
                            {
                                Encore.PatchEncore(ref canvasObj);
                            }

                        }
                        else if (levelName == "uk_construct")
                        {
                            Logging.Message("Sandbox");
                            Sandbox sandbox = new Sandbox(ref canvasObj);
                        }
                        else if (levelName == "Endless")
                        {
                            Logging.Message("CyberGrind");
                            CyberGrind.PatchCg();
                        }
                        else if (levelName.Contains("Intermission") || levelName.Contains("EarlyAccessEnd"))
                        {
                            Logging.Message("Intermission");
                            Intermission intermission = new Intermission(ref canvasObj);
                        }
                        else if (levelName == "CreditsMuseum2")
                        {
                            Logging.Message("DevMuseum");
                            DevMuseum devMuseum = new DevMuseum();
                        }
                        break;
                }
            }
        }

        public static async void ApplyPostInitFixes(GameObject canvasObj)
        {
            await Task.Delay(250); // Fix warning about async without await
            /*if (GetCurrentSceneName() == "Main Menu")
            {
                //Open Language Folder button in Options->Language
                TextMeshProUGUI openLangFolderText = GetTextMeshProUGUI(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(GetGameObjectChild(canvasObj,"OptionsMenu"), "Language Page"),"Scroll Rect (1)"),"Contents"),"OpenLangFolder"),"Slot Text")); 
                openLangFolderText.text = "<color=#03fc07>Open language folder</color>";
                
            }*/
        }
    }
}
