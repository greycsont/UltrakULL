using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

class TutorialStrings
{
    public string IntroFirstPage;

    //+ "Y/N ~ \n \n"
    //+ " AUDIO§         Ä½ \n"
    //+ " VIDEO§         Ä½ \n"
    //+ "MECHANICS§     Ä½ \n"
    //+ "+ CALIBRATION COMPLETE_ \n"
    //+ "+PRIMARY SETTINGS UPDATED_ \n"
    //+ "(±ASSIST OPTIONS_ AVAILABLE IN PAUSE MENU)½ \n"
    //+ "+ALL SYSTEMS OPERATIONAL_½ \n"
    //+ "LOADING STATUS UPDATE§ \n";

    public string IntroSecondPage;

    /*
     *  MACHINE ID:            V1½½
        LOCATION:              APPROACHING HELL½½@
        CURRENT OBJECTIVE:     FIND A WEAPON½½

        *MANKIND IS DEAD._½½
        *BLOOD IS FUEL._½½
        *HELL IS FULL._½½&
     */

    private static readonly (string keyword, Func<string, string, string, string> build)[] Messages =
    {
        ("PUNCH", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_punch1 + "<color=orange>" + input + "</color>" + LanguageManager.CurrentLanguage.tutorial.tutorial_punch2),
        ("SLIDE", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_slide1 + "<color=orange>" + input + "</color>" + LanguageManager.CurrentLanguage.tutorial.tutorial_slide2),
        ("DASH", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_dash1 + "<color=#00DFFF>" + input + "</color>" + LanguageManager.CurrentLanguage.tutorial.tutorial_dash2 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_dash3),
        ("HEALTH", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_health1 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_health2),
        ("JUMP", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_walljump),
        ("SHOCKWAVE", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave1 + "<color=orange>" + input + "</color>" + LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave2 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_shockwave3),
        ("ORBS", (m, m2, input) => LanguageManager.CurrentLanguage.tutorial.tutorial_orb1 + "\n" + LanguageManager.CurrentLanguage.tutorial.tutorial_orb2),
    };

    public static string GetMessage(string inputMessage, string inputMessage2, string input)
    {
        string fullMessage = inputMessage + inputMessage2;

        foreach (var (keyword, build) in Messages)
            if (fullMessage.Contains(keyword))
                return build(inputMessage, inputMessage2, input);

        return null;
    }

    //IMPORTANT CHARACTERS TO USE:
    // # - 3 repeating dots
    // § - Indent
    // + - Lime green text
    // * - Red text
    // ± - Blue text
    // _ - Close color
    // ½ - Half second pause
    // @ - Begins to fade out intro music
    // ~ - Wait for recalibration input
    // & - Ends intro text and loads the tutorial
    // β - Recalibration yes (automatically shows keyboard or controller button depending on what the player is using)
    // δ - Recalibration no (automatically shows keyboard or controller button depending on what the player is using)

    public void PatchCalibrationWindows(GameObject canvasObj)
    {
        try
        {
            GameObject calibrationIntro = FindDescendant(canvasObj, "Intro");
            GameObject calibrationAudioWindow = FindDescendant(calibrationIntro, "Audio Calibration");
            GameObject calibrationAudioWindowWarning = FindDescendant(calibrationAudioWindow, "Warning");
            GameObject calibrationVideoWindow = FindDescendant(calibrationIntro, "Video Calibration");
            GameObject calibrationMechanicsWindow = FindDescendant(calibrationIntro, "Difficulty Select", "Interactables");
            GameObject calibrationControllerWindow = FindDescendant(calibrationIntro, "Auto-Aim Settings");

            TextMeshProUGUI nofade = GetTextMeshProUGUI(FindDescendant(calibrationIntro, "Page 2 NoFade"));
            nofade.text = 
                "<color=red> " + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed1 + "\n "
                + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed2 + "\n "
                + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed3 + "</color>";

            //Audio
            TextMeshProUGUI calibrationAudioTitle = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindow, "Text"));
            calibrationAudioTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationTitle;

