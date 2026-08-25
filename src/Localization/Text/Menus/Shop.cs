using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class Shop
{
    private static void PatchShopFrontEnd(GameObject shopObject)
    {
        GameObject shopPanel = FindDescendant(shopObject, "Background", "Main Panel");

        //Tip panel
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_tipofthedayTitle, path: ["Tip of the Day", "Title"]);

        // Tip text: feed its current value to GetLevelTip (unless it's a V-Rank tip).
        TextMeshProUGUI tipDescription = GetTextMeshProUGUI(FindDescendant(shopPanel, "Tip of the Day", "Panel", "Text Inset", "TipText"));
        if (tipDescription.text.Contains("V-Rank"))
            tipDescription.text = tipDescription.text;
        else
            tipDescription.text = StringsParent.GetLevelTip(tipDescription.text);

        //--MENU--
        // removed and replaced with SmileOS 2.0 in patch 16
        //TextMeshProUGUI menuText = GetTextMeshProUGUI(FindDescendant(shopObject, "Menu Title"));
        //menuText.text = "--" + LanguageManager.CurrentLanguage.shop.shop_menu + "--";

        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weapons, path: ["Main Menu", "Buttons", "WeaponsButton", "Text"]);

        //Enemies button
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_monsters, path: ["Main Menu", "Buttons", "EnemiesButton", "Text"]);

        //CG buttons
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_cybergrind, path: ["Main Menu", "Buttons", "CyberGrindButton", "Text"]);

        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_returnToMission, path: ["Main Menu", "Buttons", "ReturnButton", "Text"]);

        //Sandbox button
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_sandbox, path: ["Main Menu", "Buttons", "SandboxButton", "Text"]);

        //Enemies title
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_monsters, path: ["Enemies", "Enemies Panel", "Title"]);

        //Sandbox enter description
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_sandbox, path: ["Sandbox", "Sandbox Panel", "Title"]);

        shopPanel.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_sandboxDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_sandboxDescription2,
            path: ["Sandbox", "Sandbox Panel", "Panel", "Text Inset", "Text"]);

        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_sandboxEnter, path: ["Sandbox", "Sandbox Panel", "Panel", "Enter Button", "Text"]);

        //CG enter description
        shopPanel.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription2 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_cybergrindDescription3,
            path: ["The Cyber Grind", "Cyber Grind Panel", "Panel", "Text Inset", "Text"]);

        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_cybergrindEnter, path: ["The Cyber Grind", "Cyber Grind Panel", "Panel", "Enter Button", "Text"]);

        //CG exit description
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_cybergrindExitTitle, path: ["Return from Cyber Grind", "Return from Cyber Grind Panel", "Title"]);

        shopPanel.Localize<TextMeshProUGUI>(
            GetCurrentSceneName() == "uk_construct"
                ? LanguageManager.CurrentLanguage.frontend.mainmenu_quit
                : LanguageManager.CurrentLanguage.shop.shop_cybergrindExit,
            path: ["Return from Cyber Grind", "Return from Cyber Grind Panel", "Panel", "Exit Button", "Text"]);

        //Enemies back button
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Enemies", "Back Button", "Text"]);

        //EnemyInfo back button
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Enemies", "Info Screen", "Main Window", "Back Button", "Text"]);

        //Sandbox back button
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Sandbox", "Back Button", "Text"]);

        //Enter CG back text
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["The Cyber Grind", "Back Button", "Text"]);

        //Exit CG back text
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Return from Cyber Grind", "Back Button", "Text"]);

    }
    

    private static void PatchWeapons(GameObject shopObject)
    {
        try
        {
            GameObject shopPanel = FindDescendant(shopObject, "Background", "Main Panel");

            float addWidth = 110f;
            //weapons
            GameObject shopWeaponsObject  = FindDescendant(shopPanel, "Weapons");
            
            GameObject shopWeaponsButtonsObject = FindDescendant(shopPanel, "Weapons", "Weapons Panel", "Buttons");
            
            TextMeshProUGUI weaponTitleText = GetTextMeshProUGUI(FindDescendant(shopWeaponsObject, "Weapons Panel", "Menu Title"));
            weaponTitleText.text = LanguageManager.CurrentLanguage.shop.shop_weapons;
            
            TextMeshProUGUI weaponBackText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "BackButton", "Text"));
            weaponBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("maranara_project_prophet") ||
                BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("plonk.straymode"))
                return;


            TextMeshProUGUI weaponRevolverText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "RevolverButton", "Text"));
            weaponRevolverText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;
            
            TextMeshProUGUI weaponShotgunText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "ShotgunButton", "Text"));
            weaponShotgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;
            
            TextMeshProUGUI weaponNailgunText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "NailgunButton", "Text"));
            weaponNailgunText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

            //Slight problem - not all the text fits in the box.
            //The longer text is, the more we'll need to reduce the font size to compensate.
            TextMeshProUGUI weaponRailcannonText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "RailcannonButton", "Text"));
            weaponRailcannonText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

            TextMeshProUGUI rocketLauncherText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "RocketLauncherButton", "Text"));
            rocketLauncherText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

            TextMeshProUGUI weaponArmText = GetTextMeshProUGUI(FindDescendant(shopWeaponsButtonsObject, "ArmButton", "Text"));
            weaponArmText.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

            // Revolver
            // Piercer(Blue)
            // Marksman(Green)
            // Sharpshooter(Red)

            //Revolver window and descriptions
            GameObject revolverWindow = FindDescendant(shopWeaponsObject, "Revolver Window");
            GameObject revolverVariations = FindDescendant(revolverWindow, "Variation Screen", "Variations");

            TextMeshProUGUI revolverWindowTitle = GetTextMeshProUGUI(FindDescendant(revolverVariations.transform.parent.gameObject, "Title"));
            revolverWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;
            
            //Piercer
            GameObject piercer = FindDescendant(revolverVariations, "Variation Panel (Blue)");
            TextMeshProUGUI piercerName = GetTextMeshProUGUI(FindDescendant(piercer, "Variation Name"));
            piercerName.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercer;

            GameObject piercerWindow = FindDescendant(revolverWindow, "Variation Info (Blue)", "Panel");
            TextMeshProUGUI piercerWindowTitle = GetTextMeshProUGUI(FindDescendant(piercerWindow.transform.parent.gameObject, "Title"));
            piercerWindowTitle.text = piercerName.text;
            TextMeshProUGUI piercerWindowName = GetTextMeshProUGUI(FindDescendant(piercerWindow, "Name"));
            piercerWindowName.enableAutoSizing = true;
            piercerWindowName.fontSizeMax = piercerWindowName.fontSize;
            piercerWindowName.fontSizeMin = 0f;
            piercerWindowName.text = piercerName.text;

            TextMeshProUGUI piercerWindowDescription = GetTextMeshProUGUI(FindDescendant(piercerWindow, "Description"));
            piercerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2;

            TextMeshProUGUI piercerWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(piercerWindow, "Back Button", "Text"));
            piercerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Marksman
            GameObject marksman = FindDescendant(revolverVariations, "Variation Panel (Green)");
            TextMeshProUGUI marksmanName = GetTextMeshProUGUI(FindDescendant(marksman, "Variation Name"));
            marksmanName.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksman;

            GameObject marksmanWindow = FindDescendant(revolverWindow, "Variation Info (Green)", "Panel");
            TextMeshProUGUI marksmanWindowTitle = GetTextMeshProUGUI(FindDescendant(marksmanWindow.transform.parent.gameObject, "Title"));
            marksmanWindowTitle.text = marksmanName.text;
            TextMeshProUGUI marksmanWindowName = GetTextMeshProUGUI(FindDescendant(marksmanWindow, "Name"));
            marksmanWindowName.enableAutoSizing = true;
            marksmanWindowName.fontSizeMax = marksmanWindowName.fontSize;
            marksmanWindowName.fontSizeMin = 0f;
            marksmanWindowName.text = marksmanName.text;

            TextMeshProUGUI marksmanWindowDescription = GetTextMeshProUGUI(FindDescendant(marksmanWindow, "Description"));
            marksmanWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3;

            TextMeshProUGUI marksmanWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(marksmanWindow, "Back Button", "Text"));
            marksmanWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Sharpshooter
            GameObject sharpshooter = FindDescendant(revolverVariations, "Variation Panel (Red)");
            TextMeshProUGUI sharpshooterName = GetTextMeshProUGUI(FindDescendant(sharpshooter, "Variation Name"));
            sharpshooterName.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter;

            GameObject sharpshooterWindow = FindDescendant(revolverWindow, "Variation Info (Red)", "Panel");
            TextMeshProUGUI sharpshooterWindowTitle = GetTextMeshProUGUI(FindDescendant(sharpshooterWindow.transform.parent.gameObject, "Title"));
            sharpshooterWindowTitle.text = sharpshooterName.text;
            TextMeshProUGUI sharpshooterWindowName = GetTextMeshProUGUI(FindDescendant(sharpshooterWindow, "Name"));
            sharpshooterWindowName.enableAutoSizing = true;
            sharpshooterWindowName.fontSizeMax = sharpshooterWindowName.fontSize;
            sharpshooterWindowName.fontSizeMin = 0f;
            sharpshooterWindowName.text = sharpshooterName.text;

            TextMeshProUGUI sharpshooterWindowDescription = GetTextMeshProUGUI(FindDescendant(sharpshooterWindow, "Description"));
            sharpshooterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription2 + "\n\n";

            //just in case.
            TextMeshProUGUI redrevolverBackText = GetTextMeshProUGUI(FindDescendant(sharpshooterWindow, "Back Button", "Text"));
            redrevolverBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Revolver info & color tabs
            GameObject revolverExtra = FindDescendant(revolverVariations, "Info and Color Panel");
            GameObject revolverExtraInfo = FindDescendant(revolverExtra, "InfoButton");
            GameObject revolverExtraColor = FindDescendant(revolverExtra, "ColorButton");

            TextMeshProUGUI revolverExtraInfoText = GetTextMeshProUGUI(FindDescendant(revolverExtraInfo, "Text"));
            revolverExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            TextMeshProUGUI revolverExtraInfoColors = GetTextMeshProUGUI(FindDescendant(revolverExtraColor, "Text"));
            revolverExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Revolver lore
            GameObject revolverLore = FindDescendant(revolverWindow, "Info Screen");
            TextMeshProUGUI revolverLoreName = GetTextMeshProUGUI(FindDescendant(revolverLore, "Title"));
            RectTransform rl = revolverLoreName.GetComponent<RectTransform>();
            rl.sizeDelta = new Vector2(rl.sizeDelta.x + addWidth, rl.sizeDelta.y);
            revolverLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolverInfo;// + info
            TextMeshProUGUI revolverLoreTitle = GetTextMeshProUGUI(FindDescendant(revolverLore, "Main Window", "Name"));
            revolverLoreTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

            TextMeshProUGUI revolverLoreInfo = GetTextMeshProUGUI(FindDescendant(revolverLore, "Main Window", "Scroll View", "Viewport", "Text"));

            revolverLoreInfo.text =
                "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver5 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver7 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver9 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRevolver10;

            TextMeshProUGUI revolverLoreBack = GetTextMeshProUGUI(FindDescendant(revolverLore, "Main Window", "Back Button", "Text"));
            revolverLoreBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Revolver preset colors
            GameObject revolverColorWindow = FindDescendant(revolverWindow, "Color Screen", "Main Window");

            TextMeshProUGUI revolverColorWindowTitle = GetTextMeshProUGUI(FindDescendant(revolverColorWindow.transform.parent.gameObject,"Title"));
            RectTransform rc = revolverColorWindowTitle.GetComponent<RectTransform>();
            rc.sizeDelta = new Vector2(rc.sizeDelta.x + addWidth, rc.sizeDelta.y);
            revolverColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRevolverColors; //+ color

            GameObject revolverTemplates = FindDescendant(revolverColorWindow, "Window", "Presets");
            TextMeshProUGUI revolverTemplate1 = GetTextMeshProUGUI(FindDescendant(revolverTemplates, "Template 1", "Text"));
            TextMeshProUGUI revolverTemplate2 = GetTextMeshProUGUI(FindDescendant(revolverTemplates, "Template 2", "Text"));
            TextMeshProUGUI revolverTemplate3 = GetTextMeshProUGUI(FindDescendant(revolverTemplates, "Template 3", "Text"));
            TextMeshProUGUI revolverTemplate4 = GetTextMeshProUGUI(FindDescendant(revolverTemplates, "Template 4", "Text"));
            TextMeshProUGUI revolverTemplate5 = GetTextMeshProUGUI(FindDescendant(revolverTemplates, "Template 5", "Text"));

            revolverTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset1;
            revolverTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset2;
            revolverTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset3;
            revolverTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset4;
            revolverTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_revolverPreset5;

            /*  Patch GunColorTypeGetter.ToggleAlternate() instead
            TextMeshProUGUI revolverColorSwitchToAlternative = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(revolverColorWindow, "Standard"),"AlternateButton"),"Text"));
            revolverColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

            TextMeshProUGUI revolverColorSwitchToStandard = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(revolverColorWindow, "Alternate"), "AlternateButton"), "Text"));
            revolverColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;
            */

            GameObject revolverTypeButtons = FindDescendant(revolverTemplates.transform.parent.gameObject, "Type Selection");
            TextMeshProUGUI revolverColorPreset = GetTextMeshProUGUI(FindDescendant(revolverTypeButtons, "Preset Button", "Text"));
            revolverColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            TextMeshProUGUI revolverColorCustom = GetTextMeshProUGUI(FindDescendant(revolverTypeButtons, "Custom Button", "Text"));
            revolverColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            TextMeshProUGUI revolverColorDone = GetTextMeshProUGUI(FindDescendant(revolverTemplates.transform.parent.gameObject, "Done", "Text"));
            revolverColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //Revolver custom color unlock prompt
            TextMeshProUGUI revolverCustomColorPrompt = GetTextMeshProUGUI(FindDescendant(revolverTemplates.transform.parent.gameObject, "Custom", "Locked", "Text"));
            revolverCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver;

            // SHOTGUN
            // Core Eject(Blue)
            // Pump Charge(Green)
            // Sawed-On(Red)

            //Shotgun window and descriptions
            GameObject shotgunWindow = FindDescendant(shopWeaponsObject, "Shotgun Window");
            GameObject shotgunVariations = FindDescendant(shotgunWindow, "Variation Screen", "Variations");

            TextMeshProUGUI shotgunWindowTitle = GetTextMeshProUGUI(FindDescendant(shotgunVariations.transform.parent.gameObject, "Title"));
            shotgunWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

            //Core Eject
            GameObject coreEject = FindDescendant(shotgunVariations, "Variation Panel (Blue)");
            TextMeshProUGUI coreEjectName = GetTextMeshProUGUI(FindDescendant(coreEject, "Variation Name"));
            coreEjectName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;

            GameObject coreEjectWindow = FindDescendant(shotgunWindow, "Variation Info (Blue)", "Panel");
            TextMeshProUGUI coreEjectWindowTitle = GetTextMeshProUGUI(FindDescendant(coreEjectWindow.transform.parent.gameObject, "Title"));
            coreEjectWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject;
            TextMeshProUGUI coreEjectWindowName = GetTextMeshProUGUI(FindDescendant(coreEjectWindow, "Name"));
            coreEjectWindowName.enableAutoSizing = true;
            coreEjectWindowName.fontSizeMax = coreEjectWindowName.fontSize;
            coreEjectWindowName.fontSizeMin = 0f;
            coreEjectWindowName.text = coreEjectName.text;

            TextMeshProUGUI coreEjectWindowDescription = GetTextMeshProUGUI(FindDescendant(coreEjectWindow, "Description"));
            coreEjectWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3;

            TextMeshProUGUI coreEjectWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(coreEjectWindow, "Back Button", "Text"));
            coreEjectWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Pump Charge
            GameObject pumpCharge = FindDescendant(shotgunVariations, "Variation Panel (Green)");
            TextMeshProUGUI pumpChargeName = GetTextMeshProUGUI(FindDescendant(pumpCharge, "Variation Name"));
            pumpChargeName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;

            GameObject pumpChargeWindow = FindDescendant(shotgunWindow, "Variation Info (Green)", "Panel");
            TextMeshProUGUI pumpChargeWindowTitle = GetTextMeshProUGUI(FindDescendant(pumpChargeWindow.transform.parent.gameObject, "Title"));
            pumpChargeWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;
            TextMeshProUGUI pumpChargeWindowName = GetTextMeshProUGUI(FindDescendant(pumpChargeWindow, "Name"));
            pumpChargeWindowName.enableAutoSizing = true;
            pumpChargeWindowName.fontSizeMax = pumpChargeWindowName.fontSize;
            pumpChargeWindowName.fontSizeMin = 0f;
            pumpChargeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge;

            TextMeshProUGUI pumpChargeWindowDescription = GetTextMeshProUGUI(FindDescendant(pumpChargeWindow, "Description"));
            pumpChargeWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2;

            TextMeshProUGUI pumpChargeWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(pumpChargeWindow, "Back Button", "Text"));
            pumpChargeWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Sawed-On
            GameObject sawedOn = FindDescendant(shotgunVariations, "Variation Panel (Red)");
            TextMeshProUGUI sawedOnName = GetTextMeshProUGUI(FindDescendant(sawedOn, "Variation Name"));
            sawedOnName.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn;

            GameObject sawedOnWindow = FindDescendant(shotgunWindow, "Variation Info (Red)", "Panel");
            TextMeshProUGUI sawedOnWindowTitle = GetTextMeshProUGUI(FindDescendant(sawedOnWindow.transform.parent.gameObject, "Title"));
            sawedOnWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn;
            TextMeshProUGUI sawedOnWindowName = GetTextMeshProUGUI(FindDescendant(sawedOnWindow, "Name"));
            sawedOnWindowName.enableAutoSizing = true;
            sawedOnWindowName.fontSizeMax = sawedOnWindowName.fontSize;
            sawedOnWindowName.fontSizeMin = 0f;
            sawedOnWindowName.text = sawedOnName.text;

            TextMeshProUGUI sawedOnWindowDescription = GetTextMeshProUGUI(FindDescendant(sawedOnWindow, "Description"));
            sawedOnWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription3;

            TextMeshProUGUI sawedOnWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(sawedOnWindow, "Back Button", "Text"));
            sawedOnWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Shotgun info & color tabs
            GameObject shotgunExtra = FindDescendant(shotgunVariations, "Info and Color Panel");
            GameObject shotgunExtraInfo = FindDescendant(shotgunExtra, "InfoButton");
            GameObject shotgunExtraColor = FindDescendant(shotgunExtra, "ColorButton");

            TextMeshProUGUI shotgunExtraInfoText = GetTextMeshProUGUI(FindDescendant(shotgunExtraInfo, "Text"));
            shotgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            TextMeshProUGUI shotgunExtraInfoColors = GetTextMeshProUGUI(FindDescendant(shotgunExtraColor, "Text"));
            shotgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Shotgun lore
            GameObject shotgunLore = FindDescendant(shotgunWindow, "Info Screen", "Main Window");
            TextMeshProUGUI shotgunLoreName = GetTextMeshProUGUI(FindDescendant(shotgunLore.transform.parent.gameObject, "Title"));
            RectTransform sl = shotgunLoreName.GetComponent<RectTransform>();
            sl.sizeDelta = new Vector2(sl.sizeDelta.x + addWidth, sl.sizeDelta.y);
            shotgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgunInfo;
            TextMeshProUGUI shotgunLoreTitle = GetTextMeshProUGUI(FindDescendant(shotgunLore, "Name"));
            shotgunLoreTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

            TextMeshProUGUI shotgunLoreInfo = GetTextMeshProUGUI(FindDescendant(shotgunLore, "Scroll View", "Viewport", "Text"));

            shotgunLoreInfo.text =
                "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun4 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun6 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreShotgun9;

            TextMeshProUGUI shotgunLoreBack = GetTextMeshProUGUI(FindDescendant(shotgunLore, "Back Button", "Text"));
            shotgunLoreBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Shotgun preset colors
            GameObject shotgunColorWindow = FindDescendant(shotgunWindow, "Color Screen", "Main Window");

            TextMeshProUGUI shotgunColorWindowTitle = GetTextMeshProUGUI(FindDescendant(shotgunColorWindow.transform.parent.gameObject, "Title"));
            RectTransform sc = shotgunColorWindowTitle.GetComponent<RectTransform>();
            sc.sizeDelta = new Vector2(sc.sizeDelta.x + addWidth, sc.sizeDelta.y);
            shotgunColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsShotgunColors; //+ color

            GameObject shotgunTemplates = FindDescendant(shotgunColorWindow, "Window", "Presets");
            TextMeshProUGUI shotgunTemplate1 = GetTextMeshProUGUI(FindDescendant(shotgunTemplates, "Template 1", "Text"));
            TextMeshProUGUI shotgunTemplate2 = GetTextMeshProUGUI(FindDescendant(shotgunTemplates, "Template 2", "Text"));
            TextMeshProUGUI shotgunTemplate3 = GetTextMeshProUGUI(FindDescendant(shotgunTemplates, "Template 3", "Text"));
            TextMeshProUGUI shotgunTemplate4 = GetTextMeshProUGUI(FindDescendant(shotgunTemplates, "Template 4", "Text"));
            TextMeshProUGUI shotgunTemplate5 = GetTextMeshProUGUI(FindDescendant(shotgunTemplates, "Template 5", "Text"));

            shotgunTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1;
            shotgunTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2;
            shotgunTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3;
            shotgunTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4;
            shotgunTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5;

            GameObject shotgunTypeButtons = FindDescendant(shotgunTemplates.transform.parent.gameObject, "Type Selection");
            TextMeshProUGUI shotgunColorPreset = GetTextMeshProUGUI(FindDescendant(FindDescendant(shotgunTypeButtons, "Preset Button"), "Text"));
            shotgunColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            TextMeshProUGUI shotgunColorCustom = GetTextMeshProUGUI(FindDescendant(FindDescendant(shotgunTypeButtons, "Custom Button"), "Text"));
            shotgunColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            TextMeshProUGUI shotgunColorDone = GetTextMeshProUGUI(FindDescendant(FindDescendant(shotgunTemplates.transform.parent.gameObject, "Done"), "Text"));
            shotgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //shotgun custom color unlock prompt
            TextMeshProUGUI shotgunCustomColorPrompt = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(shotgunTemplates.transform.parent.gameObject, "Custom"), "Locked"), "Text"));
            shotgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun;

            // Nailgun
            // Attractor(Blue)
            // Overheat(Green)
            // Jumpstart(Red)

            //Nailgun window and descriptions
            GameObject nailgunWindow = FindDescendant(shopWeaponsObject, "Nailgun Window");
            GameObject nailgunVariations = FindDescendant(nailgunWindow, "Variation Screen", "Variations");

            TextMeshProUGUI nailgunWindowTitle = GetTextMeshProUGUI(FindDescendant(nailgunVariations.transform.parent.gameObject, "Title"));
            nailgunWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

            //Attractor
            GameObject attractor = FindDescendant(nailgunVariations, "Variation Panel (Blue)");
            TextMeshProUGUI attractorName = GetTextMeshProUGUI(FindDescendant(attractor, "Variation Name"));
            attractorName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;

            GameObject attractorWindow = FindDescendant(nailgunWindow, "Variation Info (Blue)", "Panel");
            TextMeshProUGUI attractorWindowTitle = GetTextMeshProUGUI(FindDescendant(attractorWindow.transform.parent.gameObject, "Title"));
            attractorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet;
            TextMeshProUGUI attractorWindowName = GetTextMeshProUGUI(FindDescendant(attractorWindow, "Name"));
            attractorWindowName.enableAutoSizing = true;
            attractorWindowName.fontSizeMax = attractorWindowName.fontSize;
            attractorWindowName.fontSizeMin = 0f;
            attractorWindowName.text = attractorName.text;

            TextMeshProUGUI attractorWindowDescription = GetTextMeshProUGUI(FindDescendant(attractorWindow, "Description"));
            attractorWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2;

            TextMeshProUGUI attractorWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(attractorWindow, "Back Button", "Text"));
            attractorWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Overheat
            GameObject overheat = FindDescendant(nailgunVariations, "Variation Panel (Green)");
            TextMeshProUGUI overheatName = GetTextMeshProUGUI(FindDescendant(overheat, "Variation Name"));
            overheatName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;

            GameObject overheatWindow = FindDescendant(nailgunWindow, "Variation Info (Green)", "Panel");
            TextMeshProUGUI overheatWindowTitle = GetTextMeshProUGUI(FindDescendant(overheatWindow.transform.parent.gameObject, "Title"));
            overheatWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
            TextMeshProUGUI overheatWindowName = GetTextMeshProUGUI(FindDescendant(overheatWindow, "Name"));
            overheatWindowName.enableAutoSizing = true;
            overheatWindowName.fontSizeMax = overheatWindowName.fontSize;
            overheatWindowName.fontSizeMin = 0f;
            overheatWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat;
            

            TextMeshProUGUI overheatWindowDescription = GetTextMeshProUGUI(FindDescendant(overheatWindow, "Description"));
            overheatWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2;

            TextMeshProUGUI overheatWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(overheatWindow, "Back Button", "Text"));
            overheatWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Jumpstarter
            GameObject jumpStart = FindDescendant(nailgunVariations, "Variation Panel (Red)");
            TextMeshProUGUI jumpStartName = GetTextMeshProUGUI(FindDescendant(jumpStart, "Variation Name"));
            jumpStartName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;

            GameObject jumpStartWindow = FindDescendant(nailgunWindow, "Variation Info (Red)", "Panel");
            TextMeshProUGUI jumpStartWindowTitle = GetTextMeshProUGUI(FindDescendant(jumpStartWindow.transform.parent.gameObject, "Title"));
            jumpStartWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;
            TextMeshProUGUI jumpStartWindowName = GetTextMeshProUGUI(FindDescendant(jumpStartWindow, "Name"));
            jumpStartWindowName.enableAutoSizing = true;
            jumpStartWindowName.fontSizeMax = jumpStartWindowName.fontSize;
            jumpStartWindowName.fontSizeMin = 0f;
            jumpStartWindowName.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart;

            TextMeshProUGUI jumpStartWindowDescription = GetTextMeshProUGUI(FindDescendant(jumpStartWindow, "Description"));
            jumpStartWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription2;

            TextMeshProUGUI jumpStartWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(jumpStartWindow, "Back Button", "Text"));
            jumpStartWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Nailgun info & color tabs
            GameObject nailgunExtra = FindDescendant(nailgunVariations, "Info and Color Panel");
            GameObject nailgunExtraInfo = FindDescendant(nailgunExtra, "InfoButton");
            GameObject nailgunExtraColor = FindDescendant(nailgunExtra, "ColorButton");

            TextMeshProUGUI nailgunExtraInfoText = GetTextMeshProUGUI(FindDescendant(nailgunExtraInfo, "Text"));
            nailgunExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            TextMeshProUGUI nailgunExtraInfoColors = GetTextMeshProUGUI(FindDescendant(nailgunExtraColor, "Text"));
            nailgunExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Nailgun lore
            GameObject nailgunLore = FindDescendant(nailgunWindow, "Info Screen", "Main Window");
            TextMeshProUGUI nailgunLoreName = GetTextMeshProUGUI(FindDescendant(nailgunLore.transform.parent.gameObject, "Title"));
            RectTransform nl = nailgunLoreName.GetComponent<RectTransform>();
            nl.sizeDelta = new Vector2(nl.sizeDelta.x + addWidth, nl.sizeDelta.y);
            nailgunLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgunInfo;
            TextMeshProUGUI nailgunLoreTitle = GetTextMeshProUGUI(FindDescendant(nailgunLore, "Name"));
            nailgunLoreTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

            TextMeshProUGUI NailgunLoreInfo = GetTextMeshProUGUI(FindDescendant(nailgunLore, "Scroll View", "Viewport", "Text"));

            NailgunLoreInfo.text =
                "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun4 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun7 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreNailgun9;

            TextMeshProUGUI NailgunLoreBack = GetTextMeshProUGUI(FindDescendant(nailgunLore, "Back Button", "Text"));
            NailgunLoreBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //nailgun preset colors
            GameObject nailgunColorWindow = FindDescendant(nailgunWindow, "Color Screen", "Main Window");

            TextMeshProUGUI nailgunColorWindowTitle = GetTextMeshProUGUI(FindDescendant(nailgunColorWindow.transform.parent.gameObject, "Title"));
            RectTransform nc = nailgunColorWindowTitle.GetComponent<RectTransform>();
            nc.sizeDelta = new Vector2(nc.sizeDelta.x + addWidth, nc.sizeDelta.y);
            nailgunColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsNailgunColors; //+ color

            GameObject nailgunTemplates = FindDescendant(nailgunColorWindow, "Window", "Presets");
            TextMeshProUGUI nailgunTemplate1 = GetTextMeshProUGUI(FindDescendant(nailgunTemplates, "Template 1", "Text"));
            TextMeshProUGUI nailgunTemplate2 = GetTextMeshProUGUI(FindDescendant(nailgunTemplates, "Template 2", "Text"));
            TextMeshProUGUI nailgunTemplate3 = GetTextMeshProUGUI(FindDescendant(nailgunTemplates, "Template 3", "Text"));
            TextMeshProUGUI nailgunTemplate4 = GetTextMeshProUGUI(FindDescendant(nailgunTemplates, "Template 4", "Text"));
            TextMeshProUGUI nailgunTemplate5 = GetTextMeshProUGUI(FindDescendant(nailgunTemplates, "Template 5", "Text"));

            nailgunTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1;
            nailgunTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2;
            nailgunTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3;
            nailgunTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4;
            nailgunTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5;

            GameObject nailgunTypeButtons = FindDescendant(nailgunTemplates.transform.parent.gameObject, "Type Selection");
            TextMeshProUGUI nailgunColorPreset = GetTextMeshProUGUI(FindDescendant(nailgunTypeButtons, "Preset Button", "Text"));
            nailgunColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            TextMeshProUGUI nailgunColorCustom = GetTextMeshProUGUI(FindDescendant(nailgunTypeButtons, "Custom Button", "Text"));
            nailgunColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            TextMeshProUGUI nailgunColorDone = GetTextMeshProUGUI(FindDescendant(nailgunTemplates.transform.parent.gameObject, "Done", "Text"));
            nailgunColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //nailgun custom color unlock prompt
            TextMeshProUGUI nailgunCustomColorPrompt = GetTextMeshProUGUI(FindDescendant(nailgunTemplates.transform.parent.gameObject, "Custom", "Locked", "Text"));
            nailgunCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun;

            // Railcannon
            // Electric(Blue)
            // Screwdriver(Green)
            // Malicious(Red)

            //Railcannon window and descriptions
            GameObject railcannonWindow = FindDescendant(shopWeaponsObject, "Railcannon Window");
            GameObject railcannonVariations = FindDescendant(railcannonWindow, "Variation Screen", "Variations");

            TextMeshProUGUI railcannonWindowTitle = GetTextMeshProUGUI(FindDescendant(railcannonVariations.transform.parent.gameObject, "Title"));
            railcannonWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

            //Electric
            GameObject electric = FindDescendant(railcannonVariations, "Variation Panel (Blue)");
            TextMeshProUGUI electricName = GetTextMeshProUGUI(FindDescendant(electric, "Variation Name"));
            electricName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

            GameObject electricWindow = FindDescendant(railcannonWindow, "Variation Info (Blue)", "Panel");
            TextMeshProUGUI electricWindowTitle = GetTextMeshProUGUI(FindDescendant(electricWindow.transform.parent.gameObject, "Title"));
            electricWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;
            TextMeshProUGUI electricWindowName = GetTextMeshProUGUI(FindDescendant(electricWindow, "Name"));
            electricWindowName.enableAutoSizing = true;
            electricWindowName.fontSizeMax = electricWindowName.fontSize;
            electricWindowName.fontSizeMin = 0f;
            electricWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectric;

            TextMeshProUGUI electricWindowDescription = GetTextMeshProUGUI(FindDescendant(electricWindow, "Description"));
            electricWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3;

            TextMeshProUGUI electricWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(electricWindow, "Back Button", "Text"));
            electricWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Screwdriver
            GameObject screwdriver = FindDescendant(railcannonVariations, "Variation Panel (Green)");
            TextMeshProUGUI screwdriverName = GetTextMeshProUGUI(FindDescendant(screwdriver, "Variation Name"));
            screwdriverName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

            GameObject screwdriverWindow = FindDescendant(railcannonWindow, "Variation Info (Green)", "Panel");
            TextMeshProUGUI screwdriverWindowTitle = GetTextMeshProUGUI(FindDescendant(screwdriverWindow.transform.parent.gameObject, "Title"));
            screwdriverWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;
            TextMeshProUGUI screwdriverWindowName = GetTextMeshProUGUI(FindDescendant(screwdriverWindow, "Name"));
            screwdriverWindowName.enableAutoSizing = true;
            screwdriverWindowName.fontSizeMax = screwdriverWindowName.fontSize;
            screwdriverWindowName.fontSizeMin = 0f;
            screwdriverWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver;

            TextMeshProUGUI screwdriverWindowDescription = GetTextMeshProUGUI(FindDescendant(screwdriverWindow, "Description"));
            screwdriverWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2;

            TextMeshProUGUI screwdriverWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(screwdriverWindow, "Back Button", "Text"));
            screwdriverWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Malicious
            GameObject malicious = FindDescendant(railcannonVariations, "Variation Panel (Red)");
            TextMeshProUGUI maliciousName = GetTextMeshProUGUI(FindDescendant(malicious, "Variation Name"));
            maliciousName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

            GameObject maliciousWindow = FindDescendant(railcannonWindow, "Variation Info (Red)", "Panel");
            TextMeshProUGUI maliciousWindowTitle = GetTextMeshProUGUI(FindDescendant(maliciousWindow.transform.parent.gameObject, "Title"));
            maliciousWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;
            TextMeshProUGUI maliciousWindowName = GetTextMeshProUGUI(FindDescendant(maliciousWindow, "Name"));
            maliciousWindowName.enableAutoSizing = true;
            maliciousWindowName.fontSizeMax = maliciousWindowName.fontSize;
            maliciousWindowName.fontSizeMin = 0f;
            maliciousWindowName.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious;

            TextMeshProUGUI maliciousWindowDescription = GetTextMeshProUGUI(FindDescendant(maliciousWindow, "Description"));
            maliciousWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
                +  LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2;

            TextMeshProUGUI maliciousWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(maliciousWindow, "Back Button", "Text"));
            maliciousWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Railcannon info & color tabs
            GameObject railcannonExtra = FindDescendant(railcannonVariations, "Info and Color Panel");
            GameObject railcannonExtraInfo = FindDescendant(railcannonExtra, "InfoButton");
            GameObject railcannonExtraColor = FindDescendant(railcannonExtra, "ColorButton");

            TextMeshProUGUI railcannonExtraInfoText = GetTextMeshProUGUI(FindDescendant(railcannonExtraInfo, "Text"));
            railcannonExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            TextMeshProUGUI railcannonExtraInfoColors = GetTextMeshProUGUI(FindDescendant(railcannonExtraColor, "Text"));
            railcannonExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //Railcannon lore
            GameObject railcannonLore = FindDescendant(railcannonWindow, "Info Screen", "Main Window");
            TextMeshProUGUI railcannonLoreName = GetTextMeshProUGUI(FindDescendant(railcannonLore.transform.parent.gameObject, "Title"));
            RectTransform rcl = railcannonLoreName.GetComponent<RectTransform>();
            rcl.sizeDelta = new Vector2(rcl.sizeDelta.x + addWidth, rcl.sizeDelta.y);
            railcannonLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannonInfo;
            TextMeshProUGUI railcannonLoreTitle = GetTextMeshProUGUI(FindDescendant(railcannonLore, "Name"));
            railcannonLoreTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

            TextMeshProUGUI railcannonLoreInfo = GetTextMeshProUGUI(FindDescendant(railcannonLore, "Scroll View", "Viewport", "Text"));

            railcannonLoreInfo.text =
                 "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon4 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon6 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon7 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon9;

            TextMeshProUGUI railcannonLoreBack = GetTextMeshProUGUI(FindDescendant(railcannonLore, "Back Button", "Text"));
            railcannonLoreBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Railcannon preset colors
            GameObject railcannonColorWindow = FindDescendant(railcannonWindow, "Color Screen", "Main Window");

            TextMeshProUGUI railcannonColorWindowTitle = GetTextMeshProUGUI(FindDescendant(railcannonColorWindow.transform.parent.gameObject, "Title"));
            RectTransform rcc = railcannonColorWindowTitle.GetComponent<RectTransform>();
            rcc.sizeDelta = new Vector2(rcc.sizeDelta.x + addWidth, rcc.sizeDelta.y);
            railcannonColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannonColors; //+ color

            GameObject railcannonTemplates = FindDescendant(FindDescendant(railcannonColorWindow, "Window"), "Presets");
            TextMeshProUGUI railcannonTemplate1 = GetTextMeshProUGUI(FindDescendant(railcannonTemplates, "Template 1", "Text"));
            TextMeshProUGUI railcannonTemplate2 = GetTextMeshProUGUI(FindDescendant(railcannonTemplates, "Template 2", "Text"));
            TextMeshProUGUI railcannonTemplate3 = GetTextMeshProUGUI(FindDescendant(railcannonTemplates, "Template 3", "Text"));
            TextMeshProUGUI railcannonTemplate4 = GetTextMeshProUGUI(FindDescendant(railcannonTemplates, "Template 4", "Text"));
            TextMeshProUGUI railcannonTemplate5 = GetTextMeshProUGUI(FindDescendant(railcannonTemplates, "Template 5", "Text"));

            railcannonTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1;
            railcannonTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2;
            railcannonTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3;
            railcannonTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4;
            railcannonTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5;

            GameObject railcannonTypeButtons = FindDescendant(railcannonTemplates.transform.parent.gameObject, "Type Selection");
            TextMeshProUGUI railcannonColorPreset = GetTextMeshProUGUI(FindDescendant(railcannonTypeButtons, "Preset Button", "Text"));
            railcannonColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            TextMeshProUGUI railcannonColorCustom = GetTextMeshProUGUI(FindDescendant(railcannonTypeButtons, "Custom Button", "Text"));
            railcannonColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            TextMeshProUGUI railcannonColorDone = GetTextMeshProUGUI(FindDescendant(railcannonTemplates.transform.parent.gameObject, "Done", "Text"));
            railcannonColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //railcannon custom color unlock prompt
            TextMeshProUGUI railcannonCustomColorPrompt = GetTextMeshProUGUI(FindDescendant(railcannonTemplates.transform.parent.gameObject, "Custom", "Locked", "Text"));
            railcannonCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon;

            // Rocket Launcher
            // Freezeframe(Blue)
            // S.R.S Cannon(Green)
            // Firestarter(Red)

            //Rocket launcher window & descriptions
            GameObject rocketlauncherWindow = FindDescendant(shopWeaponsObject, "Rocket Launcher Window");
            GameObject rocketlauncherVariations = FindDescendant(rocketlauncherWindow, "Variation Screen", "Variations");

            TextMeshProUGUI rocketlauncherWindowTitle = GetTextMeshProUGUI(FindDescendant(rocketlauncherVariations.transform.parent.gameObject, "Title"));
            rocketlauncherWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

            //Freezeframe
            GameObject freezeframe = FindDescendant(rocketlauncherVariations, "Variation Panel (Blue)");
            TextMeshProUGUI freezeframeName = GetTextMeshProUGUI(FindDescendant(freezeframe, "Variation Name"));
            freezeframeName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;

            GameObject freezeframeInfo = FindDescendant(rocketlauncherWindow, "Variation Info (Blue)", "Panel");
            TextMeshProUGUI freezeframeInfoTitle = GetTextMeshProUGUI(FindDescendant(freezeframeInfo.transform.parent.gameObject, "Title"));
            freezeframeInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
            TextMeshProUGUI freezeframeWindowName = GetTextMeshProUGUI(FindDescendant(freezeframeInfo, "Name"));
            freezeframeWindowName.enableAutoSizing = true;
            freezeframeWindowName.fontSizeMax = freezeframeWindowName.fontSize;
            freezeframeWindowName.fontSizeMin = 0f;
            freezeframeWindowName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze;
            TextMeshProUGUI freezeframeDescription = GetTextMeshProUGUI(FindDescendant(freezeframeInfo, "Description"));
            freezeframeDescription.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + 
            LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2;

            TextMeshProUGUI freezeframeDescriptionBack = GetTextMeshProUGUI(FindDescendant(freezeframeInfo, "Back Button", "Text"));
            freezeframeDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Rocket Launcher green variation
            GameObject srsCannon = FindDescendant(rocketlauncherVariations, "Variation Panel (Green)");
            TextMeshProUGUI srsCannonName = GetTextMeshProUGUI(FindDescendant(srsCannon, "Variation Name"));
            srsCannonName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
            
            GameObject srsCannonInfo = FindDescendant(rocketlauncherWindow, "Variation Info (Green)", "Panel");
            TextMeshProUGUI srsCannonInfoTitle = GetTextMeshProUGUI(FindDescendant(srsCannonInfo.transform.parent.gameObject, "Title"));
            srsCannonInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
            TextMeshProUGUI srsCannonWindowName = GetTextMeshProUGUI(FindDescendant(srsCannonInfo, "Name"));
            srsCannonWindowName.enableAutoSizing = true;
            srsCannonWindowName.fontSizeMax = srsCannonWindowName.fontSize;
            srsCannonWindowName.fontSizeMin = 0f;
            srsCannonWindowName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon;
            TextMeshProUGUI srsCannonInfoDescription = GetTextMeshProUGUI(FindDescendant(srsCannonInfo, "Description"));
            srsCannonInfoDescription.text =
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription1 + "\n\n" +
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription2 + "\n\n" +
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription3;

            TextMeshProUGUI srsCannonBackText = GetTextMeshProUGUI(FindDescendant(srsCannonInfo, "Back Button", "Text"));
            srsCannonBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Firestarter a.k.a Gasoline
            GameObject fireStarter = FindDescendant(rocketlauncherVariations, "Variation Panel (Red)");
            TextMeshProUGUI fireStarterName = GetTextMeshProUGUI(FindDescendant(fireStarter, "Variation Name"));
            fireStarterName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;

            GameObject fireStarterInfo = FindDescendant(rocketlauncherWindow, "Variation Info (Red)", "Panel");
            TextMeshProUGUI fireStarterInfoTitle = GetTextMeshProUGUI(FindDescendant(fireStarterInfo.transform.parent.gameObject, "Title"));
            fireStarterInfoTitle.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;
            TextMeshProUGUI fireStarterInfoName = GetTextMeshProUGUI(FindDescendant(fireStarterInfo, "Name"));
            fireStarterInfoName.enableAutoSizing = true;
            fireStarterInfoName.fontSizeMax = fireStarterInfoName.fontSize;
            fireStarterInfoName.fontSizeMin = 0f;
            fireStarterInfoName.text = LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter;
            TextMeshProUGUI fireStarterInfoDescription = GetTextMeshProUGUI(FindDescendant(fireStarterInfo, "Description"));
            fireStarterInfoDescription.text =
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription1 + "\n\n" +
                LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription2;
            TextMeshProUGUI fireStarterBackText = GetTextMeshProUGUI(FindDescendant(fireStarterInfo, "Back Button", "Text"));
            fireStarterBackText.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //Rocket launcher info & color tabs
            GameObject rocketlauncherExtra = FindDescendant(rocketlauncherVariations, "Info and Color Panel");
            GameObject rocketlauncherExtraInfo = FindDescendant(rocketlauncherExtra, "InfoButton");
            GameObject rocketlauncherExtraColor = FindDescendant(rocketlauncherExtra, "ColorButton");

            TextMeshProUGUI rocketlauncherExtraInfoText = GetTextMeshProUGUI(FindDescendant(rocketlauncherExtraInfo, "Text"));
            rocketlauncherExtraInfoText.text = LanguageManager.CurrentLanguage.shop.shop_weaponInfo;

            TextMeshProUGUI rocketlauncherExtraInfoColors = GetTextMeshProUGUI(FindDescendant(rocketlauncherExtraColor, "Text"));
            rocketlauncherExtraInfoColors.text = LanguageManager.CurrentLanguage.shop.shop_weaponColors;

            //RocketLauncher lore
            GameObject rocketlauncherLore = FindDescendant(rocketlauncherWindow, "Info Screen", "Main Window");
            TextMeshProUGUI rocketlauncherLoreName = GetTextMeshProUGUI(FindDescendant(rocketlauncherLore.transform.parent.gameObject, "Title"));
            RectTransform rll = rocketlauncherLoreName.GetComponent<RectTransform>();
            rll.sizeDelta = new Vector2(rll.sizeDelta.x + addWidth, rll.sizeDelta.y);
            rocketlauncherLoreName.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncherInfo;
            TextMeshProUGUI rocketlauncherLoreTitle = GetTextMeshProUGUI(FindDescendant(rocketlauncherLore, "Name"));
            rocketlauncherLoreTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

            TextMeshProUGUI rocketlauncherLoreInfo = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(rocketlauncherLore, "Scroll View"), "Viewport"), "Text"));

            rocketlauncherLoreInfo.text =
                  "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_data + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher2 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher3 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher4 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher5 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher6 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher7 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_strategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher8 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher9 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher10 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher11 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher12 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher13 + "\n\n"
                + "<color=#FF4343>" + LanguageManager.CurrentLanguage.shop.shop_advancedStrategy + "</color>\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher14 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher15 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher16;

            TextMeshProUGUI rocketlauncherLoreBack = GetTextMeshProUGUI(FindDescendant(rocketlauncherLore, "Back Button", "Text"));
            rocketlauncherLoreBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //RocketLauncher preset colors
            GameObject rocketlauncherColorWindow = FindDescendant(rocketlauncherWindow, "Color Screen", "Main Window");

            TextMeshProUGUI rocketlauncherColorWindowTitle = GetTextMeshProUGUI(FindDescendant(rocketlauncherColorWindow.transform.parent.gameObject, "Title"));
            RectTransform rlc = rocketlauncherColorWindowTitle.GetComponent<RectTransform>();
            rlc.sizeDelta = new Vector2(rlc.sizeDelta.x + addWidth, rlc.sizeDelta.y);
            rocketlauncherColorWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncherColors; //+ color

            GameObject rocketlauncherTemplates = FindDescendant(rocketlauncherColorWindow, "Window", "Presets");
            TextMeshProUGUI rocketlauncherTemplate1 = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates, "Template 1", "Text"));
            TextMeshProUGUI rocketlauncherTemplate2 = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates, "Template 2", "Text"));
            TextMeshProUGUI rocketlauncherTemplate3 = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates, "Template 3", "Text"));
            TextMeshProUGUI rocketlauncherTemplate4 = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates, "Template 4", "Text"));
            TextMeshProUGUI rocketlauncherTemplate5 = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates, "Template 5", "Text"));

            rocketlauncherTemplate1.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1;
            rocketlauncherTemplate2.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2;
            rocketlauncherTemplate3.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3;
            rocketlauncherTemplate4.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4;
            rocketlauncherTemplate5.text = LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5;

            GameObject rocketlauncherTypeButtons = FindDescendant(rocketlauncherTemplates.transform.parent.gameObject, "Type Selection");
            TextMeshProUGUI rocketlauncherColorPreset = GetTextMeshProUGUI(FindDescendant(rocketlauncherTypeButtons, "Preset Button", "Text"));
            rocketlauncherColorPreset.text = LanguageManager.CurrentLanguage.shop.shop_colorsPreset;

            TextMeshProUGUI rocketlauncherColorCustom = GetTextMeshProUGUI(FindDescendant(rocketlauncherTypeButtons, "Custom Button", "Text"));
            rocketlauncherColorCustom.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustom;

            TextMeshProUGUI rocketlauncherColorDone = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates.transform.parent.gameObject, "Done", "Text"));
            rocketlauncherColorDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            //rocketlauncher custom color unlock prompt
            TextMeshProUGUI rocketlauncherCustomColorPrompt = GetTextMeshProUGUI(FindDescendant(rocketlauncherTemplates.transform.parent.gameObject, "Custom", "Locked", "Text"));
            rocketlauncherCustomColorPrompt.text = LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher;

            // Arm
            // Feedbacker(Blue)
            // Knuckleblaster(Red)
            // Whiplash(Green)
            // ???(Yellow)

            //Arm window and descriptions
            GameObject armWindow = FindDescendant(shopWeaponsObject, "Arm Window");
            GameObject armVariations = FindDescendant(armWindow, "Variation Screen", "Variations");

            TextMeshProUGUI armWindowTitle = GetTextMeshProUGUI(FindDescendant(armVariations.transform.parent.gameObject, "Title"));
            armWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_weaponsArms;

            //Feedbacker
            GameObject feedbacker = FindDescendant(armVariations, "Arm Panel (Blue)");
            TextMeshProUGUI feedbackerName = GetTextMeshProUGUI(FindDescendant(feedbacker, "Variation Name"));
            feedbackerName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

            GameObject feedbackerWindow = FindDescendant(armWindow, "Arm Info (Blue)", "Panel");
            TextMeshProUGUI feedbackerWindowTitle = GetTextMeshProUGUI(FindDescendant(feedbackerWindow.transform.parent.gameObject, "Title"));
            feedbackerWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;
            TextMeshProUGUI feedbackerWindowName = GetTextMeshProUGUI(FindDescendant(feedbackerWindow, "Name"));
            feedbackerWindowName.enableAutoSizing = true;
            feedbackerWindowName.fontSizeMax = feedbackerWindowName.fontSize;
            feedbackerWindowName.fontSizeMin = 0f;
            feedbackerWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbacker;

            TextMeshProUGUI feedbackerWindowDescription = GetTextMeshProUGUI(FindDescendant(feedbackerWindow, "Description"));
            feedbackerWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2;

            TextMeshProUGUI feedbackerWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(feedbackerWindow, "Back Button", "Text"));
            feedbackerWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;
            
            //Knuckleblaster
            GameObject knuckleblaster = FindDescendant(armVariations, "Arm Panel (Red)");
            TextMeshProUGUI knuckleblasterName = GetTextMeshProUGUI(FindDescendant(knuckleblaster, "Variation Name"));
            knuckleblasterName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

            GameObject knuckleblasterWindow = FindDescendant(armWindow, "Arm Info (Red)", "Panel");
            TextMeshProUGUI knuckleblasterWindowTitle = GetTextMeshProUGUI(FindDescendant(knuckleblasterWindow.transform.parent.gameObject, "Title"));
            knuckleblasterWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;
            TextMeshProUGUI knuckleblasterWindowName = GetTextMeshProUGUI(FindDescendant(knuckleblasterWindow, "Name"));
            knuckleblasterWindowName.enableAutoSizing = true;
            knuckleblasterWindowName.fontSizeMax = knuckleblasterWindowName.fontSize;
            knuckleblasterWindowName.fontSizeMin = 0f;
            knuckleblasterWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster;

            TextMeshProUGUI knuckleblasterWindowDescription = GetTextMeshProUGUI(FindDescendant(knuckleblasterWindow, "Description"));
            knuckleblasterWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n" + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2;

            TextMeshProUGUI knuckleblasterWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(knuckleblasterWindow, "Back Button", "Text"));
            knuckleblasterWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;
            
            //Whiplash
            GameObject whiplash = FindDescendant(armVariations, "Arm Panel (Green)");
            TextMeshProUGUI whiplashName = GetTextMeshProUGUI(FindDescendant(whiplash, "Variation Name"));
            whiplashName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

            GameObject whiplashWindow = FindDescendant(armWindow, "Arm Info (Green)", "Panel");
            TextMeshProUGUI whiplashWindowTitle = GetTextMeshProUGUI(FindDescendant(whiplashWindow.transform.parent.gameObject, "Title"));
            whiplashWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;
            TextMeshProUGUI whiplashWindowName = GetTextMeshProUGUI(FindDescendant(whiplashWindow, "Name"));
            whiplashWindowName.enableAutoSizing = true;
            whiplashWindowName.fontSizeMax = whiplashWindowName.fontSize;
            whiplashWindowName.fontSizeMin = 0f;
            whiplashWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplash;

            TextMeshProUGUI whiplashWindowDescription = GetTextMeshProUGUI(FindDescendant(whiplashWindow, "Description"));
            whiplashWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
                + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2;
            
            TextMeshProUGUI whiplashWindowDescriptionBack = GetTextMeshProUGUI(FindDescendant(whiplashWindow, "Back Button", "Text"));
            whiplashWindowDescriptionBack.text = LanguageManager.CurrentLanguage.shop.shop_back;

            //it's "???" and placeholders so comment it for future
            /*//Gold arm (under construction)
            GameObject goldArm = FindDescendant(armVariations, "Arm Panel (Gold)");
            TextMeshProUGUI goldArmUnderConstruction = GetTextMeshProUGUI(FindDescendant(goldArm, "Variation Name"));
            goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.shop.shop_armGold;

            GameObject goldArmWindow = FindDescendant(FindDescendant(armWindow, "Arm Info (Green)"), "Panel");
            TextMeshProUGUI goldArmWindowTitle = GetTextMeshProUGUI(FindDescendant(goldArmWindow.transform.parent.gameObject, "Title"));
            goldArmWindowTitle.text = LanguageManager.CurrentLanguage.shop.shop_armGold;
            TextMeshProUGUI goldArmWindowName = GetTextMeshProUGUI(FindDescendant(goldArmWindow, "Name"));
            goldArmWindowName.enableAutoSizing = true;
            goldArmWindowName.fontSizeMax = goldArmWindowName.fontSize;
            goldArmWindowName.fontSizeMin = 0f;
            goldArmWindowName.text = LanguageManager.CurrentLanguage.shop.shop_armGold;

            TextMeshProUGUI goldArmWindowDescription = GetTextMeshProUGUI(FindDescendant(goldArmWindow, "Description"));
            goldArmWindowDescription.text = LanguageManager.CurrentLanguage.shop.shop_armGoldDescription;
            */

            //Usually it's VariationInfo's job but it disabled in gold arm so
            try
            {
                GameObject goldArm = FindDescendant(armVariations, "Arm Panel (Gold)");
                TextMeshProUGUI goldArmUnderConstruction = GetTextMeshProUGUI(FindDescendant(goldArm, "Purchase Status"));
                goldArmUnderConstruction.text = LanguageManager.CurrentLanguage.misc.weapons_underConstruction;

            }
            catch (Exception e)
            {
                Logging.Warn("An error occured while patching gold arm's under construction text.");
                Logging.Warn(e.ToString());
            }

        }
        catch (Exception e)
        {
            Logging.Error("An error occured while translating shop weapons texts.");
            Logging.Error(e.ToString());
        }
            
    }

    public static void PatchShopRefactor(GameObject shopObject)
    {
        PatchShopFrontEnd(shopObject);
        PatchWeapons(shopObject);
    }
    
}
