using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class LevelPatcher
{
    // ===== Level-specific patches =====

    private static void PatchLevel0_1(GameObject canvasObj)
    {
        try
        {
            GameObject openingCredsParent = FindDescendant(canvasObj, "HurtScreen");

            TextMeshProUGUI openingCredsFirst = GetTextMeshProUGUI(FindDescendant(openingCredsParent, "Text 1 Sound", "Text (1)"));
            openingCredsFirst.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits1;

            TextMeshProUGUI openingCredsSecond = GetTextMeshProUGUI(FindDescendant(openingCredsParent, "Text 2 Sound", "Text (2)"));
            openingCredsSecond.text = LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits2;
        }
        catch (Exception e)
        {
            Logging.Warn("Failed to patch opening credits in 0-1");
            Logging.Warn(e.ToString());
        }
    }

    private static void PatchLevel2_1(GameObject canvasObj)
    {
        //"Crane control" and "Test Elevators" panels in 2-1
        GameObject outdoorsArenas = GetInactiveRootObject("3-4 - Outdoors Arenas");
        GameObject stuff = FindDescendant(outdoorsArenas, "3-4 Stuff");
        Transform stuffTransform = stuff.transform;
        //"Crane control"
        GameObject crane = stuffTransform.Find("Crane (Moveable)").gameObject;
        GameObject secretScreen = FindDescendant(crane, "Cube (19)", "Cube", "UsableScreen New", "InteractiveScreen", "Canvas", "Background");

        TextMeshProUGUI craneControl = GetTextMeshProUGUI(FindDescendant(secretScreen, "Text (TMP) (1)"));
        craneControl.text = LanguageManager.CurrentLanguage.act1.act1_lustFirst_crane;

        //"Test Elevators"
        GameObject elevator = stuffTransform.Find("UsableScreen New").gameObject;
        GameObject elevatorScreen = FindDescendant(elevator, "InteractiveScreen", "Canvas", "Background", "InteractiveScreen Button");
        TextMeshProUGUI elevatorButton = GetTextMeshProUGUI(FindDescendant(elevatorScreen, "Text (TMP)"));
        elevatorButton.text = LanguageManager.CurrentLanguage.act1.act1_lustFirst_elevator;
    }

    // ===== Complex level-specific patches (Act 3) =====

    private static void PatchLevel7_2(GameObject canvasObj)
    {
        GameObject gameObjectChild = FindDescendant(GetInactiveRootObject("Other Interiors"), "9 - Tram Station", "9 Stuff", "9A", "InteractiveScreenWithStand", "InteractiveScreen", "Canvas", "Background");
        TextMeshProUGUI textMeshProUGUI = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "A", "Opened", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI2 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "A", "Closed", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI3 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "B", "Opened", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI4 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "B", "Closed", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI5 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "C", "Opened", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI6 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "C", "Closed", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI7 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "D", "Opened", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI8 = GetTextMeshProUGUI(FindDescendant(gameObjectChild, "D", "Closed", "Text (TMP)"));
        textMeshProUGUI.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
        textMeshProUGUI2.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
        textMeshProUGUI3.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
        textMeshProUGUI4.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
        textMeshProUGUI5.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
        textMeshProUGUI6.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
        textMeshProUGUI7.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen;
        textMeshProUGUI8.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed;
        GameObject gameObjectChild2 = FindDescendant(GetInactiveRootObject("Outdoors"), "10 - Ambush Station", "10 Nonstuff", "InteractiveScreenWithStand", "InteractiveScreen", "Canvas", "Background");
        TextMeshProUGUI textMeshProUGUI9 = GetTextMeshProUGUI(FindDescendant(gameObjectChild2, "Text (TMP) (1)"));
        TextMeshProUGUI textMeshProUGUI10 = GetTextMeshProUGUI(FindDescendant(gameObjectChild2, "Button (Open)", "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI11 = GetTextMeshProUGUI(FindDescendant(gameObjectChild2, "Button (Closed)", "Text (TMP)"));
        textMeshProUGUI9.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_cartGateControlTitle;
        textMeshProUGUI10.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_cartGateControlOpen;
        textMeshProUGUI11.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_cartGateControlClosed;
        GameObject gameObjectChild3 = FindDescendant(GetInactiveRootObject("Outdoors"), "11 - Bomb Station", "11 Nonstuff", "Bomb Mechanisms", "InteractiveScreenWithStand", "InteractiveScreen", "Canvas");
        TextMeshProUGUI textMeshProUGUI12 = GetTextMeshProUGUI(FindDescendant(gameObjectChild3, "Text (TMP)"));
        TextMeshProUGUI[] componentsInChildren = FindDescendant(gameObjectChild3, "UsableButtons").GetComponentsInChildren<TextMeshProUGUI>(true);
        TextMeshProUGUI textMeshProUGUI13 = GetTextMeshProUGUI(FindDescendant(FindDescendant(gameObjectChild3, "UsableButtons"), "Error"));
        TextMeshProUGUI textMeshProUGUI14 = GetTextMeshProUGUI(FindDescendant(gameObjectChild3, "Done"));
        textMeshProUGUI12.text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlTitle;
        TextMeshProUGUI[] array = componentsInChildren;
        foreach (TextMeshProUGUI val in array)
        {
            if (((TMP_Text)val).text.Contains("LOWER"))
            {
                ((TMP_Text)val).text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlLower;
            }
        }
        ((TMP_Text)textMeshProUGUI13).text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlError1 + "<size=12>\n" + LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlError2;
        ((TMP_Text)textMeshProUGUI14).text = LanguageManager.CurrentLanguage.act3.act3_violenceSecond_payloadControlHell;
    }

    private static void PatchLevel7_3(GameObject canvasObj)
    {
        GameObject gameObjectChild4 = FindDescendant(GetInactiveRootObject("Outdoors Areas"), "8 - Upper Garden Battlefield", "8 Stuff", "Destructible Tunnel", "InteractiveScreenWithStand", "InteractiveScreen", "Canvas", "Background");
        TextMeshProUGUI textMeshProUGUI15 = GetTextMeshProUGUI(FindDescendant(FindDescendant(gameObjectChild4, "PreActivation"), "Text (TMP) (1)"));
        TextMeshProUGUI textMeshProUGUI16 = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(gameObjectChild4, "PreActivation"), "InteractiveScreenButton"), "Text (TMP)"));
        TextMeshProUGUI textMeshProUGUI17 = GetTextMeshProUGUI(FindDescendant(FindDescendant(gameObjectChild4, "PostActivation"), "Text (TMP) (1)"));
        textMeshProUGUI15.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarked;
        textMeshProUGUI16.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarkedButton;
        textMeshProUGUI17.text = LanguageManager.CurrentLanguage.act3.act3_violenceThird_starOfTheShow;
    }

    private static void PatchLevel7_4(GameObject canvasObj)
    {
        GetTextMeshProUGUI(FindDescendant(canvasObj, "Warning", "Text (TMP)")).text = LanguageManager.CurrentLanguage.act3.act3_violenceFourth_floodingWarning;
        GetTextMeshProUGUI(FindDescendant(canvasObj, "Countdown", "Text (TMP)")).text = LanguageManager.CurrentLanguage.act3.act3_violenceFourth_countdownTitle;
    }

    private static void PatchLevel8_2(GameObject canvasObj)
    {
        GameObject hub = GetInactiveRootObject("4 - Hub");
        if (hub == null)
        {
            hub = GetInactiveRootObject("Hub");
        }
        if (hub != null)
        {
            TextMeshProUGUI[] allTexts = hub.GetComponentsInChildren<TextMeshProUGUI>(true);
            string outOfOrderTranslation = LanguageManager.CurrentLanguage.act3.act3_fraudSecond_outOfOrder;
            string errorResetTranslation = LanguageManager.CurrentLanguage.act3.act3_fraudSecond_errorResetPower;
            bool outOfOrderMissing = string.IsNullOrEmpty(outOfOrderTranslation);
            bool errorResetMissing = string.IsNullOrEmpty(errorResetTranslation);
            if (outOfOrderMissing)
            {
                Logging.Warn("[Act3] Translation for 'act3_fraudSecond_outOfOrder' is missing or empty. Will keep original text.");
            }
            if (errorResetMissing)
            {
                Logging.Warn("[Act3] Translation for 'act3_fraudSecond_errorResetPower' is missing or empty. Will keep original text.");
            }
            foreach (TextMeshProUGUI text in allTexts)
            {
                string original = text.text;
                string noTags = Regex.Replace(original, "<.*?>", "");
                string normalized = Regex.Replace(noTags, @"\s+", " ").Trim().ToUpperInvariant();
                if (normalized == "OUT OF ORDER" && !outOfOrderMissing)
                {
                    text.text = outOfOrderTranslation;
                }
                else if (normalized == "ERROR RESET POWER TO OPEN" && !errorResetMissing)
                {
                    text.text = errorResetTranslation;
                }
            }
        }
        else
        {
            Logging.Warn("[Act3] Hub not found");
        }
    }

    private static void PatchLevel8_3(GameObject canvasObj)
    {
        string outOfOrder = LanguageManager.CurrentLanguage.act3.act3_fraudSecond_outOfOrder;
        if (string.IsNullOrEmpty(outOfOrder))
            return;

        foreach (string path in new[]
        {
            "Pre-Space/Rooms/10B - Night Street/10B Nonstuff/Office/ElevatorSet (1)/ElevatorStop/InteractiveScreen/Canvas/Background/Text (TMP)",
            "Pre-Space/Rooms/10B - Night Street/10B Nonstuff/Office/ElevatorSet (1)/ElevatorStop (1)/InteractiveScreen/Canvas/Background/Text (TMP)"
        })
            if (GetObject(path)?.GetComponent<TextMeshProUGUI>() is { } text)
                text.text = outOfOrder;
    }

    private static void PatchLevel8_4(GameObject canvasObj)
    {
        TextMeshProUGUI textMeshProUGUI18 = GetTextMeshProUGUI(FindDescendant(canvasObj, "HeightMarkerParent", "HeightMarker", "Title"));
        string act3_fraudFourth_heightMarkerTitle = LanguageManager.CurrentLanguage.act3.act3_fraudFourth_heightMarkerTitle;
        ((TMP_Text)textMeshProUGUI18).text = StringHelper.MakeVertical(act3_fraudFourth_heightMarkerTitle);
        ((TMP_Text)textMeshProUGUI18).ForceMeshUpdate(false, false);

        // Patch "N O P E" text
        string nopeTranslation = LanguageManager.CurrentLanguage.act3.act3_fraudFourth_nope;
        var nopeText = FindComponent<TextMeshProUGUI>(GetInactiveRootObject("The Intro"),
            "3 - Upper Intro", "ElevatorSet", "Elevator", "InteractiveScreen", "Canvas", "Background", "1 (Nope)", "Text (TMP)");
        if (nopeText != null && !string.IsNullOrEmpty(nopeTranslation))
            nopeText.text = nopeTranslation;
    }
}
