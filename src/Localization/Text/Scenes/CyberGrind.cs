using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;
using static UltrakULL.CommonFunctions;

namespace UltrakULL;

public static class CyberGrind
{
    private static void PatchWaveBoard()
    {
        //Get the object containing all the wave board strings.
        //If there's a better way of doing this someone let me know

        GameObject coreGame = GameObject.Find("Everything");
        List<GameObject> everythingList = new List<GameObject>();

        foreach(Transform child in coreGame.transform)
        {
            everythingList.Add(child.gameObject);
        }

        List<GameObject> cubeCanvasList = new List<GameObject>();
        GameObject cubeCanvas = FindDescendant(everythingList[4],"Canvas");
        foreach (Transform child in cubeCanvas.transform)
        {
            cubeCanvasList.Add(child.gameObject);
        }
        GameObject cgBoard = cubeCanvasList[1];

        //Patch all the strings here.
        Text waveText = GetTextfromGameObject(FindDescendant(cgBoard, "Wave Title"));
        waveText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave +  ":";

        Text enemiesLeftText = GetTextfromGameObject(FindDescendant(cgBoard, "Enemies Left Title"));
        enemiesLeftText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_enemiesRemaining + ":";

    }

    private static void PatchResults()
    {
        GameObject level = GameObject.Find("Player");

        GameObject resultsPanel = FindDescendant(level, "FinishCanvas (1)", "Panel");
        GameObject lastResult = FindDescendant(resultsPanel, "Panel");
        GameObject bestResult = FindDescendant(resultsPanel, "Panel (1)","Filler");
        GameObject pointsPanel = FindDescendant(resultsPanel, "Total Points");
        GameObject leaderboardsPanel = FindDescendant(resultsPanel, "Cyber Grind Leaderboards");

        //Both result panels use the same strings, so declare them here to avoid redundancy.
        string wave = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave;
        string kills = LanguageManager.CurrentLanguage.misc.levelstats_kills;
        string style = LanguageManager.CurrentLanguage.misc.levelstats_style;
        string time = LanguageManager.CurrentLanguage.misc.levelstats_time;


        //Title
        TextMeshProUGUI titleText= GetTextMeshProUGUI(FindDescendant(resultsPanel, "Title", "Text"));
        titleText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_cgTitle;

        //Last result panel
        TextMeshProUGUI lastTitle = GetTextMeshProUGUI(FindDescendant(lastResult, "Text"));
        lastTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_previousRun;

        TextMeshProUGUI lastWave = GetTextMeshProUGUI(FindDescendant(lastResult, "Wave - Info", "Text"));
        lastWave.text = wave;

        TextMeshProUGUI lastKills = GetTextMeshProUGUI(FindDescendant(lastResult, "Kills - Info", "Text"));
        lastKills.text = kills;

        TextMeshProUGUI lastStyle = GetTextMeshProUGUI(FindDescendant(lastResult, "Style - Info", "Text"));
        lastStyle.text = style;

        TextMeshProUGUI lastTime = GetTextMeshProUGUI(FindDescendant(lastResult, "Time - Info", "Text"));
        lastTime.text = time;

        //Best result panel
        TextMeshProUGUI bestTitle = GetTextMeshProUGUI(FindDescendant(bestResult, "Text (1)"));
        bestTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_bestRun;

        TextMeshProUGUI bestWave = GetTextMeshProUGUI(FindDescendant(bestResult, "Wave - Info (1)", "Text"));
        bestWave.text = wave;

        TextMeshProUGUI bestKills = GetTextMeshProUGUI(FindDescendant(bestResult, "Kills - Info (1)", "Text"));
        bestKills.text = kills;

        TextMeshProUGUI bestStyle = GetTextMeshProUGUI(FindDescendant(bestResult, "Style - Info (1)", "Text"));
        bestStyle.text = style;

        TextMeshProUGUI bestTime = GetTextMeshProUGUI(FindDescendant(bestResult, "Time - Info (1)", "Text"));
        bestTime.text = time;

        //Points panel
        TextMeshProUGUI totalPointsText = GetTextMeshProUGUI(FindDescendant(pointsPanel, "Text (1)"));
        totalPointsText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total;

        TextMeshProUGUI totalPoints = GetTextMeshProUGUI(FindDescendant(pointsPanel, "Text"));
        totalPoints.text = "+0" + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_moneyCount + "</color>";

        //Leaderboards

        string connecting = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;

        GameObject friendScores = FindDescendant(leaderboardsPanel, "Friend High Scores");
        GameObject globalScores = FindDescendant(leaderboardsPanel, "Global High Scores");

        TextMeshProUGUI friendScoresTitle = GetTextMeshProUGUI(FindDescendant(friendScores, "Text"));
        friendScoresTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_friendScores;

        TextMeshProUGUI globalScoresTitle = GetTextMeshProUGUI(FindDescendant(globalScores, "Text"));
        globalScoresTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_globalScores;

        TextMeshProUGUI friendsConnectingText = GetTextMeshProUGUI(FindDescendant(friendScores, "Connecting"));
        friendsConnectingText.text = connecting;

        TextMeshProUGUI globalConnectingText = GetTextMeshProUGUI(FindDescendant(globalScores, "Connecting"));
        globalConnectingText.text = connecting;


    }

