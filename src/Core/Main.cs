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
	internal const string InternalVersion = "1.3.0";

	public static MainPatch Instance;
	public bool ready;

	public static string ModFolder => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
	
	public static string GetVersion() => InternalVersion;

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
			InitializeLocalization();

			Logging.Warn(" --- All done. Enjoy! ---");
			this.ready = true;
			SceneManager.sceneLoaded += OnSceneLoaded;
		}
		catch (Exception e)
		{
			Logging.Fatal("An error occured while initialising!");
			Logging.Fatal(e.ToString());
			Logging.Fatal($"Scene name: {GetCurrentSceneName()}");
			this.ready = false;
		}
	}

	private static void InitializeLocalization()
	{
		Logging.Warn("--- Initializing config ---");
		Settings.InitializeConfig();

		Logging.Warn("--- Loading shared font assets ---");
		FontManager.LoadFonts();

		// Register listeners before selecting the initial language so every subsystem receives it.
		Logging.Warn("--- Registering language-change handlers ---");
		FontManager.Initialize();
		TextMeshProFontSwap.Initialize();
		SubtitleLocalizer.Initialize();
		TextureSwapper.Initialize();
		UILayoutOverride.Initialize();

		Logging.Warn("--- Loading languages and selecting the active language ---");
		LanguageManager.InitializeManager(InternalVersion);

		Logging.Warn("--- Installing game hooks ---");
		new Harmony(InternalName).PatchAll();
	}

	/// <summary>
	/// For everything you want to do it on Scene Switching.
	/// Please put it to here!
	/// Because if not it will make the whole logics on Scene Switching into chaotic.
	/// Love you.
	/// </summary>
	/// <param name="sceneEntry">True when the scene was freshly loaded; false when the active
	/// scene is being re-localized after a language change.</param>
	private void ApplySceneLocalization(Scene scene, LoadSceneMode mode, bool clearObjectCaches, bool sceneEntry)
	{
		if (!this.ready || LanguageManager.CurrentLanguage == null)
		{
			Logging.Error("UltrakULL has been deactivated to prevent crashing. Check the console for any errors!");
			return;
		}

		if (clearObjectCaches)
			ClearObjectCaches(scene, mode);

		FontManager.RefreshFallback();                 
		GameObject canvasObj = GetInactiveRootObject("Canvas");
		Core.LocalizeScene(canvasObj, sceneEntry);
		AudioSwapper.OnSceneLoaded(GetCurrentSceneName());

		RunDeferred(scene.handle);
	}

	private async void RunDeferred(int sceneHandle)
	{
		await Task.Delay(250);

		if (SceneManager.GetActiveScene().handle != sceneHandle)
			return;

		SubtitledAudioSourcesReplacer.ReplaceSubsAndAudio();
		TextureSwapper.Apply();
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		ApplySceneLocalization(scene, mode, clearObjectCaches: true, sceneEntry: true);
	}

	public void RefreshCurrentScene()
	{
		ApplySceneLocalization(SceneManager.GetActiveScene(), LoadSceneMode.Single, clearObjectCaches: false, sceneEntry: false);
	}
}
