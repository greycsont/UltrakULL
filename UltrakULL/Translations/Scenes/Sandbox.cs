using TMPro;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.CommonFunctions;
using UltrakULL.json;

namespace UltrakULL;

class Sandbox
{
    private void PatchSandboxDupeMenu(ref GameObject canvasObj)
    {
        GameObject dupeMenu = FindDescendant(canvasObj, "Cheat Menu", "Sandbox Saves");

        TextMeshProUGUI dupeMenuTitle = GetTextMeshProUGUI(FindDescendant(dupeMenu, "Title"));
        dupeMenuTitle.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesTitle;

        TextMeshProUGUI dupeMenuOpenFolder = GetTextMeshProUGUI(FindDescendant(dupeMenu, "Directory Button Wrapper", "Directory Button", "Text"));
        dupeMenuOpenFolder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesOpenFolder;

        TextMeshProUGUI dupeMenuPlaceholder = GetTextMeshProUGUI(FindDescendant(dupeMenu, "Button", "InputField", "Placeholder"));
        dupeMenuPlaceholder.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesSaveNamePrompt;

        TextMeshProUGUI dupeMenuSave = GetTextMeshProUGUI(FindDescendant(dupeMenu, "New Save Wrapper", "Save Button", "Text"));
        dupeMenuSave.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesNewSave;

        GameObject saveOverwriteConfirmPanel = FindDescendant(canvasObj, "SandboxDialogs", "Save Overwrite Confirmation", "Panel");
        TextMeshProUGUI saveOverwriteConfirmText = GetTextMeshProUGUI(FindDescendant(saveOverwriteConfirmPanel, "Text"));
        saveOverwriteConfirmText.text = LanguageManager.CurrentLanguage.cheats.cheats_dupesOverWriteWarn;

        TextMeshProUGUI saveOverwritedisableWindow = GetTextMeshProUGUI(FindDescendant(saveOverwriteConfirmPanel, "Text (1)"));
        saveOverwritedisableWindow.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

        TextMeshProUGUI saveOverwriteCancel = GetTextMeshProUGUI(FindDescendant(saveOverwriteConfirmPanel, "Cancel", "Text"));
        saveOverwriteCancel.text = LanguageManager.CurrentLanguage.cheats.cheats_disclaimerNo;

        TextMeshProUGUI saveOverwriteSave = GetTextMeshProUGUI(FindDescendant(saveOverwriteConfirmPanel, "Confirm", "Text"));
        saveOverwriteSave.text = "<color=orange>" + LanguageManager.CurrentLanguage.cheats.cheats_dupesSave + "</color>";

    }