    private static void PatchTerminal()
    {
        GameObject level = GameObject.Find("FirstRoom");
        GameObject cgTerminal = FindDescendant(level, "Room", "Cybergrind Shop", "Canvas");

        GameObject cgTerminalMainPanel = FindDescendant(cgTerminal, "Background", "Main Panel");

        //Terminal description(I just ripped off from shop.cs lol)
        GameObject tipPanel = FindDescendant(cgTerminalMainPanel, "Stats");
        TextMeshProUGUI cgTerminalTipboxTitle = GetTextMeshProUGUI(FindDescendant(tipPanel, "Title"));
        cgTerminalTipboxTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settings;

        TextMeshProUGUI cgTerminalTipboxDescription = GetTextMeshProUGUI(FindDescendant(tipPanel, "Panel", "Text Inset", "Text"));
        cgTerminalTipboxDescription.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settingsDescription;

        //Main menu
        GameObject mainButtons = FindDescendant(cgTerminalMainPanel, "Main Menu", "Buttons");

        TextMeshProUGUI cgTerminalThemesText = GetTextMeshProUGUI(FindDescendant(mainButtons, "Themes Button", "Text"));
        cgTerminalThemesText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themes;

        TextMeshProUGUI cgTerminalMusicText = GetTextMeshProUGUI(FindDescendant(mainButtons, "Music Button", "Text"));
        cgTerminalMusicText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_music;

        TextMeshProUGUI cgTerminalPatternsText = GetTextMeshProUGUI(FindDescendant(mainButtons, "Patterns Button", "Text"));
        cgTerminalPatternsText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patterns;

        TextMeshProUGUI cgTerminalWaveText = GetTextMeshProUGUI(FindDescendant(mainButtons, "Waves Button", "Text"));
        cgTerminalWaveText.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_waves;

        //Themes
        GameObject cgTerminalThemes = FindDescendant(cgTerminalMainPanel, "Themes","Preset Panel");

        TextMeshProUGUI cgTerminalThemesTitle = GetTextMeshProUGUI(FindDescendant(cgTerminalThemes, "Title"));
        cgTerminalThemesTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesTitle;

        GameObject cgTerminalThemesPanel = FindDescendant(cgTerminalThemes, "Panel");

        TextMeshProUGUI cgTerminalThemesDescription = GetTextMeshProUGUI(FindDescendant(cgTerminalThemesPanel, "Text"));
        cgTerminalThemesDescription.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDescription;
        
        GameObject cgTerminalThemesButton = FindDescendant(cgTerminalThemesPanel, "Buttons");

        TextMeshProUGUI cgTerminalThemesLight = GetTextMeshProUGUI(FindDescendant(cgTerminalThemesButton, "Light Button", "Text"));
        cgTerminalThemesLight.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesLight;

        TextMeshProUGUI cgTerminalThemesDark = GetTextMeshProUGUI(FindDescendant(cgTerminalThemesButton, "Dark Button", "Text"));
        cgTerminalThemesDark.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDark;

        TextMeshProUGUI cgTerminalThemesCustom = GetTextMeshProUGUI(FindDescendant(cgTerminalThemesButton, "Custom Button", "Text"));
        cgTerminalThemesCustom.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom;

        TextMeshProUGUI cgTerminalThemesBack = GetTextMeshProUGUI(FindDescendant(cgTerminalThemes.transform.parent.gameObject, "Back Button", "Text"));
        cgTerminalThemesBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

        //Playlist
        GameObject cgMusic = FindDescendant(cgTerminalMainPanel, "Playlist","Panel");
        
        TextMeshProUGUI cgMusicTitle = GetTextMeshProUGUI(FindDescendant(cgMusic.transform.parent.gameObject,"Title"));
        cgMusicTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicTitle;
        
        TextMeshProUGUI cgMusicClose = GetTextMeshProUGUI(FindDescendant(cgMusic, "Close Button","Text"));
        cgMusicClose.text = LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose;

        //Songs Type Selection(+ button in playlist will show this up)
        GameObject cgMusicTypeCanvas = FindDescendant(cgTerminalMainPanel, "Songs Type Selection", "Panel");

        TextMeshProUGUI cgMusicTypeTitle = GetTextMeshProUGUI(FindDescendant(cgMusicTypeCanvas.transform.parent.gameObject, "Title"));
        cgMusicTypeTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicType;

        GameObject cgMusicTypeButtons = FindDescendant(cgMusicTypeCanvas, "Inset", "Type Selection Buttons");
        TextMeshProUGUI cgMusicTypeULTRAKILL = GetTextMeshProUGUI(FindDescendant(cgMusicTypeButtons, "Soundtrack Button", "Text"));
        cgMusicTypeULTRAKILL.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack;

        TextMeshProUGUI cgMusicTypeCustom = GetTextMeshProUGUI(FindDescendant(cgMusicTypeButtons, "Custom Button", "Text"));
        cgMusicTypeCustom.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom;

        TextMeshProUGUI cgMusicTypeClose = GetTextMeshProUGUI(FindDescendant(cgMusicTypeCanvas, "Close Button", "Text"));
        cgMusicTypeClose.text = LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose;

        GameObject cgMusicSoundtrack = FindDescendant(cgTerminalMainPanel, "Songs Soundtrack", "Panel");
        TextMeshProUGUI cgMusicSoundtrackTitle = GetTextMeshProUGUI(FindDescendant(cgMusicSoundtrack.transform.parent.gameObject, "Title"));
        cgMusicSoundtrackTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack;

        TextMeshProUGUI cgMusicSoundtrackClose = GetTextMeshProUGUI(FindDescendant(cgMusicSoundtrack, "Close Button", "Text"));
        cgMusicSoundtrackClose.text = LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose;

        GameObject cgMusicSoundtrackAddMenu = FindDescendant(cgMusicSoundtrack,"Inset","Songs");

        //CustomMusic
        GameObject cgCustomMusic = FindDescendant(cgTerminalMainPanel, "Songs Custom", "Panel");

        TextMeshProUGUI cgCustomMusicTitle = GetTextMeshProUGUI(FindDescendant(cgCustomMusic.transform.parent.gameObject, "Title"));
        cgCustomMusicTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom;

        TextMeshProUGUI cgCustomMusicClose = GetTextMeshProUGUI(FindDescendant(cgCustomMusic, "Close Button", "Text"));
        cgCustomMusicClose.text = LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose;

        //Changes the "Unlocked" string under songs that are unlocked

        foreach (Transform child in cgMusicSoundtrackAddMenu.transform)
        {
            if (child.name == "Song Template(Clone)")
            {
                TextMeshProUGUI cgMusicSoundtrackTask = GetTextMeshProUGUI(FindDescendant(child.gameObject, "Requirement"));
                if (cgMusicSoundtrackTask.text == "Unlocked") { cgMusicSoundtrackTask.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlocked; }
            }
        }
        Button[] aas = cgMusicSoundtrack.GetComponentsInChildren<Button>(true);
        foreach (Button button in aas)
        {
            button.onClick.AddListener(delegate { PatchTerminalFolder(); });
        }
        
        
        //Customize theme
        GameObject cgCustomTheme = FindDescendant(cgTerminalMainPanel, "Theme Custom","Panel");
        TextMeshProUGUI cgCustomThemeTitle = GetTextMeshProUGUI(FindDescendant(cgCustomTheme.transform.parent.gameObject, "Title"));
        //"Custom", replace this later
        cgCustomThemeTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesModify;

        GameObject cgCustomThemeButtons = FindDescendant(cgCustomTheme, "Sidebar");
        GameObject cgCustomThemeSelectorButtons = FindDescendant(cgCustomThemeButtons, "Selector Buttons");
        TextMeshProUGUI cgCustomGrid = GetTextMeshProUGUI(FindDescendant(cgCustomThemeSelectorButtons, "Grid Button","Text"));
        cgCustomGrid.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGrid;

        TextMeshProUGUI cgCustomGridGlow = GetTextMeshProUGUI(FindDescendant(cgCustomThemeSelectorButtons, "Glow Button","Text"));
        cgCustomGridGlow.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGridGlow;

        TextMeshProUGUI cgCustomSkybox = GetTextMeshProUGUI(FindDescendant(cgCustomThemeSelectorButtons, "Skybox Button","Text"));
        cgCustomSkybox.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomSkybox;

        TextMeshProUGUI cgCustomFog = GetTextMeshProUGUI(FindDescendant(cgCustomThemeSelectorButtons, "Fog Button","Text"));
        cgCustomFog.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFog;

        TextMeshProUGUI cgCustomThemeBack = GetTextMeshProUGUI(FindDescendant(cgCustomThemeButtons, "Back Button","Text"));
        cgCustomThemeBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

        //Leftside Buttons(Custom Theme)
        GameObject cgCustomAdditionalRows = FindDescendant(cgCustomTheme, "Window");

        TextMeshProUGUI cgCustomRefresh = GetTextMeshProUGUI(FindDescendant(cgCustomAdditionalRows, "Grid Wrapper","Refresh Button","Text"));
        cgCustomRefresh.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh;

        GameObject cgCustomGridTypeSelection = FindDescendant(cgCustomAdditionalRows, "Grid Type Selection");

        TextMeshProUGUI cgCustomAdditionalBase = GetTextMeshProUGUI(FindDescendant(cgCustomGridTypeSelection, "Base Button","Text"));
        cgCustomAdditionalBase.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBase;

        TextMeshProUGUI cgCustomAdditionalTopRow = GetTextMeshProUGUI(FindDescendant(cgCustomGridTypeSelection, "Top Row Button","Text"));
        cgCustomAdditionalTopRow.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTopRow;

        TextMeshProUGUI cgCustomAdditionalTop = GetTextMeshProUGUI(FindDescendant(cgCustomGridTypeSelection, "Top Button","Text"));
        cgCustomAdditionalTop.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTop;

        TextMeshProUGUI cgCustomAdditionalGlowIntensity = GetTextMeshProUGUI(FindDescendant(cgCustomAdditionalRows, "Glow Intensity","Title"));
        cgCustomAdditionalGlowIntensity.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGlowIntensity;
        //Fog Control goes here, add it later

        GameObject cgCustomFogWindow = FindDescendant(cgCustomAdditionalRows, "Fog Control");
        GameObject cgCustomFogSlider = FindDescendant(cgCustomFogWindow, "Sliders");
        GameObject cgCustomFogSliderLayoutGroup = FindDescendant(cgCustomFogSlider, "Layout Group"); //This is the parent of all sliders
        GameObject cgCustomFogTabs = FindDescendant(cgCustomFogWindow, "Tabs"); //Now this GameObject contains all buttons to switch fog type. "Disable", "Static", "Dynamic"

        //Patch Color
        TextMeshProUGUI cgCustomFogColor = GetTextMeshProUGUI(FindDescendant(cgCustomFogWindow, "Color","Text")); //Color moved to Window in 16d Patch
        cgCustomFogColor.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogColor;

        //Patch Sliders Text and "Disable" Description
        TextMeshProUGUI cgCustomFogDisableDesc = GetTextMeshProUGUI(FindDescendant(cgCustomFogSlider, "Fog Disabled Text"));
        cgCustomFogDisableDesc.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDisableDesc;

        TextMeshProUGUI cgCustomFogStart = GetTextMeshProUGUI(FindDescendant(cgCustomFogSliderLayoutGroup, "Start Distance","Text"));
        cgCustomFogStart.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogStart;

        TextMeshProUGUI cgCustomFogEnd = GetTextMeshProUGUI(FindDescendant(cgCustomFogSliderLayoutGroup, "End Distance","Text"));
        cgCustomFogEnd.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogEnd;

        //Patch Buttons in Tabs. "Disable", "Static", "Dynamic"
        TextMeshProUGUI cgCustomFogDisable = GetTextMeshProUGUI(FindDescendant(cgCustomFogTabs, "Disabled Button","Text"));
        cgCustomFogDisable.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDisable;

        TextMeshProUGUI cgCustomFogStatic = GetTextMeshProUGUI(FindDescendant(cgCustomFogTabs, "Static Button","Text"));
        cgCustomFogStatic.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogStatic;

        TextMeshProUGUI cgCustomFogDynamic = GetTextMeshProUGUI(FindDescendant(cgCustomFogTabs, "Dynamic Button","Text"));
        cgCustomFogDynamic.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamic;

        //"Set to default" button
        TextMeshProUGUI cgCustomFogDefault = GetTextMeshProUGUI(FindDescendant(cgCustomFogWindow, "Default Button","Text"));
        cgCustomFogDefault.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDefault;

        //Patterns
        GameObject cgTerminalPatterns = FindDescendant(cgTerminalMainPanel, "Patterns", "Patterns Window", "Panel");

        TextMeshProUGUI cgTerminalPatternsTitle = GetTextMeshProUGUI(FindDescendant(cgTerminalPatterns.transform.parent.gameObject, "Title"));
        cgTerminalPatternsTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsTitle;

        TextMeshProUGUI cgPatternsWarning = GetTextMeshProUGUI(FindDescendant(cgTerminalPatterns,"Warning Text"));
        cgPatternsWarning.text = "<color=red>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsWarning + "</color>";

        bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
        TextMeshProUGUI cgPatternsSwitchButton = cgTerminalPatterns.transform.Cast<Transform>().FirstOrDefault(t => t.name == "Enable/Disable Button")?.Find("Text")?.GetComponent<TextMeshProUGUI>();
        cgPatternsSwitchButton.text = customPatternMode
            ? LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButtonNot
            : LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButton;

        TextMeshProUGUI cgPatternsBack = GetTextMeshProUGUI(FindDescendant(cgTerminalMainPanel, "Patterns", "Back Button", "Text"));
        cgPatternsBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;

        //TextMeshProUGUI cgCustomStateButton = GetTextMeshProUGUI(FindDescendant(FindDescendant(cgTerminalPatterns, "StateButton"), "Text"));
        //bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
        //cgCustomStateButton.text = (customPatternMode ? LanguageManager.CurrentLanguage.misc.state_activated : LanguageManager.CurrentLanguage.misc.state_deactivated);
        //it seems broken vanilla rn, so skipping it

        TextMeshProUGUI cgTerminalPatternsEditor = GetTextMeshProUGUI(FindDescendant(cgTerminalPatterns, "Patterns", "Editor Button", "Text"));
        cgTerminalPatternsEditor.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsLaunchExternalEditor;

        //Waves
        GameObject cgTerminalWaves = FindDescendant(cgTerminalMainPanel, "Waves", "Waves Window", "Panel");

        TextMeshProUGUI cgTerminalWavesTitle = GetTextMeshProUGUI(FindDescendant(cgTerminalWaves.transform.parent.gameObject, "Title"));
        cgTerminalWavesTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesTitle;

        TextMeshProUGUI cgTerminalWavesText = GetTextMeshProUGUI(FindDescendant(cgTerminalWaves, "Select Wave Text"));
        cgTerminalWavesText.text =
            LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription1;
        cgTerminalWavesText.fontSize = 16;
        TextMeshProUGUI cgTerminalWavesReqText = GetTextMeshProUGUI(FindDescendant(cgTerminalWaves, "Wave Requirement Text"));
        cgTerminalWavesReqText.text =
            LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription2;

        TextMeshProUGUI cgWavesBack = GetTextMeshProUGUI(FindDescendant(cgTerminalMainPanel, "Waves", "Back Button", "Text"));
        cgWavesBack.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack;
    }

