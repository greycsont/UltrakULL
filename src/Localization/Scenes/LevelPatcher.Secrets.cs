using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;
using static UltrakULL.json.LanguageManager;
using UnityEngine.Video;

namespace UltrakULL;

public static partial class LevelPatcher
{
    private static void PatchLevel0_S()
    {
        var testamentTerminal = GetObject("FinalRoom SecretExit", "Room", "Testament Shop (1)");
        var testamentText = CurrentLanguage.secretLevels.secretLevels_prelude_testamentTitle
                         + "\n\n" +
                         CurrentLanguage.secretLevels.secretLevels_prelude_testament1
                         + "\n\n" +
                         CurrentLanguage.secretLevels.secretLevels_prelude_testament2
                         + "\n\n" +
                         CurrentLanguage.secretLevels.secretLevels_prelude_testament3
                         + "\n\n" +
                         CurrentLanguage.secretLevels.secretLevels_prelude_testament4;
        
        testamentTerminal.Localize<TextMeshProUGUI>(testamentText,
            path: ["Canvas", "Text (TMP)"]);
    }

    private static void PatchLevel1_S()
    {
        var testamentTerminal = GetObject("5 - Finale", "FinalRoomSecretExit", "Room", "Testament Shop (1)");
        var testamentText = 
            CurrentLanguage.secretLevels.secretLevels_first_testamentTitle
            + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_first_testament1
            + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_first_testament2
            + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_first_testament3
            + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_first_testament4;
        
        testamentTerminal.Localize<TextMeshProUGUI>(testamentText,
            path: ["Canvas", "Text (TMP)"]);
    }

    private static void PatchLevel4_S()
    {
        var testamentTerminal = GetObject("4 - Boulder Run", "4 Stuff(Clone)", "FinalRoom SecretExit", "Room", "Testament Shop (1)");
        var testamentText = 
            CurrentLanguage.secretLevels.secretLevels_fourth_testamentTitle + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament1 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament2 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament3 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament4 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament5 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament6 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fourth_testament7;
        
        testamentTerminal.Localize<TextMeshProUGUI>(testamentText,
            path:  ["Canvas", "Text (TMP)"]);
    }
    private static void PatchLevel5_S()
    {
        var powerGauge = GetObject("FishingCanvas", "Power Meter");
        
        powerGauge.Localize<TextMeshProUGUI>(CurrentLanguage.fishing.fish_rodFar,
            path: ["Text (TMP)"]);
        
        powerGauge.Localize<TextMeshProUGUI>(CurrentLanguage.fishing.fish_rodClose,
            path: ["Text (TMP) (1)"]);

        // Localize buttons in Balancing Minigame
        var balancingMinigame = GetObject("FinishCanvas", "Struggle Mini Game", "Balancing Minigame");
        
        balancingMinigame.Localize<TextMeshProUGUI>(CurrentLanguage.inputStrings.input_RMB,
            path: ["Text (TMP)"]);

        balancingMinigame.Localize<TextMeshProUGUI>(CurrentLanguage.inputStrings.input_LMB,
            path: ["Text (TMP) (1)"]);
        
        // Leaderboard title
        var fishingLeaderboard = GetObject("Exit Lobby Interior", "Fish Scores", "Canvas", "Border", "TipBox", "Panel");

        fishingLeaderboard.Localize<TextMeshProUGUI>(CurrentLanguage.fishing.fish_leaderboard,
            path: ["Title"]);

        var fishingTerminal = GetObject("Fishing Enc Terminal", "Canvas", "Background", "Main Window");

        fishingTerminal.Localize<TextMeshProUGUI>(CurrentLanguage.fishing.fish_terminalTitle,
            path: ["Title"]);

        fishingTerminal.Localize<TextMeshProUGUI>(CurrentLanguage.shop.shop_back,
            path: ["Fish Info", "Window", "Back Button"]);

        FindComponent<VideoPlayer>(GetObject("Exit Lobby Interior", "Table top", "TV", "Screen")).ReplaceUrl();

        var testamentTerminal = GetObject("FinalRoom SecretExit", "Room", "Testament Shop (1)", "Canvas", "Text (TMP)");
        var testamentText = 
            CurrentLanguage.secretLevels.secretLevels_fifth_testamentTitle + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament1 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament2 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament3 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament4 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament5 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament6 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament7 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament8 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament9 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament10 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament11 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_fifth_testament12;

        testamentTerminal.Localize<TextMeshProUGUI>(testamentText,
            path: ["Canvas", "Text (TMP)"]);
    }

    private static void PatchLevel7_S()
    {
        var washingCanvas = GetObject("WashingCanvas");
        washingCanvas.Localize<TextMeshProUGUI>(CurrentLanguage.washing.wash_bloodClean,
            path: ["Painter Completion Meter", "Slider Group", "Blood Cleaned"]);

        washingCanvas.Localize<TextMeshProUGUI>(CurrentLanguage.washing.wash_littercount,
            path: ["CheckList", "Litter", "Litter Count:"]);
        
        var fakeexitCanvas = GetObject("Fake Exit", "PuzzleScreen", "Canvas");
        
        var promptText = "<size=12><color=#7f0000><u><b>" + CurrentLanguage.washing.wash_fakeexittext1 + "</u></b></color></size>\n\n"
                         + CurrentLanguage.washing.wash_fakeexittext2 + "\n"
                         + CurrentLanguage.washing.wash_fakeexittext3 + "\n"
                         + CurrentLanguage.washing.wash_fakeexittext4 + "\n"
                         + CurrentLanguage.washing.wash_fakeexittext5 + "\n"
                         + CurrentLanguage.washing.wash_fakeexittext6;
        
        var thankYouText = "<size=12><color=#7f0000><u><b>" + CurrentLanguage.washing.wash_exitOpenText1 + "</u></b></color></size>\n\n"
                           + CurrentLanguage.washing.wash_exitOpenText2 + "\n\n"
                           + CurrentLanguage.washing.wash_exitOpenText3;
        
        fakeexitCanvas.Localize<TextMeshProUGUI>(promptText,
            path: ["Cleaning Prompt Text"]);

        fakeexitCanvas.Localize<TextMeshProUGUI>(thankYouText,
            path: ["Thank You Text"]);

        var testamentTerminal = GetObject("FinalRoom SecretExit", "Room", "Testament Shop (1)");
        var testamentText = 
            CurrentLanguage.secretLevels.secretLevels_seventh_testamentTitle + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament1 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament2 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament3 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament4 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament5 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament6 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament7 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament8 + "\n\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament9 + "\n" +
            CurrentLanguage.secretLevels.secretLevels_seventh_testament10;

        testamentTerminal.Localize<TextMeshProUGUI>(testamentText,
            path: ["Canvas", "Text (TMP)"]);
    }
}
