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
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "-- Volume --", "Text")), new[] { LanguageManager.CurrentLanguage.options.audio_volume }, "-- " + LanguageManager.CurrentLanguage.options.audio_volume + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Master", "Text")), LanguageManager.CurrentLanguage.options.audio_globalVolume);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Sound Effects", "Text")), LanguageManager.CurrentLanguage.options.audio_soundEffectsVolume);

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Music", "Text")), LanguageManager.CurrentLanguage.options.audio_musicVolume);

        //-- MISC --
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "-- Misc --", "Text")), new[] { LanguageManager.CurrentLanguage.options.general_misc }, "-- " + LanguageManager.CurrentLanguage.options.general_misc + " --");

        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Subtitles", "Text")), LanguageManager.CurrentLanguage.options.audio_subtitles);
        
        TryToReplaceText(GetTextMeshProUGUI(FindDescendant(audioContent, "Muffle Music While Underwater", "Text")), LanguageManager.CurrentLanguage.options.audio_muffleMusic);
    }
}
