using System;
using UnityEngine;
using TMPro;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

[NonSenseNeedChange]
// Fuck NameSpacing change the name of it
public static class _PauseMenu
{
    public static void PatchPauseMenu(GameObject canvasObj)
    {
        try
        {
            GameObject pauseMenu = FindDescendant(canvasObj, "PauseMenu");

            //Title
            TextMeshProUGUI pauseText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Text"));
            pauseText.text = "-- " + LanguageManager.CurrentLanguage.pauseMenu.pause_title + " --";

            //Resume
            TextMeshProUGUI continueText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Resume", "Text"));
            continueText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_resume;

            //Checkpoint
            TextMeshProUGUI checkpointText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Restart Checkpoint", "Text"));
            checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_respawn;
            if (GetCurrentSceneName().Contains("Intermission"))
            {
                checkpointText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_skip;
            }
            //Restart mission
            TextMeshProUGUI restartText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Restart Mission", "Text"));
            restartText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restart;

            //Options
            TextMeshProUGUI optionsText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Options", "Text"));
            optionsText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_options;

            //Quit
            TextMeshProUGUI quitText = GetTextMeshProUGUI(FindDescendant(pauseMenu, "Quit Mission", "Text"));
            quitText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quit;

            //Quit+Restart windows
            GameObject pauseDialogs = FindDescendant(canvasObj, "PauseMenuDialogs");

            //Quit
            GameObject quitDialog = FindDescendant(pauseDialogs, "Quit Confirm", "Panel");
            TextMeshProUGUI quitDialogText = GetTextMeshProUGUI(FindDescendant(quitDialog, "Text (2)"));
            quitDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirm;

            TextMeshProUGUI quitDialogTooltip = GetTextMeshProUGUI(FindDescendant(quitDialog, "Text (1)"));
            quitDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

            TextMeshProUGUI quitDialogYes = GetTextMeshProUGUI(FindDescendant(quitDialog, "Confirm", "Text"));
            quitDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmYes;

            TextMeshProUGUI quitDialogNo = GetTextMeshProUGUI(FindDescendant(quitDialog, "Cancel", "Text"));
            quitDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_quitConfirmNo;

            //Restart
            GameObject restartDialog = FindDescendant(pauseDialogs, "Restart Confirm", "Panel");

            TextMeshProUGUI restartDialogText = GetTextMeshProUGUI(FindDescendant(restartDialog, "Text"));
            restartDialogText.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirm;

            TextMeshProUGUI restartDialogTooltip = GetTextMeshProUGUI(FindDescendant(restartDialog, "Text (1)"));
            restartDialogTooltip.text = LanguageManager.CurrentLanguage.pauseMenu.pause_disableWindow;

            TextMeshProUGUI restartDialogYes = GetTextMeshProUGUI(FindDescendant(restartDialog, "Confirm", "Text"));
            restartDialogYes.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmYes;

            TextMeshProUGUI restartDialogNo = GetTextMeshProUGUI(FindDescendant(restartDialog, "Cancel", "Text"));
            restartDialogNo.text = LanguageManager.CurrentLanguage.pauseMenu.pause_restartConfirmNo;
        }
        catch (Exception e)
        {
            Logging.Error("Failed to patch pause menu.");
            Logging.Error(e.ToString());
        }
    }
}