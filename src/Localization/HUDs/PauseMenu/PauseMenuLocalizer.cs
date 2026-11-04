using System;
using UnityEngine;
using TMPro;
using UltrakULL.json;

using static UltrakULL.json.LanguageManager;
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
        pauseMenu.Localize<TextMeshProUGUI>("-- {0} --".FormatWith(CurrentLanguage.pauseMenu.pause_title),
            path: ["Text"]);

        //Resume
        pauseMenu.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_resume,
            path: ["Resume", "Text"]);

        //Checkpoint
        pauseMenu.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_respawn,
            path: ["Restart Checkpoint", "Text"]);

        //Restart mission
        pauseMenu.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_restart,
            path: ["Restart Mission", "Text"]);

       //Options
        pauseMenu.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_options,
            path: ["Options", "Text"]);

        //Quit
        pauseMenu.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_quit,
            path: ["Quit Mission", "Text"]);
    }

    public static void LocalizeQuitDialog(GameObject quitDialog)
    {
        var quitPanel = FindDescendant(quitDialog, "Panel");

        quitPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_quitConfirm,
            path: ["Text (2)"]);

        quitPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_disableWindow,
            path: ["Text (1)"]);

        quitPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_quitConfirmYes,
            path: ["Confirm", "Text"]);

        quitPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_quitConfirmNo,
            path: ["Cancel", "Text"]);
    }

    public static void LocalizeResetDialoge(GameObject resetDialog)
    {
        //Restart
        var resetPanel = FindDescendant(resetDialog, "Panel");

        resetPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_restartConfirm,
            path: ["Text"]);

        resetPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_disableWindow,
            path: ["Text (1)"]);

        resetPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_restartConfirmYes,
            path: ["Confirm", "Text"]);

        resetPanel.Localize<TextMeshProUGUI>(CurrentLanguage.pauseMenu.pause_restartConfirmNo,
            path: ["Cancel", "Text"]);
    }
}
