using System;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UltrakULL.json;
using UnityEngine.UI;
using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static partial class LevelPatcher
{
    private static void PatchTutorial()
    {

        /*
         * First Page first time:
         * -----------------------
         * BOOT UP SEQUENCE#READY½
         * 
         * FIRMWARE#
         * +LATEST VERSION (2112.08.06)_½
         * 
         * CALIBRATION§
         * *EXPIRED_
         * *NEW CALIBRATION REQUIRED_½
         * 
         * BEGINNING CALIBRATION½
         *
         * AUDIO§         Ä½
         * VIDEO§         Ä½
         * MECHANICS§     Ä½
         * 
         * +CALIBRATION COMPLETE_
         * +PRIMARY SETTINGS UPDATED_
         * (±ASSIST OPTIONS_ AVAILABLE IN PAUSE MENU )½
         * 
         * +ALL SYSTEMS OPERATIONAL_½
         * LOADING STATUS UPDATE§
         
         * First Page second time: 
         * -----------------------
         * BOOT UP SEQUENCE#READY½
         * 
         * FIRMWARE#
         * +LATEST VERSION (2112.08.06)_½
         * 
         * CALIBRATION#
         * +RECENTLY UPDATED_
         * 
         * PERFORM RECALIBRATION?
         * β/δ~
         * 
         * AUDIO§         Ä½
         * VIDEO§         Ä½
         * MECHANICS§     Ä½
         * 
         * +CALIBRATION COMPLETE_
         * +PRIMARY SETTINGS UPDATED_
         * (±ASSIST OPTIONS_ AVAILABLE IN PAUSE MENU )½
         * 
         * +ALL SYSTEMS OPERATIONAL_½
         * LOADING STATUS UPDATE§
         *
         * Second page:
         * -----------------------
         *  STATUS UPDATE:½
         *
         *  MACHINE ID:            V1½½
         *  LOCATION:              APPROACHING HELL½½@
         *  CURRENT OBJECTIVE:     FIND A WEAPON½½
         *
         * *MANKIND IS DEAD._½½
         * *BLOOD IS FUEL._½½
         * *HELL IS FULL._½½&
         */
        var canvasObj = GetObject("Canvas");
        var intro = FindDescendant(canvasObj, "Intro");
        var audio = FindDescendant(intro, "Audio Calibration");
        var audioWarning = FindDescendant(audio, "Warning");
        var video = FindDescendant(intro, "Video Calibration");
        var mechanics = FindDescendant(intro, "Difficulty Select", "Interactables");
        var controller = FindDescendant(intro, "Auto-Aim Settings");

        var tut = LanguageManager.CurrentLanguage.tutorial;
        var options = LanguageManager.CurrentLanguage.options;
        var frontend = LanguageManager.CurrentLanguage.frontend;
        
        var firstPageFirstTime =
            LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup1 + "#" + LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup2 + "½ \n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion1 + "# \n" +
            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion2 + "_½ \n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration1 + "#\n" +
            "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibrationExpired + "_½\n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibrationBeginningCalibration + "½\n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationAudio + "§Ä½ \n" +
            LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationVideo + "§Ä½ \n" +
            LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationMechanics + "§Ä½ \n\n" +

            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete1 + "_ \n" +
            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete2 + "_ \n" +
            "(±" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder1 + "_" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder2 + ")½ \n\n" +

            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_systemsOperational + "_½ \n" +
            LanguageManager.CurrentLanguage.tutorial.tutorial_introLoadStatus + "§";

        var firstPageSecondTime = 
            LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup1 + "#" + LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup2 + "½ \n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion1 + "# \n" +
            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion2 + "_½ \n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration1 + "#\n" +
            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration2 + "_\n\n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_recalibrationPrompt + "\n β/δ~ \n" +

            LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationAudio + "§Ä½ \n" +
            LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationVideo + "§Ä½ \n" +
            LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationMechanics + "§Ä½ \n\n" +

            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete1 + "_ \n" +
            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete2 + "_ \n" +
            "(±" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder1 + "_" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder2 + ")½ \n\n" +

            "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_systemsOperational + "_½ \n" +
            LanguageManager.CurrentLanguage.tutorial.tutorial_introLoadStatus + "§";

        var secondPage = 
            " " + LanguageManager.CurrentLanguage.tutorial.tutorial_introStatusUpdate + ":½\n\n" +
            " " + LanguageManager.CurrentLanguage.tutorial.tutorial_introID1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introID2 + "½½\n" +
            " " + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation2 + "½½@\n" +
            " " + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective1 + ":    " + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective2 + "½½\n\n" +
            "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed1 + "_½½\n" +
            "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed2 + "_½½\n" +
            "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed3 + "_½½&";

        intro.Localize<TextMeshProUGUI>(firstPageFirstTime,
            path: ["Page 1 (First Time)"]);

        intro.Localize<TextMeshProUGUI>(firstPageSecondTime,
            path: ["Page 1 (Second Time)"]);

        intro.Localize<TextMeshProUGUI>(secondPage,
            path: ["Page 2"]);

        intro.Localize<TextMeshProUGUI>(
            "<color=red> " + tut.tutorial_introRed1 + "\n "
            + tut.tutorial_introRed2 + "\n "
            + tut.tutorial_introRed3 + "</color>",
            path: ["Page 2 NoFade"]);

        audio.Localize<TextMeshProUGUI>(tut.tutorial_audioCalibrationTitle,
            path: ["Text"]);

        audio.Localize<TextMeshProUGUI>(options.audio_globalVolume,
            path: ["Master Volume (1)", "Text"]);

        audio.Localize<TextMeshProUGUI>(options.audio_soundEffectsVolume,
            path: ["SFX Volume (1)", "Text"]);

        audio.Localize<TextMeshProUGUI>(options.audio_musicVolume,
            path: ["Music Volume (1)", "Text"]);

        audio.Localize<TextMeshProUGUI>(tut.tutorial_audioCalibrationDone,
            path: ["Bone (1)", "Text"]);

        audio.Localize<TextMeshProUGUI>(tut.tutorial_audioCalibrationDone,
            path: ["Done", "Text"]);

        audio.Localize<SliderValueToText>(slider =>
        {
            slider.ifMin = tut.tutorial_audioCalibrationSliderOff.Or(slider.ifMin);
        },
            path: ["Master Volume (1)", "Button", "Slider (1)", "Text (2)"]
        );

        audio.Localize<SliderValueToText>(slider =>
        {
            slider.ifMin = tut.tutorial_audioCalibrationSliderOff.Or(slider.ifMin);
        },
            path: ["SFX Volume (1)", "Button", "Slider (1)", "Text (2)"]
        );

        audio.Localize<SliderValueToText>(slider =>
        {
            slider.ifMin = tut.tutorial_audioCalibrationSliderOff.Or(slider.ifMin);
        },
            path: ["Music Volume (1)", "Button", "Slider (1)", "Text (2)"]
        );

        audioWarning.Localize<TextMeshProUGUI>(
            "<color=red>" + tut.tutorial_audioCalibrationWarning1 + "</color>\n\n"
            + tut.tutorial_audioCalibrationWarning2 + "\n\n"
            + tut.tutorial_audioCalibrationWarning3,
            path: ["Text (No Master)"]);

        audioWarning.Localize<TextMeshProUGUI>(
            "<color=red>" + tut.tutorial_audioCalibrationSFXWarning1 + "</color>\n\n"
            + tut.tutorial_audioCalibrationSFXWarning2 + "\n\n"
            + tut.tutorial_audioCalibrationSFXWarning3,
            path: ["Text (No SFX)"]);

        audioWarning.Localize<TextMeshProUGUI>(tut.tutorial_audioCalibrationWarningPromptYes,
            path: ["Done (1)", "Text"]);

        audioWarning.Localize<TextMeshProUGUI>(tut.tutorial_audioCalibrationWarningPromptNo,
            path: ["Done (2)", "Text"]);

        video.Localize<TextMeshProUGUI>(tut.tutorial_videoCalibrationTitle,
            path: ["Text"]);

        video.Localize<TextMeshProUGUI>(tut.tutorial_videoCalibrationPcDescription,
            path: ["Text (1)"]);

        video.Localize<TextMeshProUGUI>(tut.tutorial_videoCalibrationPsxDescription,
            path: ["Text (2)"]);

        mechanics.Localize<TextMeshProUGUI>("--" + frontend.difficulty_title + "--",
            path: ["Title"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_easy,
            path: ["Easy"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_normal,
            path: ["Normal"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_hard,
            path: ["Hard"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_harmless,
            path: ["Casual Easy", "Name"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_lenient,
            path: ["Casual Hard", "Name"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_standard + " <color=orange>*</color>",
            path: ["Standard", "Name"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_violent,
            path: ["Violent", "Name"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_brutal,
            path: ["Brutal", "Name"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_umd,
            path: ["V1 Must Die", "Name"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_underConstruction,
            path: ["V1 Must Die", "Under Construction"]);

        mechanics.Localize<TextMeshProUGUI>("--" + frontend.difficulty_harmless + "--",
            path: ["Harmless Info", "Title (1)"]);

        mechanics.Localize<TextMeshProUGUI>(
            frontend.difficulty_harmlessDescription1 + "\n\n"
            + frontend.difficulty_harmlessDescription2 + "\n\n"
            + "<color=green>" + frontend.difficulty_harmlessDescription3 + "</color>",
            path: ["Harmless Info", "Text"]);

        mechanics.Localize<TextMeshProUGUI>("--" + frontend.difficulty_lenient + "--",
            path: ["Lenient Info", "Title (1)"]);

        mechanics.Localize<TextMeshProUGUI>(
            frontend.difficulty_lenientDescription1 + "\n\n"
            + frontend.difficulty_lenientDescription2 + "\n\n"
            + "<color=yellow>" + frontend.difficulty_lenientDescription3 + "</color>",
            path: ["Lenient Info", "Text"]);

        mechanics.Localize<TextMeshProUGUI>("--" + frontend.difficulty_standard + "--",
            path: ["Standard Info", "Title (1)"]);

        mechanics.Localize<TextMeshProUGUI>(
            frontend.difficulty_standardDescription1 + "\n\n"
            + frontend.difficulty_standardDescription2 + "\n\n"
            + "<color=orange>" + frontend.difficulty_standardDescription3 + "</color>",
            path: ["Standard Info", "Text"]);

        mechanics.Localize<TextMeshProUGUI>("--" + frontend.difficulty_violent + "--",
            path: ["Violent Info", "Title (1)"]);

        mechanics.Localize<TextMeshProUGUI>(
            frontend.difficulty_violentDescription1 + "\n\n"
            + frontend.difficulty_violentDescription2 + "\n\n"
            + "<color=red>" + frontend.difficulty_violentDescription3 + "</color>",
            path: ["Violent Info", "Text"]);

        mechanics.Localize<TextMeshProUGUI>("--" + frontend.difficulty_brutal + "--",
            path: ["Brutal Info", "Title (1)"]);

        mechanics.Localize<TextMeshProUGUI>(
            "<color=white>" + frontend.difficulty_brutalDescription1 + "\n\n"
            + frontend.difficulty_brutalDescription2 + "</color>\n\n"
            + "<b>" + frontend.difficulty_brutalDescription3 + "</b>",
            path: ["Brutal Info", "Text"]);

        mechanics.Localize<TextMeshProUGUI>(frontend.difficulty_tweakReminder,
            path: ["Assist Tip"]);

        controller.SetActive(true);
        controller.SetActive(false);

        controller.Localize<TextMeshProUGUI>(
            "! " + tut.tutorial_controllerCalibrationTitle + " !\n<size=16>" + tut.tutorial_controllerCalibrationSubtitle + "</size>",
            path: ["Contents", "! Controller Detected !", "Text"]);

        controller.Localize<TextMeshProUGUI>(options.assists_autoAim,
            path: ["Contents", "Auto Aim", "Text"]);

        controller.Localize<TextMeshProUGUI>(options.assists_autoAimPercent,
            path: ["Contents", "Auto Aim Amount", "Text"]);

        controller.Localize<SliderValueToText>(slider =>
        {
            slider.ifMax = options.assists_autoAimPercentMaximum;
            slider.ifMin = options.assists_autoAimPercentMinimum;
        },
            path: ["Contents", "Auto Aim Amount", "Slider Button(Clone)", "Slider", "Text"]
        );

        controller.Localize<TextMeshProUGUI>(LanguageManager.CurrentLanguage.shop.shop_colorsDone,
            path: ["Done", "Text"]);

        controller.Localize<TextMeshProUGUI>(tut.tutorial_controllerCalibrationTooltip,
            path: ["Text (2)"]);
    }
}