    public async static void PatchTerminalFolder()
    {
        //Changes all folders' own names based on their original name
        GameObject level = GameObject.Find("FirstRoom");
        GameObject cgTerminalMainPanel = FindDescendant(level, "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel");
        GameObject cgMusicSoundtrack = FindDescendant(cgTerminalMainPanel, "Songs Soundtrack", "Panel");
        GameObject cgMusicSoundtrackAddMenu = FindDescendant(cgMusicSoundtrack, "Inset", "Songs");
        await Task.Delay(5);
        foreach (Transform child in cgMusicSoundtrackAddMenu.transform)
        {
            if (child.name == "Folder Template(Clone)")
            {
                Button a = child.GetComponent<Button>();
                a.onClick.AddListener(delegate { PatchTerminalFolder(); });
                TextMeshProUGUI cgMusicSoundtrackFolderTitle = GetTextMeshProUGUI(FindDescendant(child.gameObject, "Title"));
                switch (cgMusicSoundtrackFolderTitle.text.ToUpper())
                {
                    case "THE CYBER GRIND": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameCyberGrind; break; }
                    case "PRELUDE": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrelude; break; }
                    case "ACT 1": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct1; break; }
                    case "ACT 2": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct2; break; }
                    case "ACT 3": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct3; break; }
                    case "SECRET LEVELS": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameSecret; break; }
                    case "PRIME SANCTUMS": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrime; break; }
                    case "MISCELLANEOUS TRACKS": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameMisc; break; }
                    case "ENCORES": { cgMusicSoundtrackFolderTitle.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameEncores; break; }

                    default: {Logging.Warn("Missing CG music folder name: " + cgMusicSoundtrackFolderTitle.text); break; }
                }
            }
            if (child.name == "Song Template(Clone)")
            {
                TextMeshProUGUI cgMusicSoundtrackTask = GetTextMeshProUGUI(FindDescendant(child.gameObject, "Requirement"));
                if (cgMusicSoundtrackTask.text == "Unlocked") { cgMusicSoundtrackTask.text = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlocked; }
            }
        }
        return;
    }
    public static void PatchCg()
    {
        try { PatchWaveBoard(); }catch (Exception e) { Console.WriteLine("Failed to patch CG wave board"); Console.WriteLine(e.ToString());}
        try { PatchResults(); }catch (Exception e) { Console.WriteLine("Failed to patch CG results"); Console.WriteLine(e.ToString());}
        try { PatchTerminal(); }catch (Exception e) { Console.WriteLine("Failed to patch CG terminal"); Console.WriteLine(e.ToString());}
        try { PatchTerminalFolder(); }catch (Exception e) { Console.WriteLine("Failed to patch CG terminal folders"); Console.WriteLine(e.ToString());}
        
    }
}
