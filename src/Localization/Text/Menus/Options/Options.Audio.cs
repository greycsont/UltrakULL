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

public static partial class Options
{

    static public void PatchAudioOptions(GameObject optionsMenu)
    {
        //Audio options
        GameObject audioContent = FindDescendant(optionsMenu, "Container");

        //-- Volume --
        audioContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.audio_volume), path: ["-- Volume --", "Text"]);
        audioContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_globalVolume, path: ["Master", "Text"]);
        audioContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_soundEffectsVolume, path: ["Sound Effects", "Text"]);
        audioContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_musicVolume, path: ["Music", "Text"]);

        //-- MISC --
        audioContent.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(LanguageManager.CurrentLanguage.options.general_misc), path: ["-- Misc --", "Text"]);
        audioContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_subtitles, path: ["Subtitles", "Text"]);
        audioContent.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_muffleMusic, path: ["Muffle Music While Underwater", "Text"]);
    }
}