            TextMeshProUGUI calibrationAudioMaster = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindow, "Master Volume (1)", "Text"));
            calibrationAudioMaster.text = LanguageManager.CurrentLanguage.options.audio_globalVolume;

            TextMeshProUGUI calibrationAudioSFX = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindow, "SFX Volume (1)", "Text"));
            calibrationAudioSFX.text = LanguageManager.CurrentLanguage.options.audio_soundEffectsVolume;

            TextMeshProUGUI calibrationAudioMusic = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindow, "Music Volume (1)", "Text"));
            calibrationAudioMusic.text = LanguageManager.CurrentLanguage.options.audio_musicVolume;

            TextMeshProUGUI calibrationAudioDone = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindow, "Bone (1)", "Text"));
            calibrationAudioDone.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationDone;
            
            TextMeshProUGUI calibrationAudioDoneAlt = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindow, "Done", "Text"));
            calibrationAudioDoneAlt.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationDone;

            //Audio warning
            TextMeshProUGUI calibrationMasterAudioWarningPrompt = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindowWarning, "Text (No Master)"));
            calibrationMasterAudioWarningPrompt.text =
                "<color=red>" + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning1 +"</color>" + "\n\n"
                 + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning2 + "\n\n" +
                 LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarning3;

            TextMeshProUGUI calibrationSFXAudioWarningPrompt = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindowWarning, "Text (No SFX)"));
            calibrationSFXAudioWarningPrompt.text =
                "<color=red>" + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationSFXWarning1 + "</color>" + "\n\n"
                 + LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationSFXWarning2 + "\n\n" +
                 LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationSFXWarning3;

            TextMeshProUGUI calibrationAudioWarningPromptYes = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindowWarning, "Done (1)", "Text"));
            calibrationAudioWarningPromptYes.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptYes;

            TextMeshProUGUI calibrationAudioWarningPromptNo = GetTextMeshProUGUI(FindDescendant(calibrationAudioWindowWarning, "Done (2)", "Text"));
            calibrationAudioWarningPromptNo.text = LanguageManager.CurrentLanguage.tutorial.tutorial_audioCalibrationWarningPromptNo;

            //Video
            TextMeshProUGUI calibrationVideoTitle = GetTextMeshProUGUI(FindDescendant(calibrationVideoWindow, "Text"));
            calibrationVideoTitle.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationTitle;

            TextMeshProUGUI calibrationVideoPcDescription = GetTextMeshProUGUI(FindDescendant(calibrationVideoWindow, "Text (1)"));
            calibrationVideoPcDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPcDescription;

            TextMeshProUGUI calibrationVideoPsxDescription = GetTextMeshProUGUI(FindDescendant(calibrationVideoWindow, "Text (2)"));
            calibrationVideoPsxDescription.text = LanguageManager.CurrentLanguage.tutorial.tutorial_videoCalibrationPsxDescription;

            //Mechanics (difficulty)
            TextMeshProUGUI calibrationMechanicsTitle = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Title"));
            calibrationMechanicsTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_title + "--";

            TextMeshProUGUI calibrationMechanicsEasy = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Easy"));
            calibrationMechanicsEasy.text = LanguageManager.CurrentLanguage.frontend.difficulty_easy;

            TextMeshProUGUI calibrationMechanicsMedium = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Normal"));
            calibrationMechanicsMedium.text = LanguageManager.CurrentLanguage.frontend.difficulty_normal;

            TextMeshProUGUI calibrationMechanicsHard = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Hard"));
            calibrationMechanicsHard.text = LanguageManager.CurrentLanguage.frontend.difficulty_hard;

            TextMeshProUGUI calibrationMechanicsHarmless = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Casual Easy", "Name"));
            calibrationMechanicsHarmless.text = LanguageManager.CurrentLanguage.frontend.difficulty_harmless;

            TextMeshProUGUI calibrationMechanicsLenient = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Casual Hard", "Name"));
            calibrationMechanicsLenient.text = LanguageManager.CurrentLanguage.frontend.difficulty_lenient;

            TextMeshProUGUI calibrationMechanicsStandard = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Standard", "Name"));
            calibrationMechanicsStandard.text = LanguageManager.CurrentLanguage.frontend.difficulty_standard + " <color=orange>*</color>";

            TextMeshProUGUI calibrationMechanicsViolent = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Violent", "Name"));
            calibrationMechanicsViolent.text = LanguageManager.CurrentLanguage.frontend.difficulty_violent;

            TextMeshProUGUI calibrationMechanicsBrutal = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "Brutal", "Name"));
            calibrationMechanicsBrutal.text = LanguageManager.CurrentLanguage.frontend.difficulty_brutal;

            TextMeshProUGUI calibrationMechanicsUmd = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "V1 Must Die", "Name"));
            calibrationMechanicsUmd.text = LanguageManager.CurrentLanguage.frontend.difficulty_umd;

            //Harmless info
            GameObject calibrationHarmlessInfo = FindDescendant(calibrationMechanicsWindow, "Harmless Info");
            TextMeshProUGUI harmlessTitle = GetTextMeshProUGUI(FindDescendant(calibrationHarmlessInfo, "Title (1)"));
            harmlessTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_harmless + "--";

            //Harmless descriptor
            TextMeshProUGUI harmlessDescriptor = GetTextMeshProUGUI(FindDescendant(calibrationHarmlessInfo, "Text"));
            harmlessDescriptor.text =
                LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription1
                + "\n\n"
                + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription2
                + "\n\n"
                + "<color=green>" + LanguageManager.CurrentLanguage.frontend.difficulty_harmlessDescription3 + "</color>";

            //Lenient title
            GameObject calibrationLenientInfo = FindDescendant(calibrationMechanicsWindow, "Lenient Info");
            TextMeshProUGUI lenientTitle = GetTextMeshProUGUI(FindDescendant(calibrationLenientInfo, "Title (1)"));
            lenientTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_lenient + "--";

            //Lenient descriptor
            TextMeshProUGUI lenientDescriptor = GetTextMeshProUGUI(FindDescendant(calibrationLenientInfo, "Text"));
            lenientDescriptor.text =
                LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription1
                + "\n\n"
                + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription2
                + "\n\n"
                + "<color=yellow>" + LanguageManager.CurrentLanguage.frontend.difficulty_lenientDescription3 + "</color>";

            //Standard title
            GameObject calibrationStandardInfo = FindDescendant(calibrationMechanicsWindow, "Standard Info");
            TextMeshProUGUI standardTitle = GetTextMeshProUGUI(FindDescendant(calibrationStandardInfo, "Title (1)"));
            standardTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_standard + "--";

            //Standard descriptor
            TextMeshProUGUI standardDescriptor = GetTextMeshProUGUI(FindDescendant(calibrationStandardInfo, "Text"));
            standardDescriptor.text =
                LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription1
                + "\n\n"
                + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription2
                + "\n\n"
                + "<color=orange>" + LanguageManager.CurrentLanguage.frontend.difficulty_standardDescription3 + "</color>";

            //Violent title
            GameObject calibrationViolentInfo = FindDescendant(calibrationMechanicsWindow, "Violent Info");
            TextMeshProUGUI violentTitle = GetTextMeshProUGUI(FindDescendant(calibrationViolentInfo, "Title (1)"));
            violentTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_violent + "--";

            //Violent descriptor
            TextMeshProUGUI violentDescriptor = GetTextMeshProUGUI(FindDescendant(calibrationViolentInfo, "Text"));
            violentDescriptor.text =
                LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription1
                + "\n\n"
                + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription2
                + "\n\n"
                + "<color=red>" + LanguageManager.CurrentLanguage.frontend.difficulty_violentDescription3 + "</color>";

            //Brutal title
            GameObject calibrationBrutalInfo = FindDescendant(calibrationMechanicsWindow, "Brutal Info");
            TextMeshProUGUI brutalTitle = GetTextMeshProUGUI(FindDescendant(calibrationBrutalInfo, "Title (1)"));
            brutalTitle.text = "--" + LanguageManager.CurrentLanguage.frontend.difficulty_brutal + "--";
            //Brutal descriptor
            TextMeshProUGUI brutalDescriptor = GetTextMeshProUGUI(FindDescendant(calibrationBrutalInfo, "Text"));
            brutalDescriptor.text =
                "<color=white>" + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription1
                + "\n\n"
                + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription2 + "</color>"
                + "\n\n"
                + "<b>" + LanguageManager.CurrentLanguage.frontend.difficulty_brutalDescription3 + "</b>";

            TextMeshProUGUI underConstructionText = GetTextMeshProUGUI(FindDescendant(calibrationMechanicsWindow, "V1 Must Die", "Under Construction"));
            underConstructionText.text = LanguageManager.CurrentLanguage.frontend.difficulty_underConstruction;

            //Controller/autoaim settings //Updated patch to objects in REVAMP update
            calibrationControllerWindow.SetActive(true); //Fast on-off for load all childs in GameObject
            calibrationControllerWindow.SetActive(false);
            TextMeshProUGUI calibrationControllerTitle = GetTextMeshProUGUI(FindDescendant(calibrationControllerWindow, "Contents", "! Controller Detected !", "Text"));
            calibrationControllerTitle.text = "! " + LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTitle + " !\n<size=16>" + LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationSubtitle + "</size>";

            TextMeshProUGUI calibrationControllerAutoAimToggle = GetTextMeshProUGUI(FindDescendant(calibrationControllerWindow, "Contents", "Auto Aim", "Text"));
            calibrationControllerAutoAimToggle.text = LanguageManager.CurrentLanguage.options.assists_autoAim;

            GameObject calibrationControllerAutoAimAmount = FindDescendant(calibrationControllerWindow, "Contents", "Auto Aim Amount");
            TextMeshProUGUI calibrationControllerAutoAimPercent = GetTextMeshProUGUI(FindDescendant(calibrationControllerAutoAimAmount, "Text"));
            calibrationControllerAutoAimPercent.text = LanguageManager.CurrentLanguage.options.assists_autoAimPercent;

            SliderValueToText autoAimSlider = FindDescendant(calibrationControllerAutoAimAmount, "Slider Button(Clone)", "Slider", "Text").GetComponentInChildren<SliderValueToText>();
            autoAimSlider.ifMin = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMinimum;
            autoAimSlider.ifMax = LanguageManager.CurrentLanguage.options.assists_autoAimPercentMaximum;

            TextMeshProUGUI calibrationAssistDone = GetTextMeshProUGUI(FindDescendant(calibrationControllerWindow, "Done", "Text"));
            calibrationAssistDone.text = LanguageManager.CurrentLanguage.shop.shop_colorsDone;

            TextMeshProUGUI calibrationControllerAutoAimReminder = GetTextMeshProUGUI(FindDescendant(calibrationControllerWindow, "Text (2)"));
            calibrationControllerAutoAimReminder.text = LanguageManager.CurrentLanguage.tutorial.tutorial_controllerCalibrationTooltip;

            //Tooltip
            GameObject assistTip = FindDescendant(calibrationMechanicsWindow, "Assist Tip");
            TextMeshProUGUI assistTipText = GetTextMeshProUGUI(assistTip);
            assistTipText.text = LanguageManager.CurrentLanguage.frontend.difficulty_tweakReminder;
        }
        catch(Exception e)
        {
            Logging.Error("Failed to patch tutorial panels");
            Logging.Error(e.ToString());
        }
    }

    public TutorialStrings(GameObject canvasObj)
    {
        this.IntroFirstPage =
            LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup1 + "#" + LanguageManager.CurrentLanguage.tutorial.tutorial_introStartup2 + "½ \n\n"

            + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion1 + "# \n"
            + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introVersion2 + "_½ \n\n"

            + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration1 + "#\n"
            + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_introCalibration2 + "_\n\n"

            + LanguageManager.CurrentLanguage.tutorial.tutorial_recalibrationPrompt + "\n β/δ~ \n"

            + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationAudio + "§Ä½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationVideo + "§Ä½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationMechanics + "§Ä½ \n\n"

            + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete1 + "_ \n"
            + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_calibrationComplete2 + "_ \n"
            + "(±" + LanguageManager.CurrentLanguage.tutorial.tutorial_introReminder + " _)½ \n\n"

            + "+" + LanguageManager.CurrentLanguage.tutorial.tutorial_systemsOperational + "_½ \n"
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introLoadStatus + "§";

        this.IntroSecondPage = " " +
            LanguageManager.CurrentLanguage.tutorial.tutorial_introStatusUpdate + ":½\n\n " +
            LanguageManager.CurrentLanguage.tutorial.tutorial_introID1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introID2 + "½½\n "
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation1 + ":     " + LanguageManager.CurrentLanguage.tutorial.tutorial_introLocation2 + "½½@\n "
            + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective1 + ":    " + LanguageManager.CurrentLanguage.tutorial.tutorial_introObjective2 + "½½\n\n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed1 + "_½½\n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed2 + "_½½\n"
            + "*" + LanguageManager.CurrentLanguage.tutorial.tutorial_introRed3 + "_½½&";

        PatchCalibrationWindows(canvasObj);

    }
}