    private void PatchMisc(ref GameObject canvasObj)
    {
        //text mesh pro out of date
        Text navmeshWarning = GetTextfromGameObject(FindDescendant(canvasObj, "Navmesh Warning", "Text (1)"));
        navmeshWarning.text = LanguageManager.CurrentLanguage.sandbox.sandbox_navmeshWarn;

        //shop
        GameObject sandboxShop = GameObject.Find("Sandbox Shop");

        GameObject sandboxShopCanvas = FindDescendant(sandboxShop, "Canvas", "Background", "Main Panel");

        TextMeshProUGUI sandboxShopStatsTitle = GetTextMeshProUGUI(FindDescendant(sandboxShopCanvas, "Stats", "Title"));
        sandboxShopStatsTitle.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_stats;
        //for wondering, actual stat texts are patched in StatsPatch.cs

        
        //Main menu
        GameObject sandboxShopMenu = FindDescendant(sandboxShopCanvas, "Main Menu", "Buttons");

        TextMeshProUGUI sandboxShopTimeOfDayButton = GetTextMeshProUGUI(FindDescendant(sandboxShopMenu, "TimeOfDayButton", "Text"));
        sandboxShopTimeOfDayButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_timeOfDay;
        
        TextMeshProUGUI sandboxShopWorldOptionsButton = GetTextMeshProUGUI(FindDescendant(sandboxShopMenu, "WorldOptionsButton", "Text"));
        sandboxShopWorldOptionsButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptions;
        
        TextMeshProUGUI sandboxShopIconsButton = GetTextMeshProUGUI(FindDescendant(sandboxShopMenu, "IconsButton", "Text"));
        sandboxShopIconsButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_icons;
        
        //Time of day
        GameObject sandboxShopTimeOfDay = FindDescendant(sandboxShopCanvas, "Time of Day");

        TextMeshProUGUI sandboxShopTimeOfDayTitle =
            GetTextMeshProUGUI(FindDescendant(sandboxShopTimeOfDay, "Title"));
        sandboxShopTimeOfDayTitle.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_timeOfDay;

        TextMeshProUGUI sandboxShopTimeOfDayLoading =
            GetTextMeshProUGUI(FindDescendant(sandboxShopTimeOfDay, "Panel", "Loading", "Title"));
        sandboxShopTimeOfDayLoading.text = LanguageManager.CurrentLanguage.misc.loading;

        TextMeshProUGUI sandboxShopTimeOfDayClose = GetTextMeshProUGUI(FindDescendant(sandboxShopTimeOfDay, "Panel", "Close Button", "Text"));
        sandboxShopTimeOfDayClose.text = LanguageManager.CurrentLanguage.options.save_close;
        
        //World options
        GameObject sandboxShopWorldOptions = FindDescendant(sandboxShopCanvas, "World Options");
        TextMeshProUGUI sandboxShopWorldOptionsTitle = GetTextMeshProUGUI(FindDescendant(sandboxShopWorldOptions, "Title"));
        sandboxShopWorldOptionsTitle.text =
            LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsTitle;
        TextMeshProUGUI sandboxWorldOptionsClose = GetTextMeshProUGUI(FindDescendant(sandboxShopWorldOptions, "Panel", "Close Button","Text"));
        sandboxWorldOptionsClose.text = LanguageManager.CurrentLanguage.options.save_close;
        
        GameObject sandboxShopWorldOptionsMapBorder = FindDescendant(sandboxShopWorldOptions, "Panel", "Options", "Map Border");
        TextMeshProUGUI sandboxShopWorldOptionsMapBorderTitle = GetTextMeshProUGUI(FindDescendant(sandboxShopWorldOptionsMapBorder, "Title Text"));
        sandboxShopWorldOptionsMapBorderTitle.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_mapBorder;

        TextMeshProUGUI sandboxShopWorldOptionsMapBorderStatus = GetTextMeshProUGUI(FindDescendant(sandboxShopWorldOptionsMapBorder, "Status Text"));
        TextMeshProUGUI sandboxShopWorldOptionsMapBorderButton = GetTextMeshProUGUI(FindDescendant(sandboxShopWorldOptionsMapBorder, "Button","Text"));
        switch(sandboxShopWorldOptionsMapBorderStatus.text.ToUpper())
        {
            case "ENABLED":
            {
                sandboxShopWorldOptionsMapBorderStatus.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnabled;
                break;
            }
            case "DISABLED":
            {
                sandboxShopWorldOptionsMapBorderStatus.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisabled;
                break;
            }
        }
        switch (sandboxShopWorldOptionsMapBorderButton.text.ToUpper())
        {
            case "ENABLE":
            {
                sandboxShopWorldOptionsMapBorderButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsEnable;
                break;
            }
            case "DISABLE":
            {
                sandboxShopWorldOptionsMapBorderButton.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_worldOptionsDisable;
                break;
            }
        }

        //Icons
        GameObject sandboxShopIcons = FindDescendant(sandboxShopCanvas, "Icons", "Icons Window", "Panel");
        TextMeshProUGUI sandboxShopIconsTitle = GetTextMeshProUGUI(FindDescendant(sandboxShopIcons.transform.parent.gameObject, "Title"));
        sandboxShopIconsTitle.text =
            LanguageManager.CurrentLanguage.sandbox.sandbox_shop_iconsTitle;
        
        TextMeshProUGUI sandboxShopIconsDefault = GetTextMeshProUGUI(FindDescendant(sandboxShopIcons, "Default", "Text"));
        sandboxShopIconsDefault.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_default;
        
        TextMeshProUGUI sandboxShopIconsPitr = GetTextMeshProUGUI(FindDescendant(sandboxShopIcons, "PITR", "Text"));
        sandboxShopIconsPitr.text = LanguageManager.CurrentLanguage.sandbox.sandbox_shop_pitr;
        
        TextMeshProUGUI sandboxIconsClose = GetTextMeshProUGUI(FindDescendant(sandboxShopCanvas, "Icons", "Back Button", "Text"));
        sandboxIconsClose.text = LanguageManager.CurrentLanguage.shop.shop_back;
    }
    public static void PatchAlterMenu()
    {
        // Sandbox enemy modifier menu

        GameObject panel = FindDescendant(GetInactiveRootObject("Canvas"), "Alter Menu Wrapper", "Sandbox Alter Menu", "Spawning Menu");

        GameObject enemyAlterMenu = FindDescendant(panel, "Scroll View", "Viewport", "Content");

        TextMeshProUGUI enemyAlterMenuTitle = GetTextMeshProUGUI(FindDescendant(enemyAlterMenu, "Header", "Title"));
        enemyAlterMenuTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_title;

        GameObject enemyAlterSizeMenu = FindDescendant(enemyAlterMenu, "Size Options");
        TextMeshProUGUI enemyAlterSizeTitle = GetTextMeshProUGUI(FindDescendant(enemyAlterSizeMenu, "Title (1)"));
        enemyAlterSizeTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_sizeTitle;

        TextMeshProUGUI enemyAlterSizeUniform = GetTextMeshProUGUI(FindDescendant(enemyAlterSizeMenu, "Toggle", "Label"));
        enemyAlterSizeUniform.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformToggle;

        GameObject enemyAlterSizeUniformContainer = FindDescendant(enemyAlterSizeMenu, "Uniform Container", "Image");
        TextMeshProUGUI enemyAlterSizeUniformContainerSmaller = GetTextMeshProUGUI(FindDescendant(enemyAlterSizeUniformContainer, "Divide By Two Button", "Text"));
        TextMeshProUGUI enemyAlterSizeUniformContainerDefault = GetTextMeshProUGUI(FindDescendant(enemyAlterSizeUniformContainer, "Default Size Button", "Text"));
        TextMeshProUGUI enemyAlterSizeUniformContainerLarger = GetTextMeshProUGUI(FindDescendant(enemyAlterSizeUniformContainer, "Time Two Button", "Text"));
        enemyAlterSizeUniformContainerSmaller.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformSmall;
        enemyAlterSizeUniformContainerDefault.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformDefault;
        enemyAlterSizeUniformContainerLarger.text = LanguageManager.CurrentLanguage.misc.enemyAlter_uniformLarge;

        GameObject enemyAlterMeta = FindDescendant(enemyAlterMenu, "Meta Options");
        //Prop
        TextMeshProUGUI enemyAlterMetaTitle = GetTextMeshProUGUI(FindDescendant(enemyAlterMeta, "Title (1)"));
        enemyAlterMetaTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaTitle;

        TextMeshProUGUI enemyAlterMetaFrozen = GetTextMeshProUGUI(FindDescendant(enemyAlterMeta, "Frozen Toggle", "Label"));
        enemyAlterMetaFrozen.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaFrozen;

        TextMeshProUGUI enemyAlterMetaDisallowManipulation = GetTextMeshProUGUI(FindDescendant(enemyAlterMeta, "Disallow Manipulation Toggle", "Label"));
        enemyAlterMetaDisallowManipulation.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaDisallowManipulation;

        TextMeshProUGUI enemyAlterMetaDisallowFreezing = GetTextMeshProUGUI(FindDescendant(enemyAlterMeta, "Disallow Freezing Toggle", "Label"));
        enemyAlterMetaDisallowFreezing.text = LanguageManager.CurrentLanguage.misc.enemyAlter_metaDisallowFreezing;

        //Jumppad
        GameObject enemyAlterJumpPad = FindDescendant(enemyAlterMenu, "Jump Pad Options");
        TextMeshProUGUI enemyAlterJumpPadTitle = GetTextMeshProUGUI(FindDescendant(enemyAlterJumpPad, "Title (1)"));
        enemyAlterJumpPadTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_jumpPadTitle;

        TextMeshProUGUI enemyAlterJumpPadPower = GetTextMeshProUGUI(FindDescendant(enemyAlterJumpPad, "Slider", "Title (4)"));
        enemyAlterJumpPadPower.text = LanguageManager.CurrentLanguage.misc.enemyAlter_power;

        //Radiance options
        GameObject enemyAlterRadiance = FindDescendant(enemyAlterMenu, "Radiance Options");
        TextMeshProUGUI enemyAlterRadianceTitle = GetTextMeshProUGUI(FindDescendant(enemyAlterRadiance, "Title (1)"));
        enemyAlterRadianceTitle.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceTitle;

        TextMeshProUGUI enemyAlterRadianceEnable = GetTextMeshProUGUI(FindDescendant(enemyAlterRadiance, "Toggle", "Label"));
        enemyAlterRadianceEnable.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceEnable;

        //Radiance details
        GameObject enemyAlterRadianceDetails = FindDescendant(enemyAlterMenu, "Radiance Details", "Radiance Settings");
        TextMeshProUGUI enemyAlterRadianceDetailsTier = GetTextMeshProUGUI(FindDescendant(enemyAlterRadianceDetails, "Radiance Tier Container", "Title (4)"));
        enemyAlterRadianceDetailsTier.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDetails_tier;

        TextMeshProUGUI enemyAlterRadianceHealth = GetTextMeshProUGUI(FindDescendant(enemyAlterRadianceDetails, "Health Multi Container", "Title (4)"));
        enemyAlterRadianceHealth.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceHealth_tier;

        TextMeshProUGUI enemyAlterRadianceDamage = GetTextMeshProUGUI(FindDescendant(enemyAlterRadianceDetails, "Damage Multi Container", "Title (4)"));
        enemyAlterRadianceDamage.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceDamage_tier;

        TextMeshProUGUI enemyAlterRadianceSpeed = GetTextMeshProUGUI(FindDescendant(enemyAlterRadianceDetails, "Speed Multi Container", "Title (4)"));
        enemyAlterRadianceSpeed.text = LanguageManager.CurrentLanguage.misc.enemyAlter_radianceSpeed_tier;

        //Close button
        TextMeshProUGUI enemyAlterClose = GetTextMeshProUGUI(FindDescendant(panel, "Close Button", "Text"));
        enemyAlterClose.text = LanguageManager.CurrentLanguage.options.save_close;

        //Note: Stuff for jump pads, props and enemy boss HP bars are located in SandboxPatches because of dynamic object creation by the game
    }

    public Sandbox(ref GameObject canvasObj)
    {
        PatchSandboxDupeMenu(ref canvasObj);
        PatchMisc(ref canvasObj);
        PatchAlterMenu();
    }

}
