using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
        if (!tipDescription.text.Contains("V-Rank"))
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
        GameObject shopWeaponsObject = FindDescendant(shopObject, "Background", "Main Panel", "Weapons");

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weapons, path: ["Weapons Panel", "Menu Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Weapons Panel", "Buttons", "BackButton", "Text"]);

        if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("maranara_project_prophet") ||
            BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("plonk.straymode"))
            return;

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver, path: ["Weapons Panel", "Buttons", "RevolverButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun, path: ["Weapons Panel", "Buttons", "ShotgunButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun, path: ["Weapons Panel", "Buttons", "NailgunButton", "Text"]);

        //Slight problem - not all the text fits in the box.
        //The longer text is, the more we'll need to reduce the font size to compensate.
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon, path: ["Weapons Panel", "Buttons", "RailcannonButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher, path: ["Weapons Panel", "Buttons", "RocketLauncherButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsArms, path: ["Weapons Panel", "Buttons", "ArmButton", "Text"]);

        // Revolver
        // Piercer(Blue)
        // Marksman(Green)
        // Sharpshooter(Red)

        //Revolver window and descriptions
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver, path: ["Revolver Window", "Variation Screen", "Title"]);

        //Piercer
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPiercer, path: ["Revolver Window", "Variation Screen", "Variations", "Variation Panel (Blue)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPiercer, path: ["Revolver Window", "Variation Info (Blue)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPiercer, path: ["Revolver Window", "Variation Info (Blue)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_revolverPiercerDescription2,
            path: ["Revolver Window", "Variation Info (Blue)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Revolver Window", "Variation Info (Blue)", "Panel", "Back Button", "Text"]);

        //Marksman
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverMarksman, path: ["Revolver Window", "Variation Screen", "Variations", "Variation Panel (Green)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverMarksman, path: ["Revolver Window", "Variation Info (Green)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverMarksman, path: ["Revolver Window", "Variation Info (Green)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription2 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_revolverMarksmanDescription3,
            path: ["Revolver Window", "Variation Info (Green)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Revolver Window", "Variation Info (Green)", "Panel", "Back Button", "Text"]);

        //Sharpshooter
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter, path: ["Revolver Window", "Variation Screen", "Variations", "Variation Panel (Red)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter, path: ["Revolver Window", "Variation Info (Red)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooter, path: ["Revolver Window", "Variation Info (Red)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_revolverSharpshooterDescription2 + "\n\n",
            path: ["Revolver Window", "Variation Info (Red)", "Panel", "Description"]);
        //just in case.
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Revolver Window", "Variation Info (Red)", "Panel", "Back Button", "Text"]);

        //Revolver info & color tabs
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponInfo, path: ["Revolver Window", "Variation Screen", "Variations", "Info and Color Panel", "InfoButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponColors, path: ["Revolver Window", "Variation Screen", "Variations", "Info and Color Panel", "ColorButton", "Text"]);

        //Revolver lore
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRevolverInfo, path: ["Revolver Window", "Info Screen", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver, path: ["Revolver Window", "Info Screen", "Main Window", "Name"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(
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
            + LanguageManager.CurrentLanguage.shop.shop_loreRevolver10,
            path: ["Revolver Window", "Info Screen", "Main Window", "Scroll View", "Viewport", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Revolver Window", "Info Screen", "Main Window", "Back Button", "Text"]);

        //Revolver preset colors
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRevolverColors, path: ["Revolver Window", "Color Screen", "Title"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPreset1, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Presets", "Template 1", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPreset2, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Presets", "Template 2", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPreset3, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Presets", "Template 3", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPreset4, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Presets", "Template 4", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_revolverPreset5, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Presets", "Template 5", "Text"]);

        /*  Patch GunColorTypeGetter.ToggleAlternate() instead
        TextMeshProUGUI revolverColorSwitchToAlternative = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(revolverColorWindow, "Standard"),"AlternateButton"),"Text"));
        revolverColorSwitchToAlternative.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;

        TextMeshProUGUI revolverColorSwitchToStandard = GetTextMeshProUGUI(FindDescendant(FindDescendant(FindDescendant(revolverColorWindow, "Alternate"), "AlternateButton"), "Text"));
        revolverColorSwitchToStandard.text = LanguageManager.CurrentLanguage.shop.shop_colorsAlternative;
        */

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsPreset, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Type Selection", "Preset Button", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustom, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Type Selection", "Custom Button", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsDone, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Done", "Text"]);

        //Revolver custom color unlock prompt
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRevolver, path: ["Revolver Window", "Color Screen", "Main Window", "Window", "Custom", "Locked", "Text"]);

        // SHOTGUN
        // Core Eject(Blue)
        // Pump Charge(Green)
        // Sawed-On(Red)

        //Shotgun window and descriptions
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun, path: ["Shotgun Window", "Variation Screen", "Title"]);

        //Core Eject
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject, path: ["Shotgun Window", "Variation Screen", "Variations", "Variation Panel (Blue)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject, path: ["Shotgun Window", "Variation Info (Blue)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEject, path: ["Shotgun Window", "Variation Info (Blue)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription2 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_shotgunCoreEjectDescription3,
            path: ["Shotgun Window", "Variation Info (Blue)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Shotgun Window", "Variation Info (Blue)", "Panel", "Back Button", "Text"]);

        //Pump Charge
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge, path: ["Shotgun Window", "Variation Screen", "Variations", "Variation Panel (Green)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge, path: ["Shotgun Window", "Variation Info (Green)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPumpCharge, path: ["Shotgun Window", "Variation Info (Green)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_shotgunPumpChargeDescription2,
            path: ["Shotgun Window", "Variation Info (Green)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Shotgun Window", "Variation Info (Green)", "Panel", "Back Button", "Text"]);

        //Sawed-On
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn, path: ["Shotgun Window", "Variation Screen", "Variations", "Variation Panel (Red)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn, path: ["Shotgun Window", "Variation Info (Red)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOn, path: ["Shotgun Window", "Variation Info (Red)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription2 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_shotgunSawedOnDescription3,
            path: ["Shotgun Window", "Variation Info (Red)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Shotgun Window", "Variation Info (Red)", "Panel", "Back Button", "Text"]);

        //Shotgun info & color tabs
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponInfo, path: ["Shotgun Window", "Variation Screen", "Variations", "Info and Color Panel", "InfoButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponColors, path: ["Shotgun Window", "Variation Screen", "Variations", "Info and Color Panel", "ColorButton", "Text"]);

        //Shotgun lore
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsShotgunInfo, path: ["Shotgun Window", "Info Screen", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun, path: ["Shotgun Window", "Info Screen", "Main Window", "Name"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(
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
            + LanguageManager.CurrentLanguage.shop.shop_loreShotgun9,
            path: ["Shotgun Window", "Info Screen", "Main Window", "Scroll View", "Viewport", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Shotgun Window", "Info Screen", "Main Window", "Back Button", "Text"]);

        //Shotgun preset colors
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsShotgunColors, path: ["Shotgun Window", "Color Screen", "Title"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPreset1, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 1", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPreset2, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 2", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPreset3, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 3", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPreset4, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 4", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_shotgunPreset5, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 5", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsPreset, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Type Selection", "Preset Button", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustom, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Type Selection", "Custom Button", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsDone, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Done", "Text"]);

        //shotgun custom color unlock prompt
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsShotgun, path: ["Shotgun Window", "Color Screen", "Main Window", "Window", "Custom", "Locked", "Text"]);

        // Nailgun
        // Attractor(Blue)
        // Overheat(Green)
        // Jumpstart(Red)

        //Nailgun window and descriptions
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun, path: ["Nailgun Window", "Variation Screen", "Title"]);

        //Attractor
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet, path: ["Nailgun Window", "Variation Screen", "Variations", "Variation Panel (Blue)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet, path: ["Nailgun Window", "Variation Info (Blue)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunMagnet, path: ["Nailgun Window", "Variation Info (Blue)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_nailgunMagnetDescription2,
            path: ["Nailgun Window", "Variation Info (Blue)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Nailgun Window", "Variation Info (Blue)", "Panel", "Back Button", "Text"]);

        //Overheat
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat, path: ["Nailgun Window", "Variation Screen", "Variations", "Variation Panel (Green)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat, path: ["Nailgun Window", "Variation Info (Green)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunOverheat, path: ["Nailgun Window", "Variation Info (Green)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_nailgunOverheatDescription2,
            path: ["Nailgun Window", "Variation Info (Green)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Nailgun Window", "Variation Info (Green)", "Panel", "Back Button", "Text"]);

        //Jumpstarter
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart, path: ["Nailgun Window", "Variation Screen", "Variations", "Variation Panel (Red)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart, path: ["Nailgun Window", "Variation Info (Red)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStart, path: ["Nailgun Window", "Variation Info (Red)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_nailgunJumpStartDescription2,
            path: ["Nailgun Window", "Variation Info (Red)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Nailgun Window", "Variation Info (Red)", "Panel", "Back Button", "Text"]);

        //Nailgun info & color tabs
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponInfo, path: ["Nailgun Window", "Variation Screen", "Variations", "Info and Color Panel", "InfoButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponColors, path: ["Nailgun Window", "Variation Screen", "Variations", "Info and Color Panel", "ColorButton", "Text"]);

        //Nailgun lore
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsNailgunInfo, path: ["Nailgun Window", "Info Screen", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun, path: ["Nailgun Window", "Info Screen", "Main Window", "Name"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(
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
            + LanguageManager.CurrentLanguage.shop.shop_loreNailgun9,
            path: ["Nailgun Window", "Info Screen", "Main Window", "Scroll View", "Viewport", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Nailgun Window", "Info Screen", "Main Window", "Back Button", "Text"]);

        //nailgun preset colors
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsNailgunColors, path: ["Nailgun Window", "Color Screen", "Title"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunPreset1, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 1", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunPreset2, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 2", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunPreset3, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 3", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunPreset4, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 4", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_nailgunPreset5, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Presets", "Template 5", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsPreset, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Type Selection", "Preset Button", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustom, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Type Selection", "Custom Button", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsDone, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Done", "Text"]);

        //nailgun custom color unlock prompt
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsNailgun, path: ["Nailgun Window", "Color Screen", "Main Window", "Window", "Custom", "Locked", "Text"]);

        // Railcannon
        // Electric(Blue)
        // Screwdriver(Green)
        // Malicious(Red)

        //Railcannon window and descriptions
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon, path: ["Railcannon Window", "Variation Screen", "Title"]);

        //Electric
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonElectric, path: ["Railcannon Window", "Variation Screen", "Variations", "Variation Panel (Blue)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonElectric, path: ["Railcannon Window", "Variation Info (Blue)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonElectric, path: ["Railcannon Window", "Variation Info (Blue)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription2 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_railcannonElectricDescription3,
            path: ["Railcannon Window", "Variation Info (Blue)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Railcannon Window", "Variation Info (Blue)", "Panel", "Back Button", "Text"]);

        //Screwdriver
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver, path: ["Railcannon Window", "Variation Screen", "Variations", "Variation Panel (Green)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver, path: ["Railcannon Window", "Variation Info (Green)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriver, path: ["Railcannon Window", "Variation Info (Green)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_railcannonScrewdriverDescription2,
            path: ["Railcannon Window", "Variation Info (Green)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Railcannon Window", "Variation Info (Green)", "Panel", "Back Button", "Text"]);

        //Malicious
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious, path: ["Railcannon Window", "Variation Screen", "Variations", "Variation Panel (Red)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious, path: ["Railcannon Window", "Variation Info (Red)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonMalicious, path: ["Railcannon Window", "Variation Info (Red)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_railcannonMaliciousDescription2,
            path: ["Railcannon Window", "Variation Info (Red)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Railcannon Window", "Variation Info (Red)", "Panel", "Back Button", "Text"]);

        //Railcannon info & color tabs
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponInfo, path: ["Railcannon Window", "Variation Screen", "Variations", "Info and Color Panel", "InfoButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponColors, path: ["Railcannon Window", "Variation Screen", "Variations", "Info and Color Panel", "ColorButton", "Text"]);

        //Railcannon lore
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannonInfo, path: ["Railcannon Window", "Info Screen", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon, path: ["Railcannon Window", "Info Screen", "Main Window", "Name"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(
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
            + LanguageManager.CurrentLanguage.shop.shop_loreRailcannon9,
            path: ["Railcannon Window", "Info Screen", "Main Window", "Scroll View", "Viewport", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Railcannon Window", "Info Screen", "Main Window", "Back Button", "Text"]);

        //Railcannon preset colors
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannonColors, path: ["Railcannon Window", "Color Screen", "Title"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonPreset1, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Presets", "Template 1", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonPreset2, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Presets", "Template 2", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonPreset3, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Presets", "Template 3", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonPreset4, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Presets", "Template 4", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_railcannonPreset5, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Presets", "Template 5", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsPreset, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Type Selection", "Preset Button", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustom, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Type Selection", "Custom Button", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsDone, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Done", "Text"]);

        //railcannon custom color unlock prompt
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRailcannon, path: ["Railcannon Window", "Color Screen", "Main Window", "Window", "Custom", "Locked", "Text"]);

        // Rocket Launcher
        // Freezeframe(Blue)
        // S.R.S Cannon(Green)
        // Firestarter(Red)

        //Rocket launcher window & descriptions
        //Rocket launcher window & descriptions
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher, path: ["Rocket Launcher Window", "Variation Screen", "Title"]);

        //Freezeframe
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze, path: ["Rocket Launcher Window", "Variation Screen", "Variations", "Variation Panel (Blue)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze, path: ["Rocket Launcher Window", "Variation Info (Blue)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreeze, path: ["Rocket Launcher Window", "Variation Info (Blue)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFreezeDescription2,
            path: ["Rocket Launcher Window", "Variation Info (Blue)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Rocket Launcher Window", "Variation Info (Blue)", "Panel", "Back Button", "Text"]);

        //Rocket Launcher green variation
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon, path: ["Rocket Launcher Window", "Variation Screen", "Variations", "Variation Panel (Green)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon, path: ["Rocket Launcher Window", "Variation Info (Green)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannon, path: ["Rocket Launcher Window", "Variation Info (Green)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription2 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_rocketLauncherSrsCannonDescription3,
            path: ["Rocket Launcher Window", "Variation Info (Green)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Rocket Launcher Window", "Variation Info (Green)", "Panel", "Back Button", "Text"]);

        //Firestarter a.k.a Gasoline
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter, path: ["Rocket Launcher Window", "Variation Screen", "Variations", "Variation Panel (Red)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter, path: ["Rocket Launcher Window", "Variation Info (Red)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarter, path: ["Rocket Launcher Window", "Variation Info (Red)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_rocketLauncherFireStarterDescription2,
            path: ["Rocket Launcher Window", "Variation Info (Red)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Rocket Launcher Window", "Variation Info (Red)", "Panel", "Back Button", "Text"]);

        //Rocket launcher info & color tabs
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponInfo, path: ["Rocket Launcher Window", "Variation Screen", "Variations", "Info and Color Panel", "InfoButton", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponColors, path: ["Rocket Launcher Window", "Variation Screen", "Variations", "Info and Color Panel", "ColorButton", "Text"]);

        //RocketLauncher lore
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncherInfo, path: ["Rocket Launcher Window", "Info Screen", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher, path: ["Rocket Launcher Window", "Info Screen", "Main Window", "Name"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(
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
            + LanguageManager.CurrentLanguage.shop.shop_loreRocketLauncher16,
            path: ["Rocket Launcher Window", "Info Screen", "Main Window", "Scroll View", "Viewport", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Rocket Launcher Window", "Info Screen", "Main Window", "Back Button", "Text"]);

        //RocketLauncher preset colors
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncherColors, path: ["Rocket Launcher Window", "Color Screen", "Title"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset1, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Presets", "Template 1", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset2, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Presets", "Template 2", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset3, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Presets", "Template 3", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset4, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Presets", "Template 4", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_rocketlauncherPreset5, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Presets", "Template 5", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsPreset, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Type Selection", "Preset Button", "Text"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustom, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Type Selection", "Custom Button", "Text"]);

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsDone, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Done", "Text"]);

        //rocketlauncher custom color unlock prompt
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsCustomUnlockPrompt + " " + LanguageManager.CurrentLanguage.shop.shop_weaponsRocketLauncher, path: ["Rocket Launcher Window", "Color Screen", "Main Window", "Window", "Custom", "Locked", "Text"]);
        // Arm
        // Feedbacker(Blue)
        // Knuckleblaster(Red)
        // Whiplash(Green)
        // ???(Yellow)

        //Arm window and descriptions
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weaponsArms, path: ["Arm Window", "Variation Screen", "Title"]);

        //Feedbacker
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armFeedbacker, path: ["Arm Window", "Variation Screen", "Variations", "Arm Panel (Blue)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armFeedbacker, path: ["Arm Window", "Arm Info (Blue)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armFeedbacker, path: ["Arm Window", "Arm Info (Blue)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_armFeedbackerDescription2,
            path: ["Arm Window", "Arm Info (Blue)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Arm Window", "Arm Info (Blue)", "Panel", "Back Button", "Text"]);

        //Knuckleblaster
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster, path: ["Arm Window", "Variation Screen", "Variations", "Arm Panel (Red)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster, path: ["Arm Window", "Arm Info (Red)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armKnuckleblaster, path: ["Arm Window", "Arm Info (Red)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_armKnuckleblasterDescription2,
            path: ["Arm Window", "Arm Info (Red)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Arm Window", "Arm Info (Red)", "Panel", "Back Button", "Text"]);

        //Whiplash
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armWhiplash, path: ["Arm Window", "Variation Screen", "Variations", "Arm Panel (Green)", "Variation Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armWhiplash, path: ["Arm Window", "Arm Info (Green)", "Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_armWhiplash, path: ["Arm Window", "Arm Info (Green)", "Panel", "Name"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(
            LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription1 + "\n\n"
            + LanguageManager.CurrentLanguage.shop.shop_armWhiplashDescription2,
            path: ["Arm Window", "Arm Info (Green)", "Panel", "Description"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Arm Window", "Arm Info (Green)", "Panel", "Back Button", "Text"]);

        //Gold arm (under construction) - Purchase Status shows "under construction" instead of a name
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.misc.weapons_underConstruction, path: ["Arm Window", "Variation Screen", "Variations", "Arm Panel (Gold)", "Purchase Status"]);
}

    public static void PatchShopRefactor(GameObject shopObject)
    {
        PatchShopFrontEnd(shopObject);
        PatchWeapons(shopObject);
    }
    
}
