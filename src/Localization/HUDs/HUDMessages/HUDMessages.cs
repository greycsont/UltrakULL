using System;
using TMPro;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.UI;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class HUDMessages
{
    public static void PatchMisc(GameObject canvasObj)
    {
        string currentLevel = GetCurrentSceneName();
        GameObject player = GameObject.Find("Player");
        GameObject styleMeter = FindDescendant(player, "Main Camera", "HUD Camera", "HUD", "StyleCanvas", "Panel (1)", "Panel", "Text (1)", "Text");
        TextMeshProUGUI styleMeterMultiplierText = GetTextMeshProUGUI(styleMeter);
        styleMeterMultiplierText.text = LanguageManager.CurrentLanguage.style.stylemeter_multiplier;

        //Classic HUD
        GameObject classicHudBw = FindDescendant(canvasObj, "Crosshair Filler", "AltHud", "Filler");
        GameObject classicHudColor = FindDescendant(canvasObj, "Crosshair Filler", "AltHud (2)", "Filler");

        TextMeshProUGUI classicHudBwHealth = GetTextMeshProUGUI(FindDescendant(classicHudBw, "Health", "Title"));
        TextMeshProUGUI classicHudColorHealth = GetTextMeshProUGUI(FindDescendant(classicHudColor, "Health (1)", "Title"));
        classicHudBwHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;
        classicHudColorHealth.text = LanguageManager.CurrentLanguage.misc.classicHud_health;

        TextMeshProUGUI classicHudBwStamina = GetTextMeshProUGUI(FindDescendant(classicHudBw, "Stamina", "Title"));
        TextMeshProUGUI classicHudColorStamina = GetTextMeshProUGUI(FindDescendant(classicHudColor, "Stamina (1)", "Title"));
        classicHudBwStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;
        classicHudColorStamina.text = LanguageManager.CurrentLanguage.misc.classicHud_stamina;

        TextMeshProUGUI classicHudBwWeapon = GetTextMeshProUGUI(FindDescendant(classicHudBw, "Weapon", "Title"));
        TextMeshProUGUI classicHudColorWeapon = GetTextMeshProUGUI(FindDescendant(classicHudColor, "Weapon (1)", "Title"));
        classicHudBwWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;
        classicHudColorWeapon.text = LanguageManager.CurrentLanguage.misc.classicHud_weapon;

        TextMeshProUGUI classicHudBwArm = GetTextMeshProUGUI(FindDescendant(classicHudBw, "Arm", "Title"));
        TextMeshProUGUI classicHudColorArm = GetTextMeshProUGUI(FindDescendant(classicHudColor, "Arm (1)", "Title"));
        classicHudBwArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;
        classicHudColorArm.text = LanguageManager.CurrentLanguage.misc.classicHud_arm;

        TextMeshProUGUI classicHudBwRailcannon = GetTextMeshProUGUI(FindDescendant(classicHudBw, "RailcannonMeter (1)", "Title"));
        TextMeshProUGUI classicHudColorRailcannon = GetTextMeshProUGUI(FindDescendant(classicHudColor, "RailcannonMeter (2)", "Title"));
        classicHudBwRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;
        classicHudColorRailcannon.text = LanguageManager.CurrentLanguage.misc.classicHud_railcannonMeter;

        TextMeshProUGUI classicHudBwSpeedometer = GetTextMeshProUGUI(FindDescendant(classicHudBw, "Speedometer", "Title"));
        TextMeshProUGUI classicHudColorSpeedometer = GetTextMeshProUGUI(FindDescendant(classicHudColor, "Speedometer", "Title"));
        classicHudBwSpeedometer.text = LanguageManager.CurrentLanguage.misc.classicHud_speed;
        classicHudColorSpeedometer.text = LanguageManager.CurrentLanguage.misc.classicHud_speed;
    }
}
