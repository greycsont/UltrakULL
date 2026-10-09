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

    private static void PatchLevel0_1()
    {
        var hurtScreen = GetObject("Canvas", "HurtScreen");
        hurtScreen.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits1,
            path: ["Text 1 Sound", "Text (1)"]);
        
        hurtScreen.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.prelude.prelude_first_openingCredits2,
            path: ["Text 2 Sound", "Text (2)"]);
    }

    private static void PatchLevel2_1()
    {
        //"Crane control" and "Test Elevators" panels in 2-1
        var stuff = GetObject("3-4 - Outdoors Arenas", "3-4 Stuff");
        
        //"Crane control"
        stuff.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act1.act1_lustFirst_crane,
            path: ["Crane (Moveable)", "Cube (19)", "Cube", "UsableScreen New", "InteractiveScreen", "Canvas", "Background", "Text (TMP) (1)"]);

        //"Test Elevators"
        stuff.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act1.act1_lustFirst_elevator,
            path: ["UsableScreen New", "InteractiveScreen", "Canvas", "Background", "InteractiveScreen Button", "Text (TMP)"]);
    }

    private static void PatchLevel5_3()
    {
        var rotate = GetObject("Rotated");
        rotate.Localize<TMP_Text>(LanguageManager.CurrentLanguage.levelTips.leveltips_wrathThirdBroken, 
            path: ["1 - Hallway", "Shop", "Canvas", "Background", "Main Panel", "Tip of the Day", "Panel", "Text Inset", "TipText"]);
    }

    // ===== Complex level-specific patches (Act 3) =====

    private static void PatchLevel7_2()
    {
        var gateControl1 = GetObject("Other Interiors", "9 - Tram Station", "9 Stuff", "9A", "InteractiveScreenWithStand", "InteractiveScreen", "Canvas", "Background");
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen,
            path: ["A", "Opened", "Text (TMP)"]);
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed,
            path: ["A", "Closed", "Text (TMP)"]);
        
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen,
            path: ["B", "Opened", "Text (TMP)"]);
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed,
            path: ["B", "Closed", "Text (TMP)"]);
        
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen,
            path: ["C", "Opened", "Text (TMP)"]);
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed,
            path: ["C", "Closed", "Text (TMP)"]);
        
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlOpen,
            path: ["D", "Opened", "Text (TMP)"]);
        gateControl1.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceSecond_gateControlClosed,
            path: ["D", "Closed", "Text (TMP)"]);
        
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

    private static void PatchLevel7_3()
    {
        var deathMarkBG = GetObject("Outdoors Areas", "8 - Upper Garden Battlefield", "8 Stuff", "Destructible Tunnel", "InteractiveScreenWithStand", "InteractiveScreen", "Canvas", "Background");
        deathMarkBG.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarked,
            path: ["PreActivation", "Text (TMP) (1)"]);
        
        deathMarkBG.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceThird_becomeMarkedButton,
            path: ["PreActivation", "InteractiveScreenButton", "Text (TMP)"]);
        
        deathMarkBG.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceThird_starOfTheShow,
            path: ["PreActivation", "Text (TMP) (1)"]);
    }

    private static void PatchLevel7_4()
    {
        GetObject("Warning").Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceFourth_floodingWarning,
            path: ["Text (TMP)"]);
        
        GetObject("Countdown").Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_violenceFourth_countdownTitle,
            path: ["Text (TMP)"]);
    }

    private static void PatchLevel8_2()
    {
        var hub = GetObject("4 - Hub");
        hub.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_fraudSecond_errorResetPower,
            path: ["4 Nonstuff", "InteractiveScreen (1)", "Canvas", "Background (Off)", "Text (TMP)"]);
        
        LocalizeOutOfOrder(GetObject("4 - Hub", "4 Nonstuff", "Elevators", "ElevatorSet"));
        LocalizeOutOfOrder(GetObject("4 - Hub", "4 Nonstuff", "Elevators", "ElevatorSet (1)"));
        void LocalizeOutOfOrder(GameObject elevator)
        {
            var allTexts = elevator.GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (var text in allTexts)
            {
                text.Localize(LanguageManager.CurrentLanguage.act3.act3_fraudSecond_outOfOrder);
            }
        }
    }

    private static void PatchLevel8_3()
    {
        var office = GetObject("Pre-Space", "Rooms", "10B - Night Street", "10B Nonstuff", "Office");
        office.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_fraudSecond_outOfOrder,
            path: ["ElevatorSet (1)", "ElevatorStop", "InteractiveScreen", "Canvas", "Background", "Text (TMP)"]);
        
        office.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_fraudSecond_outOfOrder,
            path: ["ElevatorSet (1)", "ElevatorStop (1)", "InteractiveScreen", "Canvas", "Background", "Text (TMP)"]);
    }

    private static void PatchLevel8_4()
    {
        var canvas = GetObject("Canvas");
        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_fraudFourth_heightMarkerTitle,
            path: ["HeightMarkerParent", "HeightMarker", "Title"]);

        var intro = GetObject("Intro");
        intro.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.act3.act3_fraudFourth_nope,
            path: ["3 - Upper Intro", "ElevatorSet", "Elevator", "InteractiveScreen", "Canvas", "Background", "1 (Nope)", "Text (TMP)"]);
    }

    private static void PatchLevel0_E()
    {
        var canvas = GetObject("Canvas");
        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceWarn, 
            path: ["HurtScreen", "Heat Resistance", "Warning"]).enableWordWrapping = false;

        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceText, 
            path: ["HurtScreen", "Heat Resistance", "Flavor Text"]);

        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceTitle, 
            path: ["HurtScreen", "Heat Resistance", "Meter", "Label"]);

        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceRepaired, 
            path: ["HurtScreen", "Heat Fixed", "Warning"]).enableWordWrapping = false;

        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceRepairedText, 
            path: ["HurtScreen", "Heat Fixed", "Flavor Text"]);

        canvas.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encorePrelude_heatResistanceTitle, 
            path: ["HurtScreen", "Heat Fixed", "Meter", "Label"]);
    }

    private static void PatchLevel1_E()
    {
        GetObject("11 - Skull Room").Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.encore.encoreLimbo_warningText,
            path: ["11 Nonstuff", "Room", "Cube (24)", "Canvas", "Text (TMP)"]);
    }
}
