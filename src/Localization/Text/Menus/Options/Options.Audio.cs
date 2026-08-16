using System;
using System.Collections.Generic;
using TMPro;
using UltrakULL.Harmony_Patches;
using UltrakULL.json;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UltrakULL.TextReplacer;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class Options
{

    static public void PatchAudioOptions(GameObject optionsMenu)
    {
        //Audio options
        GameObject audioContent = FindDescendant(optionsMenu, "Container");

        //-- Volume --
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.audio_volume), audioContent, "-- Volume --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_globalVolume, audioContent, "Master", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_soundEffectsVolume, audioContent, "Sound Effects", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_musicVolume, audioContent, "Music", "Text");

        //-- MISC --
        TryReplaceText<TextMeshProUGUI>(StringHelper.Format("-- {0} --", LanguageManager.CurrentLanguage.options.general_misc), audioContent, "-- Misc --", "Text");

        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_subtitles, audioContent, "Subtitles", "Text");
        
        TryReplaceText<TextMeshProUGUI>(LanguageManager.CurrentLanguage.options.audio_muffleMusic, audioContent, "Muffle Music While Underwater", "Text");
    }
}
