using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
        //Get the object containing all the wave board strings.
        //If there's a better way of doing this someone let me know

        GameObject coreGame = GetObject("Everything");
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
        cgBoard.Localize<Text>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave,
            path: ["Wave Title"]);

        cgBoard.Localize<Text>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_enemiesRemaining,
            path: ["Enemies Left Title"]);

    }

    private static void PatchResults()
    {
        GameObject level = GetObject("Player");


        //Both result panels use the same strings, so declare them here to avoid redundancy.
        string wave = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wave;
        string kills = LanguageManager.CurrentLanguage.misc.levelstats_kills;
        string style = LanguageManager.CurrentLanguage.misc.levelstats_style;
        string time = LanguageManager.CurrentLanguage.misc.levelstats_time;


        //Title
        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_cgTitle,
            path: ["FinishCanvas (1)", "Panel", "Title", "Text"]);

        //Last result panel
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

        //Best result panel
        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_bestRun,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)","Filler", "Text (1)"]);

        level.Localize<TextMeshProUGUI>(wave,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)","Filler", "Wave - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(kills,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)","Filler", "Kills - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(style,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)","Filler", "Style - Info (1)", "Text"]);

        level.Localize<TextMeshProUGUI>(time,
            path: ["FinishCanvas (1)", "Panel", "Panel (1)","Filler", "Time - Info (1)", "Text"]);

        //Points panel
        level.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_total,
            path: ["FinishCanvas (1)", "Panel", "Total Points", "Text (1)"]);

        level.Localize<TextMeshProUGUI>("+0" + "<color=orange>" + LanguageManager.CurrentLanguage.shop.shop_moneyCount + "</color>",
            path: ["FinishCanvas (1)", "Panel", "Total Points", "Text"]);

        //Leaderboards

        string connecting = LanguageManager.CurrentLanguage.cyberGrind.cybergrind_connectingToSteam;


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

        GameObject cgTerminalMainPanel = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel");

        //Terminal description(I just ripped off from shop.cs lol)
        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settings,
            path: ["Stats", "Title"]);

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_settingsDescription,
            path: ["Stats", "Panel", "Text Inset", "Text"]);

        //Main menu

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themes,
            path: ["Main Menu", "Buttons", "Themes Button", "Text"]);

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_music,
            path: ["Main Menu", "Buttons", "Music Button", "Text"]);

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patterns,
            path: ["Main Menu", "Buttons", "Patterns Button", "Text"]);

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_waves,
            path: ["Main Menu", "Buttons", "Waves Button", "Text"]);

        //Themes
        GameObject cgTerminalThemes = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Themes", "Preset Panel");

        cgTerminalThemes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesTitle,
            path: ["Title"]);


        cgTerminalThemes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDescription,
            path: ["Panel", "Text"]);
        

        cgTerminalThemes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesLight,
            path: ["Panel", "Buttons", "Light Button", "Text"]);

        cgTerminalThemes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesDark,
            path: ["Panel", "Buttons", "Dark Button", "Text"]);

        cgTerminalThemes.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom,
            path: ["Panel", "Buttons", "Custom Button", "Text"]);

        cgTerminalThemes.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Back Button", "Text"]);

        //Playlist
        GameObject cgMusic = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Playlist", "Panel");
        
        cgMusic.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicTitle,
            path: ["Title"]);
        
        cgMusic.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose,
            path: ["Close Button","Text"]);

        //Songs Type Selection(+ button in playlist will show this up)
        GameObject cgMusicTypeCanvas = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Songs Type Selection", "Panel");

        cgMusicTypeCanvas.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicType,
            path: ["Title"]);

        cgMusicTypeCanvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack,
            path: ["Inset", "Type Selection Buttons", "Soundtrack Button", "Text"]);

        cgMusicTypeCanvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom,
            path: ["Inset", "Type Selection Buttons", "Custom Button", "Text"]);

        cgMusicTypeCanvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose,
            path: ["Close Button", "Text"]);

        GameObject cgMusicSoundtrack = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Songs Soundtrack", "Panel");
        cgMusicSoundtrack.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicSoundtrack,
            path: ["Title"]);

        cgMusicSoundtrack.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose,
            path: ["Close Button", "Text"]);

        //CustomMusic
        GameObject cgCustomMusic = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Songs Custom", "Panel");

        cgCustomMusic.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustom,
            path: ["Title"]);

        cgCustomMusic.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.devMuseum.museum_chessSettingsclose,
            path: ["Close Button", "Text"]);

        Button[] aas = cgMusicSoundtrack.GetComponentsInChildren<Button>(true);
        foreach (Button button in aas)
        {
            button.onClick.AddListener(delegate { PatchTerminalFolder(); });
        }

        //Customize theme
        GameObject cgCustomTheme = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Theme Custom", "Panel");
        //"Custom", replace this later
        cgCustomTheme.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesModify,
            path: ["Title"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGrid,
            path: ["Sidebar", "Selector Buttons", "Grid Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGridGlow,
            path: ["Sidebar", "Selector Buttons", "Glow Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomSkybox,
            path: ["Sidebar", "Selector Buttons", "Skybox Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFog,
            path: ["Sidebar", "Selector Buttons", "Fog Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Sidebar", "Back Button","Text"]);

        //Leftside Buttons(Custom Theme)

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsRefresh,
            path: ["Window", "Grid Wrapper","Refresh Button","Text"]);


        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBase,
            path: ["Window", "Grid Type Selection", "Base Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTopRow,
            path: ["Window", "Grid Type Selection", "Top Row Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomTop,
            path: ["Window", "Grid Type Selection", "Top Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomGlowIntensity,
            path: ["Window", "Glow Intensity","Title"]);


        //Patch Color
        //Color moved to Window in 16d Patch
        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogColor,
            path: ["Window", "Fog Control", "Color","Text"]);

        //Patch Sliders Text and "Disable" Description
        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDisableDesc,
            path: ["Window", "Fog Control", "Sliders", "Fog Disabled Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogStart,
            path: ["Window", "Fog Control", "Sliders", "Layout Group", "Start Distance","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogEnd,
            path: ["Window", "Fog Control", "Sliders", "Layout Group", "End Distance","Text"]);

        //Patch Buttons in Tabs. "Disable", "Static", "Dynamic"
        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDisable,
            path: ["Window", "Fog Control", "Tabs", "Disabled Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogStatic,
            path: ["Window", "Fog Control", "Tabs", "Static Button","Text"]);

        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDynamic,
            path: ["Window", "Fog Control", "Tabs", "Dynamic Button","Text"]);

        //"Set to default" button
        cgCustomTheme.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomFogDefault,
            path: ["Window", "Fog Control", "Default Button","Text"]);

        //Patterns
        GameObject cgTerminalPatterns = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Patterns", "Patterns Window", "Panel");

        cgTerminalPatterns.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsTitle,
            path: ["Title"]);

        cgTerminalPatterns.Localize<TextMeshProUGUI>("<color=red>" + LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsWarning + "</color>",
            path: ["Warning Text"]);

        bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
        TextMeshProUGUI cgPatternsSwitchButton = cgTerminalPatterns.transform.Cast<Transform>().FirstOrDefault(t => t.name == "Enable/Disable Button")?.Find("Text")?.GetComponent<TextMeshProUGUI>();
        cgPatternsSwitchButton.Localize(customPatternMode
            ? LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButtonNot
            : LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsSwitchButton);

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Patterns", "Back Button", "Text"]);

        //TextMeshProUGUI cgCustomStateButton = GetTextMeshProUGUI(FindDescendant(FindDescendant(cgTerminalPatterns, "StateButton"), "Text"));
        //bool customPatternMode = MonoSingleton<EndlessGrid>.Instance.customPatternMode;
        //cgCustomStateButton.text = (customPatternMode ? LanguageManager.CurrentLanguage.misc.state_activated : LanguageManager.CurrentLanguage.misc.state_deactivated);
        //it seems broken vanilla rn, so skipping it

        cgTerminalPatterns.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_patternsLaunchExternalEditor,
            path: ["Patterns", "Editor Button", "Text"]);

        //Waves
        GameObject cgTerminalWaves = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Waves", "Waves Window", "Panel");

        cgTerminalWaves.transform.parent.gameObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesTitle,
            path: ["Title"]);

        cgTerminalWaves.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription1,
            path: ["Select Wave Text"]).fontSize = 16;
        cgTerminalWaves.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_wavesDescription2,
            path: ["Wave Requirement Text"]);

        cgTerminalMainPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_themesCustomBack,
            path: ["Waves", "Back Button", "Text"]);
    }

    public async static void PatchTerminalFolder()
    {
        //Changes all folders' own names based on their original name
        GameObject cgMusicSoundtrackAddMenu = GetObject("FirstRoom", "Room", "Cybergrind Shop", "Canvas", "Background", "Main Panel", "Songs Soundtrack", "Panel", "Inset", "Songs");
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
                    case "THE CYBER GRIND": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameCyberGrind); break; }
                    case "PRELUDE": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrelude); break; }
                    case "ACT 1": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct1); break; }
                    case "ACT 2": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct2); break; }
                    case "ACT 3": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameAct3); break; }
                    case "SECRET LEVELS": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameSecret); break; }
                    case "PRIME SANCTUMS": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNamePrime); break; }
                    case "MISCELLANEOUS TRACKS": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameMisc); break; }
                    case "ENCORES": { cgMusicSoundtrackFolderTitle.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicFolderNameEncores); break; }

                    default: {Logging.Warn("Missing CG music folder name: " + cgMusicSoundtrackFolderTitle.text); break; }
                }
            }
            if (child.name == "Song Template(Clone)")
            {
                TextMeshProUGUI cgMusicSoundtrackTask = GetTextMeshProUGUI(FindDescendant(child.gameObject, "Requirement"));
                if (cgMusicSoundtrackTask.text == "Unlocked") cgMusicSoundtrackTask.Localize(LanguageManager.CurrentLanguage.cyberGrind.cybergrind_musicUnlocked);
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
