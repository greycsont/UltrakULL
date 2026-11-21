using System;
using UnityEngine;
using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class Core
{
	public static bool wasLanguageReset = false;

    /// <param name="sceneEntry">
    /// True when the scene was freshly loaded. Scene-entry-only tweaks
    /// (like AdjustOptionTextPosition) must not re-run when language change
    /// </param>
    public static void LocalizeScene(bool sceneEntry)
    {
        string levelName = GetCurrentSceneName();

        // Don't do anything if we're still booting up the game.
        if(levelName == "Intro" || levelName == "Bootstrap")
        { 
            //Logging.Warn("In intro, not hooking yet");
            return;
        }

        switch(levelName) 
        { 
            case "Main Menu":
            {
                if(Core.wasLanguageReset)
                {
                    Core.wasLanguageReset = false;
                    MonoSingleton<HudMessageReceiver>.Instance?.SendHudMessage("<color=orange>The currently set language file could not be loaded.\nLanguage has been reset to English to avoid problems.</color>");
                }

                MainMenu.Patch();

                break;
            }
            default:
            {
                if (sceneEntry)
                    UILayoutOverride.AdjustOptionTextPosition();
                if (LanguageManager.IsEnglish)
                {
                    Logging.Warn("Current language is English, not patching.");
                    break;
                }
                
                Logging.Message("Regular scene");

                LevelPatcher.Patch(levelName);
                break;
            }
        }
    }
}
