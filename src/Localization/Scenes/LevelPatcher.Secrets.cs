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
    // ===== Secret levels =====

    private static void PatchSecret(string levelName, GameObject canvasObj)
    {
        GameObject testamentRoom;
        switch (levelName)
        {
            case "Level 0-S":
                testamentRoom = GameObject.Find("FinalRoom SecretExit");
                PatchTestament(testamentRoom);
                break;
            case "Level 1-S":
                testamentRoom = GameObject.Find("5 - Finale");
                PatchTestament(testamentRoom);
                break;
            case "Level 2-S": Act1Vn.PatchPrompts(canvasObj); break;
            case "Level 4-S":
                testamentRoom = GetInactiveRootObject("4 - Boulder Run");
                PatchTestament(testamentRoom);
                break;
            case "Level 5-S":
                testamentRoom = GetInactiveRootObject("FinalRoom SecretExit");
                PatchTestament(testamentRoom);
                PatchLevel5_S(canvasObj);
                break;
            case "Level 7-S":
                testamentRoom = GetInactiveRootObject("FinalRoom SecretExit");
                PatchTestament(testamentRoom);
                PatchLevel7_S(canvasObj);
                break;
        }
    }

    private static void PatchTestament(GameObject testamentRoom)
    {
        TextMeshProUGUI testamentPanelText = null;
        TextMeshProUGUI testamentPanelText4S1 = null;
        TextMeshProUGUI testamentPanelText4S2 = null;
        //TextMeshProUGUI testamentPanelTitle = null;

        //0-S
        if (GetCurrentSceneName() == "Level 0-S")
        {
            testamentPanelText = GetTextMeshProUGUI(FindDescendant(testamentRoom, "Room", "Testament Shop (1)", "Canvas", "Text (TMP)"));
        }
        //1-S
        else if (GetCurrentSceneName() == "Level 1-S")
        {
            GameObject finalRoom = FindDescendant(testamentRoom, "FinalRoomSecretExit");
            testamentPanelText = GetTextMeshProUGUI(FindDescendant(finalRoom, "Room", "Testament Shop (1)", "Canvas", "Text (TMP)"));
        }
        //4-S
        else if (GetCurrentSceneName() == "Level 4-S")
        {
            Transform[] allChildren = testamentRoom.GetComponentsInChildren<Transform>(true);
            List<GameObject> stuff = new List<GameObject>();
            int errorCount = 0;
            foreach (Transform child in allChildren)
            {
                if (child.name.Contains("4 Stuff"))
                {
                    stuff.Add(child.gameObject);
                }
            }
            foreach (GameObject stuffObject in stuff)
            {
                if ((testamentPanelText4S1 == null) & (errorCount == 0))
                {
                    try
                    {
                        testamentPanelText4S1 = GetTextMeshProUGUI(
                            FindDescendant(stuffObject,
                            "FinalRoom SecretExit",
                            "Room",
                            "Testament Shop (1)",
                            "Canvas",
                            "Text (TMP)"));
                    }
                    catch (Exception ex)
                    {
                        Logging.Warn("An error occurred during the search for the first object");
                        errorCount++;
                    }
                }
                else if ((testamentPanelText4S2 == null) & (errorCount < 2))
                {
                    try
                    {
                        testamentPanelText4S2 = GetTextMeshProUGUI(
                            FindDescendant(stuffObject, "FinalRoom SecretExit",
                            "Room",
                            "Testament Shop (1)",
                            "Canvas",
                            "Text (TMP)"));
                    }
                    catch (Exception ex)
                    {
                        Logging.Warn("An error occurred while searching for the second object");
                        errorCount++;
                    }
                }

                if (errorCount >= 2)
                {
                    Logging.Error("The number of attempts to find the Text (TMP) object has been exhausted");
                }
            }
        }
        //5-S
        else if (GetCurrentSceneName() == "Level 5-S")
        {
            testamentPanelText = GetTextMeshProUGUI(FindDescendant(testamentRoom, "Room", "Testament Shop (1)", "Canvas", "Text (TMP)"));
        }
        else if (GetCurrentSceneName() == "Level 7-S")
        {
            testamentPanelText = GetTextMeshProUGUI(FindDescendant(testamentRoom, "Room", "Testament Shop (1)", "Canvas", "Text (TMP)"));
        }

        switch (GetCurrentSceneName())
        {
            case "Level 0-S":
                {
                    testamentPanelText.text =
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testamentTitle
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament1
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament2
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament3
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_prelude_testament4;
                    break;
                }
            case "Level 1-S":
                {
                    testamentPanelText.text =
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testamentTitle
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament1
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament2
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament3
                        + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_first_testament4;
                    break;
                }
            case "Level 4-S":
                {
                    if (!(testamentPanelText4S1 == null))
                    {
                        testamentPanelText4S1.text =
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testamentTitle + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament1 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament2 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament3 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament4 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament5 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament6 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament7;
                    }
                    if (!(testamentPanelText4S2 == null))
                    {
                        testamentPanelText4S2.text =
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testamentTitle + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament1 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament2 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament3 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament4 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament5 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament6 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fourth_testament7;
                    }
                    break;
                }
            case "Level 5-S":
                {
                    testamentPanelText.text =
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testamentTitle + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament1 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament2 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament3 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament4 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament5 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament6 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament7 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament8 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament9 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament10 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament11 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_fifth_testament12;
                    break;
                }
            case "Level 7-S":
                {
                    testamentPanelText.text =
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testamentTitle + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament1 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament2 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament3 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament4 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament5 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament6 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament7 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament8 + "\n\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament9 + "\n" +
                        LanguageManager.CurrentLanguage.secretLevels.secretLevels_seventh_testament10;
                    break;
                }
        }
    }

    private static void PatchLevel5_S(GameObject canvasObj)
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
    }

    private static void PatchLevel7_S(GameObject canvasObj)
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
    }
}
