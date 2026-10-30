using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class CyberGrind
{
    private static void PatchWaveBoard()
    {
        var coreGame = GetObject("Everything");
        var everythingList = new List<GameObject>();

        foreach (Transform child in coreGame.transform)
        {
            everythingList.Add(child.gameObject);
        }

        var cubeCanvas = FindDescendant(everythingList[4], "Canvas");
        var cubeCanvasList = new List<GameObject>();
        foreach (Transform child in cubeCanvas.transform)
        {
            cubeCanvasList.Add(child.gameObject);
        }
        var cgBoard = cubeCanvasList[1];

        cgBoard.Localize<Text>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave,
            path: ["Wave Title"]);

        cgBoard.Localize<Text>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_enemiesRemaining,
            path: ["Enemies Left Title"]);
    }

    private static void PatchResults()
    {
        var level = GetObject("Player");

        var wave = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave;
        var kills = LanguageManager.CurrentLanguage.misc.levelstats_kills;
        var style = LanguageManager.CurrentLanguage.misc.levelstats_style;
        var time = LanguageManager.CurrentLanguage.misc.levelstats_time;

        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_cgTitle,
            path: ["FinishCanvas (1)", "Panel", "Title", "Text"]);

        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_previousRun,
            path: ["FinishCanvas (1)", "Panel", "Panel", "Text"]);

        level.Localize<TextMeshProUGUI>(wave,
            path: ["FinishCanvas (1)", "Panel", "Panel", "Wave - Info", "Text"]);

        level.Localize<TextMeshProUGUI>(kills,
            path: ["FinishCanvas (1)", "Panel", "Panel", "Kills - Info", "Text"]);

        level.Localize<TextMeshProUGUI>(style,
            path: ["FinishCanvas (1)", "Panel", "Panel", "Style - Info", "Text"]);

        level.Localize<TextMeshProUGUI>(time,
            path: ["FinishCanvas (1)", "Panel", "Panel", "Time - Info", "Text"]);

        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_bestRun,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)", "Filler", "Text (1)"]);

        level.Localize<TextMeshProUGUI>(wave,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)", "Filler", "Wave - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(kills,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)", "Filler", "Kills - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(style,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)", "Filler", "Style - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(time,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)", "Filler", "Time - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total,
            path: ["FinishCanvas (1)", "Panel", "Total Points", "Text (1)"]);

        level.Localize<TextMeshProUGUI>("+0" + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_moneyCount + "</color>",
            path: ["FinishCanvas (1)", "Panel", "Total Points", "Text"]);

        var connecting = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;

        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_friendScores,
            path: ["FinishCanvas (1)", "Panel", "Cyber Grind Leaderboards", "Friend High Scores", "Text"]);

        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_globalScores,
            path: ["FinishCanvas (1)", "Panel", "Cyber Grind Leaderboards", "Global High Scores", "Text"]);

        level.Localize<TextMeshProUGUI>(connecting,
            path: ["FinishCanvas (1)", "Panel", "Cyber Grind Leaderboards", "Friend High Scores", "Connecting"]);

        level.Localize<TextMeshProUGUI>(connecting,
            path: ["FinishCanvas (1)", "Panel", "Cyber Grind Leaderboards", "Global High Scores", "Connecting"]);
    }


    private static void PatchTerminal()
    {
        var shop = GetObject("FirstRoom", "Room", "Cybergrind Shop");
        var navigator = shop.GetComponent<CyberGrindSettingsNavigator>();
        var mainPanel = shop.transform.Find("Canvas/Background/Main Panel").gameObject;

        LocalizeSettings(mainPanel);
        LocalizeThemes(navigator);
        LocalizeMusic(navigator);
        LocalizeThemeCustom(navigator);
        LocalizePatterns(navigator);
        LocalizeWaves(navigator);
    }

    private static void LocalizeSettings(GameObject mainPanel)
    {
        mainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settings,
            path: ["Stats", "Title"]).AddWidthAndHeight(110f, 0f);

        mainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settingsDescription,
            path: ["Stats", "Panel", "Text Inset", "Text"]);

        mainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themes,
            path: ["Main Menu", "Buttons", "Themes Button", "Text"]);

        mainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_music,
            path: ["Main Menu", "Buttons", "Music Button", "Text"]);

        mainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patterns,
            path: ["Main Menu", "Buttons", "Patterns Button", "Text"]);

        mainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_waves,
            path: ["Main Menu", "Buttons", "Waves Button", "Text"]);
    }

    private static void LocalizeThemes(CyberGrindSettingsNavigator navigator)
    {
        var themes = navigator.GetPanel("Themes");

        themes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesTitle,
            path: ["Preset Panel", "Title"]).AddWidthAndHeight(110f, 0f);

        themes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDescription,
            path: ["Preset Panel", "Panel", "Text"]);

        themes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesLight,
            path: ["Preset Panel", "Panel", "Buttons", "Light Button", "Text"]);

        themes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDark,
            path: ["Preset Panel", "Panel", "Buttons", "Dark Button", "Text"]);

        themes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom,
            path: ["Preset Panel", "Panel", "Buttons", "Custom Button", "Text"]);

        themes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Back Button", "Text"]);
    }

    private static void LocalizeMusic(CyberGrindSettingsNavigator navigator)
    {
        var close = LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose;

        var playlist = navigator.GetPanel("Playlist");
        playlist.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicTitle,
            path: ["Title"]).AddWidthAndHeight(110f, 0f);
        playlist.Localize<TextMeshProUGUI>(close,
            path: ["Panel", "Close Button", "Text"]);

        var typeSelection = navigator.GetPanel("Songs Type Selection");
        typeSelection.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicType,
            path: ["Title"]);
        typeSelection.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack,
            path: ["Panel", "Inset", "Type Selection Buttons", "Soundtrack Button", "Text"]);
        typeSelection.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom,
            path: ["Panel", "Inset", "Type Selection Buttons", "Custom Button", "Text"]);
        typeSelection.Localize<TextMeshProUGUI>(close,
            path: ["Panel", "Close Button", "Text"]);

        var soundtrack = navigator.GetPanel("Songs Soundtrack");
        soundtrack.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack,
            path: ["Title"]).AddWidthAndHeight(110f, 0f);
        soundtrack.Localize<TextMeshProUGUI>(close,
            path: ["Panel", "Close Button", "Text"]);

        var custom = navigator.GetPanel("Songs Custom");
        custom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom,
            path: ["Title"]).AddWidthAndHeight(110f, 0f);
        custom.Localize<TextMeshProUGUI>(close,
            path: ["Panel", "Close Button", "Text"]);

        foreach (var button in soundtrack.GetComponentsInChildren<Button>(true))
        {
            button.onClick.AddListener(delegate { PatchTerminalFolder(); });
        }
    }

    private static void LocalizeThemeCustom(CyberGrindSettingsNavigator navigator)
    {
        var themeCustom = navigator.GetPanel("Theme Custom");

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesModify,
            path: ["Title"]).AddWidthAndHeight(110f, 0f);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGrid,
            path: ["Panel", "Sidebar", "Selector Buttons", "Grid Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGridGlow,
            path: ["Panel", "Sidebar", "Selector Buttons", "Glow Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomSkybox,
            path: ["Panel", "Sidebar", "Selector Buttons", "Skybox Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFog,
            path: ["Panel", "Sidebar", "Selector Buttons", "Fog Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Panel", "Sidebar", "Back Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh,
            path: ["Panel", "Window", "Grid Wrapper", "Refresh Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBase,
            path: ["Panel", "Window", "Grid Type Selection", "Base Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTopRow,
            path: ["Panel", "Window", "Grid Type Selection", "Top Row Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTop,
            path: ["Panel", "Window", "Grid Type Selection", "Top Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGlowIntensity,
            path: ["Panel", "Window", "Glow Intensity", "Title"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogColor,
            path: ["Panel", "Window", "Fog Control", "Color", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDisableDesc,
            path: ["Panel", "Window", "Fog Control", "Sliders", "Fog Disabled Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogStart,
            path: ["Panel", "Window", "Fog Control", "Sliders", "Layout Group", "Start Distance", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogEnd,
            path: ["Panel", "Window", "Fog Control", "Sliders", "Layout Group", "End Distance", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDisable,
            path: ["Panel", "Window", "Fog Control", "Tabs", "Disabled Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogStatic,
            path: ["Panel", "Window", "Fog Control", "Tabs", "Static Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamic,
            path: ["Panel", "Window", "Fog Control", "Tabs", "Dynamic Button", "Text"]);

        themeCustom.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDefault,
            path: ["Panel", "Window", "Fog Control", "Default Button", "Text"]);
    }

    private static void LocalizePatterns(CyberGrindSettingsNavigator navigator)
    {
        var patterns = navigator.GetPanel("Patterns");

        patterns.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsTitle,
            path: ["Patterns Window", "Title"]).AddWidthAndHeight(110f, 0f);

        patterns.Localize<TextMeshProUGUI>("<color=red>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsWarning + "</color>",
            path: ["Patterns Window", "Panel", "Warning Text"]);

        patterns.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsLaunchExternalEditor,
            path: ["Patterns Window", "Panel", "Patterns", "Editor Button", "Text"]);

        patterns.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Back Button", "Text"]);

        patterns.Localize<TextMeshProUGUI>(MonoSingleton<EndlessGrid>.Instance.customPatternMode
            ? LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButtonNot
            : LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButton,
            path: ["Patterns Window", "Panel", "Enable/Disable Button", "Text"]);
    }

    private static void LocalizeWaves(CyberGrindSettingsNavigator navigator)
    {
        var waves = navigator.GetPanel("Waves");

        waves.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesTitle,
            path: ["Waves Window", "Title"]).AddWidthAndHeight(110f, 0f);

        waves.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription1,
            path: ["Waves Window", "Panel", "Select Wave Text"]).fontSize = 16;

        waves.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription2,
            path: ["Waves Window", "Panel", "Wave Requirement Text"]);

        waves.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Back Button", "Text"]);
    }

    public async static void PatchTerminalFolder()
    {
        var songs = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Songs Soundtrack", "Panel", "Inset", "Songs");
        await Task.Delay(5);

        foreach (Transform child in songs.transform)
        {
            if (child.name == "Folder Template(Clone)")
            {
                var folder = child.GetComponent<Button>();
                folder.onClick.AddListener(delegate { PatchTerminalFolder(); });

                var folderTitle = GetTextMeshProUGUI(FindDescendant(child.gameObject, "Title"));
                switch (folderTitle.text.ToUpper())
                {
                    case "THE CYBER GRIND": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameCyberGrind); break; }
                    case "PRELUDE": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrelude); break; }
                    case "ACT 1": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct1); break; }
                    case "ACT 2": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct2); break; }
                    case "ACT 3": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct3); break; }
                    case "SECRET LEVELS": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameSecret); break; }
                    case "PRIME SANCTUMS": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrime); break; }
                    case "MISCELLANEOUS TRACKS": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameMisc); break; }
                    case "ENCORES": { folderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameEncores); break; }
                    default: { Logging.Warn("Missing CG music folder name: " + folderTitle.text); break; }
                }
            }
        }
    }

    public static void PatchCg()
    {
        SafeRun.Run("CyberGrind: wave board", PatchWaveBoard);
        SafeRun.Run("CyberGrind: results", PatchResults);
        SafeRun.Run("CyberGrind: terminal", PatchTerminal);
        SafeRun.Run("CyberGrind: terminal folders", () => PatchTerminalFolder());
    }
}
