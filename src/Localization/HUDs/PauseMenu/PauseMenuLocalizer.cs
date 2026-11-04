using System;
using UnityEngine;
using TMPro;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

[NonSenseNeedChange]
// Fuck NameSpacing change the name of it
public static class PauseMenuLocalizer
{
    public static void LocalizeAll(OptionsMenuToManager optionsMenuToManager)
    {
        LocalizePauseMenu(optionsMenuToManager.pauseMenu);
        LocalizeQuitDialog(optionsMenuToManager.quitDialog.gameObject);
        LocalizeResetDialoge(optionsMenuToManager.resetDialog.gameObject);
    }

    public static void LocalizePauseMenu(GameObject pauseMenu)
    {
        //Title
        TextMeshProUGUI pauseText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Text"));
        pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

        //Resume
        TextMeshProUGUI continueText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Resume", "Text"));
        continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

        //Checkpoint
        TextMeshProUGUI checkpointText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Restart Checkpoint", "Text"));
        checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;

        //Restart mission
        TextMeshProUGUI restartText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Restart Mission", "Text"));
        restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

        //Options
        TextMeshProUGUI optionsText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Options", "Text"));
        optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

        //Quit
        TextMeshProUGUI quitText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Quit Mission", "Text"));
        quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;
    }

    public static void LocalizeQuitDialog(GameObject quitDialog)
    {
        //Quit
        GameObject quitPanel = FindDescendant(quitDialog, "Panel");
        TextMeshProUGUI quitDialogText = GetTextMeshProUGUI(FindDescendant(quitPanel, "Text (2)"));
        quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

        TextMeshProUGUI quitDialogTooltip = GetTextMeshProUGUI(FindDescendant(quitPanel, "Text (1)"));
        quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

        TextMeshProUGUI quitDialogYes = GetTextMeshProUGUI(FindDescendant(quitPanel, "Confirm", "Text"));
        quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

        TextMeshProUGUI quitDialogNo = GetTextMeshProUGUI(FindDescendant(quitPanel, "Cancel", "Text"));
        quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;
    }

    public static void LocalizeResetDialoge(GameObject resetDialog)
    {
        //Restart
        GameObject restartDialog = FindDescendant(resetDialog, "Panel");

        TextMeshProUGUI restartDialogText = GetTextMeshProUGUI(FindDescendant(restartDialog, "Text"));
        restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

        TextMeshProUGUI restartDialogTooltip = GetTextMeshProUGUI(FindDescendant(restartDialog, "Text (1)"));
        restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;
        TextMeshProUGUI restartDialogYes = GetTextMeshProUGUI(FindDescendant(restartDialog, "Confirm", "Text"));
        restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

        TextMeshProUGUI restartDialogNo = GetTextMeshProUGUI(FindDescendant(restartDialog, "Cancel", "Text"));
        restartDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmNo;
    }
}
