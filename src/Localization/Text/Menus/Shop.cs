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
        var shopPanel = FindDescendant(shopObject, "Background", "Main Panel");

        //Tip panel
        shopPanel.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_tipofthedayTitle, path: ["Tip of the Day", "Title"]);

        // Tip text: feed its current value to GetLevelTip (unless it's a V-Rank tip).
        var tipDescription = GetTextMeshProUGUI(FindDescendant(shopPanel, "Tip of the Day", "Panel", "Text Inset", "TipText"));
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
        var shopWeaponsObject = FindDescendant(shopObject, "Background", "Main Panel", "Weapons");

        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_weapons, path: ["Weapons Panel", "Menu Title"]);
        shopWeaponsObject.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_back, path: ["Weapons Panel", "Buttons", "BackButton", "Text"]);

        if (BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("maranara_project_prophet") ||
            BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("plonk.straymode"))
            return;

        foreach (var w in ShopWeapons)
            PatchWeapon(shopWeaponsObject, w);

        // Arm
        PatchArm(shopWeaponsObject);
    }

    public static void PatchShopRefactor(GameObject shopObject)
    {
        PatchShopFrontEnd(shopObject);
        PatchWeapons(shopObject);
    }

    private static void PatchWeapon(GameObject root, WeaponData w)
    {
        var t = LanguageManager.CurrentLanguage;

        root.Localize<TextMeshProUGUI>(w.Title(t), path: ["Weapons Panel", "Buttons", w.Button, "Text"]);
        root.Localize<TextMeshProUGUI>(w.Title(t), path: [w.Window, "Variation Screen", "Title"]);

        foreach (var (color, name, description) in w.Variations)
        {
            root.Localize<TextMeshProUGUI>(name(t), path: [w.Window, "Variation Screen", "Variations", $"Variation Panel ({color})", "Variation Name"]).AddUpperCase();
            root.Localize<TextMeshProUGUI>(name(t), path: [w.Window, $"Variation Info ({color})", "Title"]);
            root.Localize<TextMeshProUGUI>(name(t), path: [w.Window, $"Variation Info ({color})", "Panel", "Name"]).AddUpperCase();
            root.Localize<TextMeshProUGUI>(description(t), path: [w.Window, $"Variation Info ({color})", "Panel", "Description"]);
            root.Localize<TextMeshProUGUI>(t.shop.shop_back, path: [w.Window, $"Variation Info ({color})", "Panel", "Back Button", "Text"]);
        }

        // info & color tabs (shared across weapons)
        root.Localize<TextMeshProUGUI>(t.shop.shop_weaponInfo, path: [w.Window, "Variation Screen", "Variations", "Info and Color Panel", "InfoButton", "Text"]);
        root.Localize<TextMeshProUGUI>(t.shop.shop_weaponColors, path: [w.Window, "Variation Screen", "Variations", "Info and Color Panel", "ColorButton", "Text"]);

        // lore
        root.Localize<TextMeshProUGUI>(w.InfoTitle(t), path: [w.Window, "Info Screen", "Title"]);
        root.Localize<TextMeshProUGUI>(w.Title(t), path: [w.Window, "Info Screen", "Main Window", "Name"]);
        root.Localize<TextMeshProUGUI>(w.Lore(t), path: [w.Window, "Info Screen", "Main Window", "Scroll View", "Viewport", "Text"]);
        root.Localize<TextMeshProUGUI>(t.shop.shop_back, path: [w.Window, "Info Screen", "Main Window", "Back Button", "Text"]);

        // preset colors
        root.Localize<TextMeshProUGUI>(w.ColorsTitle(t), path: [w.Window, "Color Screen", "Title"]);
        for (int i = 0; i < w.Presets.Length; i++)
            root.Localize<TextMeshProUGUI>(w.Presets[i](t), path: [w.Window, "Color Screen", "Main Window", "Window", "Presets", $"Template {i + 1}", "Text"]);

        // This part should not be blocked when add compability with ohter mods
        root.Localize<TextMeshProUGUI>(t.shop.shop_colorsPreset, path: [w.Window, "Color Screen", "Main Window", "Window", "Type Selection", "Preset Button", "Text"]);
        root.Localize<TextMeshProUGUI>(t.shop.shop_colorsCustom, path: [w.Window, "Color Screen", "Main Window", "Window", "Type Selection", "Custom Button", "Text"]);
        root.Localize<TextMeshProUGUI>(t.shop.shop_colorsDone, path: [w.Window, "Color Screen", "Main Window", "Window", "Done", "Text"]);
        root.Localize<TextMeshProUGUI>(t.shop.shop_colorsCustomUnlockPrompt + " " + w.Title(t), path: [w.Window, "Color Screen", "Main Window", "Window", "Custom", "Locked", "Text"]);
    }

    private static void PatchArm(GameObject root)
    {
        var t = LanguageManager.CurrentLanguage;

        root.Localize<TextMeshProUGUI>(t.shop.shop_weaponsArms, path: ["Weapons Panel", "Buttons", "ArmButton", "Text"]);
        root.Localize<TextMeshProUGUI>(t.shop.shop_weaponsArms, path: ["Arm Window", "Variation Screen", "Title"]);

        (string Color, string Field, Func<JsonFormat, string> Description)[] arms =
        {
            ("Blue", t.shop.shop_armFeedbacker, t => t.shop.shop_armFeedbackerDescription1 + "\n\n" + t.shop.shop_armFeedbackerDescription2),
            ("Red", t.shop.shop_armKnuckleblaster, t => t.shop.shop_armKnuckleblasterDescription1 + "\n\n" + t.shop.shop_armKnuckleblasterDescription2),
            ("Green", t.shop.shop_armWhiplash, t => t.shop.shop_armWhiplashDescription1 + "\n\n" + t.shop.shop_armWhiplashDescription2),
        };

        foreach (var (color, field, desc) in arms)
        {
            root.Localize<TextMeshProUGUI>(field, path: ["Arm Window", "Variation Screen", "Variations", $"Arm Panel ({color})", "Variation Name"]).AddUpperCase();
            root.Localize<TextMeshProUGUI>(field, path: ["Arm Window", $"Arm Info ({color})", "Title"]);
            root.Localize<TextMeshProUGUI>(field, path: ["Arm Window", $"Arm Info ({color})", "Panel", "Name"]).AddUpperCase();
            root.Localize<TextMeshProUGUI>(desc(t), path: ["Arm Window", $"Arm Info ({color})", "Panel", "Description"]);
            root.Localize<TextMeshProUGUI>(t.shop.shop_back, path: ["Arm Window", $"Arm Info ({color})", "Panel", "Back Button", "Text"]);
        }

        // Gold arm (under construction) - Purchase Status shows "under construction"
        root.Localize<TextMeshProUGUI>(t.misc.weapons_underConstruction, path: ["Arm Window", "Variation Screen", "Variations", "Arm Panel (Gold)", "Purchase Status"]);
    }

    private static readonly WeaponData[] ShopWeapons =
    {
        new()
        {
            Window = "Revolver Window",
            Button = "RevolverButton",
            Title = t => t.shop.shop_weaponsRevolver,
            InfoTitle = t => t.shop.shop_weaponsRevolverInfo,
            ColorsTitle = t => t.shop.shop_weaponsRevolverColors,
            Variations =
            [
                ("Blue", t => t.shop.shop_revolverPiercer,
                    t => t.shop.shop_revolverPiercerDescription1 + "\n\n" + t.shop.shop_revolverPiercerDescription2),
                ("Green", t => t.shop.shop_revolverMarksman,
                    t => t.shop.shop_revolverMarksmanDescription1 + "\n\n" + t.shop.shop_revolverMarksmanDescription2 + "\n\n" + t.shop.shop_revolverMarksmanDescription3),
                ("Red", t => t.shop.shop_revolverSharpshooter,
                    t => t.shop.shop_revolverSharpshooterDescription1 + "\n\n" + t.shop.shop_revolverSharpshooterDescription2 + "\n\n"),
            ],
            Lore = t => "<color=#FF4343>" + t.shop.shop_data + "</color>\n"
                + t.shop.shop_loreRevolver1 + "\n\n"
                + t.shop.shop_loreRevolver2 + "\n\n"
                + t.shop.shop_loreRevolver3 + "\n\n"
                + t.shop.shop_loreRevolver4 + "\n\n"
                + t.shop.shop_loreRevolver5 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_strategy + "</color>\n"
                + t.shop.shop_loreRevolver6 + "\n\n"
                + t.shop.shop_loreRevolver7 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_advancedStrategy + "</color>\n"
                + t.shop.shop_loreRevolver8 + "\n\n"
                + t.shop.shop_loreRevolver9 + "\n\n"
                + t.shop.shop_loreRevolver10,
            Presets =
            [
                t => t.shop.shop_revolverPreset1, t => t.shop.shop_revolverPreset2, t => t.shop.shop_revolverPreset3,
                t => t.shop.shop_revolverPreset4, t => t.shop.shop_revolverPreset5,
            ],
        },
        new()
        {
            Window = "Shotgun Window",
            Button = "ShotgunButton",
            Title = t => t.shop.shop_weaponsShotgun,
            InfoTitle = t => t.shop.shop_weaponsShotgunInfo,
            ColorsTitle = t => t.shop.shop_weaponsShotgunColors,
            Variations =
            [
                ("Blue", t => t.shop.shop_shotgunCoreEject,
                    t => t.shop.shop_shotgunCoreEjectDescription1 + "\n\n" + t.shop.shop_shotgunCoreEjectDescription2 + "\n\n" + t.shop.shop_shotgunCoreEjectDescription3),
                ("Green", t => t.shop.shop_shotgunPumpCharge,
                    t => t.shop.shop_shotgunPumpChargeDescription1 + "\n\n" + t.shop.shop_shotgunPumpChargeDescription2),
                ("Red", t => t.shop.shop_shotgunSawedOn,
                    t => t.shop.shop_shotgunSawedOnDescription1 + "\n\n" + t.shop.shop_shotgunSawedOnDescription2 + "\n\n" + t.shop.shop_shotgunSawedOnDescription3),
            ],
            Lore = t => "<color=#FF4343>" + t.shop.shop_data + "</color>\n"
                + t.shop.shop_loreShotgun1 + "\n\n"
                + t.shop.shop_loreShotgun2 + "\n\n"
                + t.shop.shop_loreShotgun3 + "\n\n"
                + t.shop.shop_loreShotgun4 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_strategy + "</color>\n"
                + t.shop.shop_loreShotgun5 + "\n\n"
                + t.shop.shop_loreShotgun6 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_advancedStrategy + "</color>\n"
                + t.shop.shop_loreShotgun7 + "\n\n"
                + t.shop.shop_loreShotgun8 + "\n\n"
                + t.shop.shop_loreShotgun9,
            Presets =
            [
                t => t.shop.shop_shotgunPreset1, t => t.shop.shop_shotgunPreset2, t => t.shop.shop_shotgunPreset3,
                t => t.shop.shop_shotgunPreset4, t => t.shop.shop_shotgunPreset5,
            ],
        },
        new()
        {
            Window = "Nailgun Window",
            Button = "NailgunButton",
            Title = t => t.shop.shop_weaponsNailgun,
            InfoTitle = t => t.shop.shop_weaponsNailgunInfo,
            ColorsTitle = t => t.shop.shop_weaponsNailgunColors,
            Variations =
            [
                ("Blue", t => t.shop.shop_nailgunMagnet,
                    t => t.shop.shop_nailgunMagnetDescription1 + "\n\n" + t.shop.shop_nailgunMagnetDescription2),
                ("Green", t => t.shop.shop_nailgunOverheat,
                    t => t.shop.shop_nailgunOverheatDescription1 + "\n\n" + t.shop.shop_nailgunOverheatDescription2),
                ("Red", t => t.shop.shop_nailgunJumpStart,
                    t => t.shop.shop_nailgunJumpStartDescription1 + "\n\n" + t.shop.shop_nailgunJumpStartDescription2),
            ],
            Lore = t => "<color=#FF4343>" + t.shop.shop_data + "</color>\n"
                + t.shop.shop_loreNailgun1 + "\n\n"
                + t.shop.shop_loreNailgun2 + "\n\n"
                + t.shop.shop_loreNailgun3 + "\n\n"
                + t.shop.shop_loreNailgun4 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_strategy + "</color>\n"
                + t.shop.shop_loreNailgun5 + "\n\n"
                + t.shop.shop_loreNailgun6 + "\n\n"
                + t.shop.shop_loreNailgun7 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_advancedStrategy + "</color>\n"
                + t.shop.shop_loreNailgun8 + "\n\n"
                + t.shop.shop_loreNailgun9,
            Presets =
            [
                t => t.shop.shop_nailgunPreset1, t => t.shop.shop_nailgunPreset2, t => t.shop.shop_nailgunPreset3,
                t => t.shop.shop_nailgunPreset4, t => t.shop.shop_nailgunPreset5,
            ],
        },
        new()
        {
            Window = "Railcannon Window",
            Button = "RailcannonButton",
            Title = t => t.shop.shop_weaponsRailcannon,
            InfoTitle = t => t.shop.shop_weaponsRailcannonInfo,
            ColorsTitle = t => t.shop.shop_weaponsRailcannonColors,
            Variations =
            [
                ("Blue", t => t.shop.shop_railcannonElectric,
                    t => t.shop.shop_railcannonElectricDescription1 + "\n\n" + t.shop.shop_railcannonElectricDescription2 + "\n\n" + t.shop.shop_railcannonElectricDescription3),
                ("Green", t => t.shop.shop_railcannonScrewdriver,
                    t => t.shop.shop_railcannonScrewdriverDescription1 + "\n\n" + t.shop.shop_railcannonScrewdriverDescription2),
                ("Red", t => t.shop.shop_railcannonMalicious,
                    t => t.shop.shop_railcannonMaliciousDescription1 + "\n\n" + t.shop.shop_railcannonMaliciousDescription2),
            ],
            Lore = t => "<color=#FF4343>" + t.shop.shop_data + "</color>\n"
                + t.shop.shop_loreRailcannon1 + "\n\n"
                + t.shop.shop_loreRailcannon2 + "\n\n"
                + t.shop.shop_loreRailcannon3 + "\n\n"
                + t.shop.shop_loreRailcannon4 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_strategy + "</color>\n"
                + t.shop.shop_loreRailcannon5 + "\n\n"
                + t.shop.shop_loreRailcannon6 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_advancedStrategy + "</color>\n"
                + t.shop.shop_loreRailcannon7 + "\n\n"
                + t.shop.shop_loreRailcannon8 + "\n\n"
                + t.shop.shop_loreRailcannon9,
            Presets =
            [
                t => t.shop.shop_railcannonPreset1, t => t.shop.shop_railcannonPreset2, t => t.shop.shop_railcannonPreset3,
                t => t.shop.shop_railcannonPreset4, t => t.shop.shop_railcannonPreset5,
            ],
        },
        new()
        {
            Window = "Rocket Launcher Window",
            Button = "RocketLauncherButton",
            Title = t => t.shop.shop_weaponsRocketLauncher,
            InfoTitle = t => t.shop.shop_weaponsRocketLauncherInfo,
            ColorsTitle = t => t.shop.shop_weaponsRocketLauncherColors,
            Variations =
            [
                ("Blue", t => t.shop.shop_rocketLauncherFreeze,
                    t => t.shop.shop_rocketLauncherFreezeDescription1 + "\n\n" + t.shop.shop_rocketLauncherFreezeDescription2),
                ("Green", t => t.shop.shop_rocketLauncherSrsCannon,
                    t => t.shop.shop_rocketLauncherSrsCannonDescription1 + "\n\n" + t.shop.shop_rocketLauncherSrsCannonDescription2 + "\n\n" + t.shop.shop_rocketLauncherSrsCannonDescription3),
                ("Red", t => t.shop.shop_rocketLauncherFireStarter,
                    t => t.shop.shop_rocketLauncherFireStarterDescription1 + "\n\n" + t.shop.shop_rocketLauncherFireStarterDescription2),
            ],
            Lore = t => "<color=#FF4343>" + t.shop.shop_data + "</color>\n"
                + t.shop.shop_loreRocketLauncher1 + "\n\n"
                + t.shop.shop_loreRocketLauncher2 + "\n\n"
                + t.shop.shop_loreRocketLauncher3 + "\n\n"
                + t.shop.shop_loreRocketLauncher4 + "\n\n"
                + t.shop.shop_loreRocketLauncher5 + "\n\n"
                + t.shop.shop_loreRocketLauncher6 + "\n\n"
                + t.shop.shop_loreRocketLauncher7 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_strategy + "</color>\n"
                + t.shop.shop_loreRocketLauncher8 + "\n\n"
                + t.shop.shop_loreRocketLauncher9 + "\n\n"
                + t.shop.shop_loreRocketLauncher10 + "\n\n"
                + t.shop.shop_loreRocketLauncher11 + "\n\n"
                + t.shop.shop_loreRocketLauncher12 + "\n\n"
                + t.shop.shop_loreRocketLauncher13 + "\n\n"
                + "<color=#FF4343>" + t.shop.shop_advancedStrategy + "</color>\n"
                + t.shop.shop_loreRocketLauncher14 + "\n\n"
                + t.shop.shop_loreRocketLauncher15 + "\n\n"
                + t.shop.shop_loreRocketLauncher16,
            Presets =
            [
                t => t.shop.shop_rocketlauncherPreset1, t => t.shop.shop_rocketlauncherPreset2, t => t.shop.shop_rocketlauncherPreset3,
                t => t.shop.shop_rocketlauncherPreset4, t => t.shop.shop_rocketlauncherPreset5,
            ],
        },
    };

    private sealed class WeaponData
    {
        public string Window = "";
        public string Button = "";
        public Func<JsonFormat, string> Title = _ => "";
        public Func<JsonFormat, string> InfoTitle = _ => "";
        public Func<JsonFormat, string> ColorsTitle = _ => "";
        public (string Color, Func<JsonFormat, string> Name, Func<JsonFormat, string> Description)[] Variations = [];
        public Func<JsonFormat, string> Lore = _ => "";
        public Func<JsonFormat, string>[] Presets = [];
    }
    
}
