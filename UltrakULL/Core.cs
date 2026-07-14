using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
using HarmonyLib;
using Newtonsoft.Json;
using TMPro;
using UltrakULL.json;
using static UltrakULL.CommonFunctions;

namespace UltrakULL;

public static class Core
{
	public static bool wasLanguageReset = false;

    public static void HandleSceneSwitch(Scene scene,ref GameObject canvas)
    {
        string levelName = GetCurrentSceneName();

        // Don't do anything if we're still booting up the game.
        if(levelName == "Intro" || levelName == "Bootstrap")
        { 
            //Logging.Warn("In intro, not hooking yet");
            return;
        }
        
        //Each scene (level) has an object called Canvas. Most game objects are there.
        GameObject canvasObj = GetInactiveRootObject("Canvas");
        if (!canvasObj)
        {
            Logging.Fatal("UNABLE TO FIND CANVAS IN CURRENT SCENE");
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

                MainMenu.Patch(canvasObj);
                Options.Patch(ref canvasObj);

                break;
            }
            default:
            {
                if (isUsingEnglish())
                {
                    Logging.Warn("Current language is English, not patching.");
                    return;
                }
                
                Logging.Message("Regular scene");

                PatchingBaseElements(ref canvasObj);

                HandleLevelPatching(levelName, ref canvasObj);

                break;
            }
        }
    }

    private static void PatchingBaseElements(ref GameObject canvasObj)
    {
        Logging.Message("Attempting to patch base elements");
        try{_PauseMenu.PatchPauseMenu(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
        try{Cheats.PatchCheatConsentPanel(ref canvasObj);;} catch(Exception e){Console.WriteLine(e.ToString());}
        try{Sandbox.PatchAlterMenu();} catch(Exception e){ Console.WriteLine(e.ToString());}
        try{HUDMessages.PatchDeathScreen(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
        try{LevelStatWindow.PatchStats(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
        try{HUDMessages.PatchMisc(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}
        try{Options.Patch(ref canvasObj);} catch(Exception e){Console.WriteLine(e.ToString());}

        Logging.Message("Base elements patched");
    }

    private static void HandleLevelPatching(string levelName, ref GameObject canvasObj)
    {
        if (levelName.Contains("Tutorial"))
        { 
            Logging.Message("Tutorial");
        }
        else if (levelName.Contains("-S"))
        {
            Logging.Message("Secret");
            SecretLevels.Patch(ref canvasObj);
        }
        if(levelName.Contains("0-"))
        { 
            Logging.Message("Prelude");
            Prelude.Patch(ref canvasObj);
        }
        else if(levelName.Contains("1-") || levelName.Contains("2-") || levelName.Contains("3-"))
        {
            Logging.Message("Act 1");
            Act1.PatchAct1(ref canvasObj);
        }
        else if(levelName.Contains("4-") || levelName.Contains("5-") || levelName.Contains("6-"))
        {
            Logging.Message("Act 2");
            Act2.PatchAct2(ref canvasObj);
        }
        else if(levelName.Contains("7-") || levelName.Contains("8-") || levelName.Contains("9-"))
        {
            Logging.Message("Act 3");
            Act3.PatchAct3(ref canvasObj);
        }
        else if (levelName.Contains("P-"))
        {
            Logging.Message("Prime");
            PrimeSanctum.Patch();
        }
        else if (levelName == "uk_construct")
        { 
            Logging.Message("Sandbox");
            Sandbox.Patch(ref canvasObj);
        }
        else if (levelName == "Endless")
        {
            Logging.Message("CyberGrind");
            CyberGrind.PatchCg();
        }
        else if (levelName.Contains("Intermission") || levelName.Contains("EarlyAccessEnd"))
        {
            Logging.Message("Intermission");
            Intermission.Patch(ref canvasObj);
        }
        else if (levelName == "CreditsMuseum2")
        {
            Logging.Message("DevMuseum");
            DevMuseum.Patch();
        }
    }

    public static async void ApplyPostInitFixes(GameObject canvasObj)
    {
        await Task.Delay(250);
        if (GetCurrentSceneName() == "Main Menu")
        {
            //Open Language Folder button in Options->Language
            TextMeshProUGUI openLangFolderText = GetTextMeshProUGUI(
                FindDescendant(canvasObj,
                "OptionsMenu", 
                "Language Page",
                "Scroll Rect (1)",
                "Contents",
                "OpenLangFolder",
                "Slot Text")
            );
            if (openLangFolderText != null)
                openLangFolderText.text = "<color=#03fc07>Open language folder</color>";
            
        }
    }
}
