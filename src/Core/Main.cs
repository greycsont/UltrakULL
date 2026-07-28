using HarmonyLib;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UltrakULL.json;
using BepInEx;
using System.Reflection;
using UltrakULL.audio;
using static UltrakULL.SceneObjects;

/*
 *	UltrakULL (Ultrakill Language Library)
 *	Written by Clearwater
 *  	Additional code contributions by Temperz87, Flazhik, BitKoven, CoatlessAli and others
 *  	Translations by UltrakULL Translation Team
 *	Date started: 21st April 2021
 *	Last updated: 12th March 2024
 *	
 *	A translation mod for Ultrakill that hooks into the game and allows for text/string replacement. This tool is primarily meant to assist with language translation.
 * 
 * 
 *  -- LONG-TERM TASK LIST --
 * Better error handling
 * Bundle submitted voice packs with language downloads (EternalUnion recommends Google Drive)
 * Sit down and finish audio documentation
 * Figure out why online language browser breaks sometimes. Seems to happen at random with no singular cause. Quick game restart usually fixes.
 * Clean up logging, redirect or simplify non-breaking warnings & errors.
 * Swap rank textures in HUD for translated ones (there's already a mod that allows this. Will need to either integrate or copy code from it)
 * 
 * 
 * -- STUFF FOR NEXT UPDATE --
 * Nothing yet :)
 * 
 * 
 * -- REPORTED STUFF TO INVESTIGATE --
 * Spawning MDK+Owl while noclipped causes a crash. Function that's causing it: MandaloreSubtitlesSwap->Mandalore_Start
 * Offending transpiler lines have been commented out for now. Waiting for Flazhik to look at and fix.
 * 14c Update completely messed up MDK/Owl. Yet again. Pain. 
 * r2modman messes up font files with extentions that makes the detection skip them (https://discord.com/channels/1017473804592754778/1017898261660565675/1228095247163068567)
 * 
 *
 * -- TODO --
 * Make 2 materials for the font, one with a shadow and the other without, and only apply the shadow version on level title pop-ups
 * 
 *
 * -- TESTING REPORTS --
 * "Home or ~" cheat string isn't translated
 * The arm alter menu isn't fully translated and mostly doesn't work outside of the Sandbox
 * '0' has weird spacing with the font
 * 
 * */

namespace UltrakULL;

[BepInPlugin(Guid, InternalName, InternalVersion)]
public class MainPatch : BaseUnityPlugin
{
	private const string Guid = "clearwater.ultrakill.ultrakull";
	private const string InternalName = "clearwater.ultrakull.ultrakULL";
	private const string InternalVersion = "1.3.0";

	public static MainPatch Instance;
	public bool ready;

	public static string ModFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
	
	public static string GetVersion() => InternalVersion;

	public void OnApplicationQuit()
	{
		LanguageManager.DumpLastLanguage();
	}

	public void DisableMod()
	{
		this.ready = false;
	}

	/// <summary>
	/// THIS IS THE ENTRY OF THE MOD!
	/// PLEASE PUT EVERYTHING WHEN LAUNCHING IN HERE
	/// </summary>
	private void Awake()
	{
		Instance = this;
		Debug.unityLogger.filterLogType = LogType.Exception;
		gameObject.hideFlags = HideFlags.DontSaveInEditor;

		Logging.Warn("UltrakULL Loading... | Version v." + InternalVersion);
		try
		{
			Logging.Warn("--- Loading default fonts ---");
			FontManager.LoadFonts();

			// Must happen before InitializeManager
			// These two mf is to register event in LanguageManager
			// For handling Language Switching
			Logging.Warn("--- Register events ---");
			FontManager.Initialize();
			SubtitleLocalizer.Initialize();

			Logging.Warn("--- Initializing language manager ---");
			LanguageManager.InitializeManager(InternalVersion);
			
			Logging.Warn("--- Patching vanilla game functions ---");
			new Harmony(InternalName).PatchAll();

			Logging.Warn(" --- All done. Enjoy! ---");
			SceneManager.sceneLoaded += onSceneLoaded;
			this.ready = true;
		}
		catch (Exception e)
		{
			Logging.Fatal("An error occured while initialising!");
			Logging.Fatal(e.ToString());
			this.ready = false;
		}
	}
	
	/// <summary>
	/// For everything you want to do it on Scene Switching.
	/// Please put it to here!
	/// Because if not it will make the whole logics on Scene Switching into chaotic.
	/// Love you.
	/// </summary>
	/// <param name="scene">scene after loaded</param>
	/// <param name="mode">the load mode of scene (ULTRAKILL mostly uses Single)</param>
	public void onSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (!this.ready || LanguageManager.CurrentLanguage == null)
		{
			Logging.Error("UltrakULL has been deactivated to prevent crashing. Check the console for any errors!");
			return;
		}

		ClearObjectCaches(scene, mode);
		FontManager.RefreshFallback();                 
		GameObject canvasObj = GetInactiveRootObject("Canvas");
		Core.HandleSceneSwitch(scene, ref canvasObj);
		AudioSwapper.OnSceneLoaded(GetCurrentSceneName());

		RunDeferred(canvasObj);
	}

	// Some objects only appear a moment after the scene loads, so this second wave waits first.
	// I have no idea why clearwater do this but it may have some reason so I kept
	private async void RunDeferred(GameObject canvasObj)
	{
		await Task.Delay(250);
		Core.ApplyPostInitFixes(canvasObj);
		SubtitledAudioSourcesReplacer.ReplaceSubsAndAudio();
	}
}
