using System;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class LevelPatcher
{
    // ===== Secret levels =====

    private static void PatchSecret(string levelName, GameObject canvasObj)
    {
        GameObject testamentRoom;
        switch (levelName)
        {
            case "Level 0-S": testamentRoom = GameObject.Find("FinalRoom SecretExit"); PatchTestament(testamentRoom); break;
            case "Level 1-S": testamentRoom = GameObject.Find("5 - Finale"); PatchTestament(testamentRoom); break;
            case "Level 2-S": Act1Vn.PatchPrompts(canvasObj); break;
            case "Level 4-S": testamentRoom = GetInactiveRootObject("4 - Boulder Run"); PatchTestament(testamentRoom); break;
            case "Level 5-S": testamentRoom = GetInactiveRootObject("FinalRoom SecretExit"); PatchTestament(testamentRoom); Patch5S(canvasObj); break;
            case "Level 7-S": testamentRoom = GetInactiveRootObject("FinalRoom SecretExit"); PatchTestament(testamentRoom); Patch7S(canvasObj); break;
        }

        GameObject player = GetInactiveRootObject("Player");
        GameObject secretLevelResults = FindDescendant(player, "Main Camera", "HUD Camera", "HUD", "FinishCanvas");
        GameObject secretLevelResultsPanel = secretLevelResults.transform.GetChild(2).gameObject;

        TextMeshProUGUI secretLevelResultsName = GetTextMeshProUGUI(FindDescendant(secretLevelResultsPanel, "Title", "Text"));
        secretLevelResultsName.text = GetSecretLevelName(levelName);

        TextMeshProUGUI secretLevelResultsInfo = GetTextMeshProUGUI(FindDescendant(secretLevelResultsPanel, "Time - Info", "Text"));
        secretLevelResultsInfo.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete1;

        TextMeshProUGUI secretLevelComplete = GetTextMeshProUGUI(FindDescendant(secretLevelResultsPanel, "Time - Rank", "Text"));
        secretLevelComplete.text = LanguageManager.CurrentLanguage.secretLevels.secretLevels_complete2;
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

    private static void Patch5S(GameObject canvasObj)
    {
        GameObject powerGauge = FindDescendant(GetInactiveRootObject("FishingCanvas"), "Power Meter");
        TextMeshProUGUI distanceFar = GetTextMeshProUGUI(FindDescendant(powerGauge, "Text (TMP)"));
        distanceFar.text = LanguageManager.CurrentLanguage.fishing.fish_rodFar;
        TextMeshProUGUI distanceClose = GetTextMeshProUGUI(FindDescendant(powerGauge, "Text (TMP) (1)"));
        distanceClose.text = LanguageManager.CurrentLanguage.fishing.fish_rodClose;

        //Localize buttons in Balancing Minigame
        GameObject balancingMinigame = FindDescendant(GetInactiveRootObject("FishingCanvas"), "Struggle Mini Game", "Balancing Minigame");
        TextMeshProUGUI RMB = GetTextMeshProUGUI(FindDescendant(balancingMinigame, "Text (TMP)"));
        RMB.text = GetAbbreviation(LanguageManager.CurrentLanguage.inputStrings.input_RMB);
        TextMeshProUGUI LMB = GetTextMeshProUGUI(FindDescendant(balancingMinigame, "Text (TMP) (1)"));
        LMB.text = GetAbbreviation(LanguageManager.CurrentLanguage.inputStrings.input_LMB);

        GameObject fishingLeaderboard = FindDescendant(GetInactiveRootObject("Exit Lobby Interior"), "Fish Scores", "Canvas", "Border", "TipBox", "Panel");
        TextMeshProUGUI fishingLeaderboardTitle = GetTextMeshProUGUI(FindDescendant(fishingLeaderboard, "Title"));
        fishingLeaderboardTitle.text = LanguageManager.CurrentLanguage.fishing.fish_leaderboard;

        GameObject fishingTerminal = FindDescendant(GetInactiveRootObject("Fishing Enc Terminal"), "Canvas", "Background", "Main Window");
        TextMeshProUGUI fishingTerminalTitle = GetTextMeshProUGUI(FindDescendant(fishingTerminal, "Title"));
        fishingTerminalTitle.text = LanguageManager.CurrentLanguage.fishing.fish_terminalTitle;
        GameObject fishingTerminalBackButton = FindDescendant(fishingTerminal, "Fish Info", "Window", "Back Button");
        TextMeshProUGUI fishingTerminalBackButtonText = GetTextMeshProUGUI(FindDescendant(fishingTerminalBackButton, "Text"));
        fishingTerminalBackButtonText.text = LanguageManager.CurrentLanguage.shop.shop_back;
    }

    private static void Patch7S(GameObject canvasObj)
    {
        try
        {
            //BloodCleanText
            GameObject washcanvas = GameObject.Find("WashingCanvas");
            TextMeshProUGUI BloodCleanText = GetTextMeshProUGUI(FindDescendant(washcanvas, "Painter Completion Meter", "Slider Group", "Blood Cleaned"));
            BloodCleanText.text = LanguageManager.CurrentLanguage.washing.wash_bloodClean;
            GameObject chklst = FindDescendant(washcanvas, "CheckList");

            TextMeshProUGUI LitterCount = GetTextMeshProUGUI(FindDescendant(chklst, "Litter", "Litter Count:"));
            LitterCount.text = LanguageManager.CurrentLanguage.washing.wash_littercount;

            //Faxeexittext
            GameObject fakeexitCanvas = FindDescendant(GetInactiveRootObject("Fake Exit"), "PuzzleScreen", "Canvas");
            TextMeshProUGUI fakeexittext = GetTextMeshProUGUI(FindDescendant(fakeexitCanvas, "Cleaning Prompt Text"));
            fakeexittext.text = "<size=12><color=#7f0000><u><b>" + LanguageManager.CurrentLanguage.washing.wash_fakeexittext1 + "</u></b></color></size>\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext2 + "\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext3 + "\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext4 + "\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext5 + "\n"
            + LanguageManager.CurrentLanguage.washing.wash_fakeexittext6;

            TextMeshProUGUI thxtext = GetTextMeshProUGUI(FindDescendant(fakeexitCanvas, "Thank You Text"));
            thxtext.text = "<size=12><color=#7f0000><u><b>" + LanguageManager.CurrentLanguage.washing.wash_exitOpenText1 + "</u></b></color></size>\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_exitOpenText2 + "\n\n"
            + LanguageManager.CurrentLanguage.washing.wash_exitOpenText3;
        }
        catch (Exception e)
        {
            Logging.Warn("Failed to Patch 7-S");
            if (LanguageManager.CurrentLanguage.washing == null)
            { Logging.Warn("Category is missing from the language file! Please Update the language file!"); return; }
            Logging.Warn(e.ToString());
        }
    }

    private static string GetSecretLevelName(string currentLevel)
    {
        switch (currentLevel)
        {
            case ("Level 0-S"): { return "0-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_preludeSecret; }
            case ("Level 1-S"): { return "1-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_limboSecret; }
            case ("Level 2-S"): { return "2-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_lustSecret; }
            case ("Level 4-S"): { return "4-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_greedSecret; }
            case ("Level 5-S"): { return "5-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_wrathSecret; }
            case ("Level 7-S"): { return "7-S: " + LanguageManager.CurrentLanguage.levelNames.levelName_violenceSecret; }
            default: { return "UNKNOWN"; }
        }
    }

    private static string GetAbbreviation(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string[] words = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        StringBuilder abbreviation = new StringBuilder();

        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word) && word.Length > 0)
            {
                abbreviation.Append(char.ToUpper(word[0]));
            }
        }

        return abbreviation.ToString();
    }
}
