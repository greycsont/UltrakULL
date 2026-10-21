using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

// For the keybinds part, please look at 
//   ./src/Localization/Text/Patches/ControlBindNames.cs
public static partial class Options
{

    static public void PatchControlOptions(GameObject optionsMenu)
    {   
        //Control options
        GameObject controlContent = FindDescendant(optionsMenu, "Scroll Rect", "Contents");

        //-- GENERAL --
        controlContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.category_general), path: ["-- General --", "Text"]);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_mouseSensitivity, path: ["Look Sensitivity", "Text"]);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_xInversion, path: ["Invert X Axis", "Text"]);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_yInversion, path: ["Invert Y Axis", "Text"]);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_controllerRumble, path: ["Controller Rumble", "Text"]);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_controllerRumbleCustomize, path: ["Controller Rumble", "Action Button(Clone)", "Text"]);

        controlContent.transform.GetChild(5).gameObject.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.controls_weapons), path: ["Text"]);

        GameObject mouseWheelContent = FindDescendant(controlContent, "Scroll Weapons with Mouse Wheel");
        mouseWheelContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_mouseWheelToChangeWeapon, path: ["Text"]);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_scrollType, path: ["Weapon Scroll Type", "Text"]);

        //Dropdown here
        GameObject scrollTypeList = FindDescendant(controlContent, "Weapon Scroll Type", "Dropdown(Clone)");

        TMP_Dropdown scrollTypeDropdown = scrollTypeList.GetComponent<TMP_Dropdown>();
        List<TMP_Dropdown.OptionData> scrollTypeDropdownText = scrollTypeDropdown.options;
        scrollTypeDropdownText[0].Localize(LanguageManager.CurrentLanguage.options.controls_scrollTypeWeapons);
        scrollTypeDropdownText[1].Localize(LanguageManager.CurrentLanguage.options.controls_scrollTypeVariations);
        scrollTypeDropdownText[2].Localize(LanguageManager.CurrentLanguage.options.controls_scrollTypeAll);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_reverseScroll, path: ["Reverse Scroll Direction", "Text"]);

        GameObject redrawBehaviour = FindDescendant(controlContent, "On Swap To Already Drawn Weapon");
        redrawBehaviour.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_redrawBehaviour, path: ["Text"]);

        TMP_Dropdown redrawBehaviourDropdown = FindComponent<TMP_Dropdown>(redrawBehaviour, "Dropdown(Clone)");
        List<TMP_Dropdown.OptionData> redrawBehaviourDropdownText = redrawBehaviourDropdown.options;
        redrawBehaviourDropdownText[0].Localize(LanguageManager.CurrentLanguage.options.controls_redrawNext);
        redrawBehaviourDropdownText[1].Localize(LanguageManager.CurrentLanguage.options.controls_redrawFirst);
        redrawBehaviourDropdownText[2].Localize(LanguageManager.CurrentLanguage.options.controls_redrawSame);

        controlContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.controls_invertRocketControls, path: ["Invert Rocket Controls", "Text"]);

        //unused after patch 16
        //TextMeshProUGUI bindsTitle = FindComponent<TextMeshProUGUI>(controlContent.transform.GetChild(10).gameObject, "Text");
        //bindsTitle.text = "-- " + LanguageManager.CurrentLanguage.options.controls_bindings + " --";


        //Tried to use a foreach loop but it just wouldn't work, that'll do for now, just have to add things manually once they get added
        //Commented this out for now due to it causing out of bound issues. Will investigate later

        /*TextMeshProUGUI bindMove = GetTextMeshProUGUI(controlContent.transform.GetChild(8).gameObject);
        TextMeshProUGUI bindDodge = GetTextMeshProUGUI(controlContent.transform.GetChild(9).gameObject);
        TextMeshProUGUI bindSlide = GetTextMeshProUGUI(controlContent.transform.GetChild(10).gameObject);
        TextMeshProUGUI bindJump = GetTextMeshProUGUI(controlContent.transform.GetChild(11).gameObject);

        TextMeshProUGUI bindPrimary = GetTextMeshProUGUI(controlContent.transform.GetChild(13).gameObject);
        TextMeshProUGUI bindSecondary = GetTextMeshProUGUI(controlContent.transform.GetChild(14).gameObject);
        TextMeshProUGUI bindChangeVariation = GetTextMeshProUGUI(controlContent.transform.GetChild(15).gameObject);
        TextMeshProUGUI bindSlot0 = GetTextMeshProUGUI(controlContent.transform.GetChild(16).gameObject);
        TextMeshProUGUI bindSlot1 = GetTextMeshProUGUI(controlContent.transform.GetChild(17).gameObject);
        TextMeshProUGUI bindSlot2 = GetTextMeshProUGUI(controlContent.transform.GetChild(18).gameObject);
        TextMeshProUGUI bindSlot3 = GetTextMeshProUGUI(controlContent.transform.GetChild(19).gameObject);
        TextMeshProUGUI bindSlot4 = GetTextMeshProUGUI(controlContent.transform.GetChild(20).gameObject);
        TextMeshProUGUI bindSlot5 = GetTextMeshProUGUI(controlContent.transform.GetChild(21).gameObject);
        TextMeshProUGUI bindSlot6 = GetTextMeshProUGUI(controlContent.transform.GetChild(22).gameObject);
        TextMeshProUGUI bindSlot7 = GetTextMeshProUGUI(controlContent.transform.GetChild(23).gameObject);
        TextMeshProUGUI bindSlot8 = GetTextMeshProUGUI(controlContent.transform.GetChild(24).gameObject);
        TextMeshProUGUI bindSlot9 = GetTextMeshProUGUI(controlContent.transform.GetChild(25).gameObject);
        TextMeshProUGUI bindNext = GetTextMeshProUGUI(controlContent.transform.GetChild(26).gameObject);
        TextMeshProUGUI bindPrevious = GetTextMeshProUGUI(controlContent.transform.GetChild(27).gameObject);
        TextMeshProUGUI bindLast = GetTextMeshProUGUI(controlContent.transform.GetChild(28).gameObject);

        TextMeshProUGUI bindChangeFist = GetTextMeshProUGUI(controlContent.transform.GetChild(30).gameObject);
        TextMeshProUGUI bindPunch = GetTextMeshProUGUI(controlContent.transform.GetChild(31).gameObject);
        TextMeshProUGUI bindHook = GetTextMeshProUGUI(controlContent.transform.GetChild(32).gameObject);

        bindMove.text = LanguageManager.CurrentLanguage.options.controls_move;
        bindDodge.text = LanguageManager.CurrentLanguage.options.controls_dash;
        bindSlide.text = LanguageManager.CurrentLanguage.options.controls_slide;
        bindJump.text = LanguageManager.CurrentLanguage.options.controls_jump;

        bindPrimary.text = LanguageManager.CurrentLanguage.options.controls_primaryFire;
        bindSecondary.text = LanguageManager.CurrentLanguage.options.controls_secondaryFire;
        bindChangeVariation.text = LanguageManager.CurrentLanguage.options.controls_changeVariation;
        bindSlot0.text = LanguageManager.CurrentLanguage.options.controls_slot0;
        bindSlot1.text = LanguageManager.CurrentLanguage.options.controls_slot1;
        bindSlot2.text = LanguageManager.CurrentLanguage.options.controls_slot2;
        bindSlot3.text = LanguageManager.CurrentLanguage.options.controls_slot3;
        bindSlot4.text = LanguageManager.CurrentLanguage.options.controls_slot4;
        bindSlot5.text = LanguageManager.CurrentLanguage.options.controls_slot5;
        bindSlot6.text = LanguageManager.CurrentLanguage.options.controls_slot6;
        bindSlot7.text = LanguageManager.CurrentLanguage.options.controls_slot7;
        bindSlot8.text = LanguageManager.CurrentLanguage.options.controls_slot8;
        bindSlot9.text = LanguageManager.CurrentLanguage.options.controls_slot9;
        bindNext.text = LanguageManager.CurrentLanguage.options.controls_nextWeapon;
        bindPrevious.text = LanguageManager.CurrentLanguage.options.controls_previousWeapon;
        bindLast.text = LanguageManager.CurrentLanguage.options.controls_lastUsedWeapon;

        bindChangeFist.text = LanguageManager.CurrentLanguage.options.controls_changeArm;
        bindPunch.text = LanguageManager.CurrentLanguage.options.controls_punch;
        bindHook.text = LanguageManager.CurrentLanguage.options.controls_whiplash;*/
    }
}
