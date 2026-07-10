using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ArabicSupportUnity;
using BepInEx;
using TMPro;

namespace UltrakULL.json;

public sealed class Lang
{
    public JsonFormat Json { get;}
    public string Name => Json.metadata.langName;
    public string DisplayName => Json.metadata.langDisplayName;
    public bool IsEnglish => Json.metadata.langDisplayName == "English";
    public bool IsRightToLeft => Json.metadata.langRTL;

    // Isn't this Hindi Number?
    public bool UsingHinduNumbers => Json.metadata.langHinduNumbers;

    public string SpeechFolder { get; }

    // These part will be added on language folder rework
    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }

    // Which fallbacks FontManager pushed into which game fonts while this language was active,
    // so switching away can undo exactly what this language added.
    internal readonly List<(TMP_FontAsset font, TMP_FontAsset fallback)> AppliedFallbacks = new();

    private bool rtlApplied;

    public Lang(JsonFormat json)
    {
        Json = json;
        SpeechFolder = Path.Combine(Paths.ConfigPath, "ultrakull", "audio", json.metadata.langName)
                       + Path.DirectorySeparatorChar;
    }

    // ArabicFixer.Fix rewrites Json's strings in place, so it must never run twice on the same Lang.
    public void EnsureRtlApplied()
    {
        if (!IsRightToLeft || rtlApplied)
            return;

        rtlApplied = true;
        Logging.Message("Language is an RTL - applying fix!");
        ApplyRtl(Json);
    }

    private static void ApplyRtl(JsonFormat language)
    {
        List<object> translationComponents = new List<object>
        {
            language.frontend,
            language.tutorial,
            language.prelude,
            language.act1,
            language.act2,
            language.act3,
            language.cyberGrind,
            language.primeSanctum,
            language.secretLevels,
            language.intermission,
            language.pauseMenu,
            language.options,
            language.levelNames,
            language.levelChallenges,
            language.enemyNames,
            language.enemyBios,
            language.shop,
            language.levelTips,
            language.books,
            language.visualnovel,
            language.subtitles,
            language.style,
            language.cheats,
            language.misc,
            language.devMuseum
        };

        foreach (object component in translationComponents)
        {
            try
            {
                foreach (FieldInfo field in component.GetType().GetFields())
                {
                    string original = (string)field.GetValue(component);
                    if (original != null)
                        field.SetValue(component, ArabicFixer.Fix(original));
                }
            }
            catch (Exception ex)
            {
                Logging.Warn($"ULL caught an exception while trying to fix a RTL language! {ex.Message} \nSource: {ex.Source}\nStack Trace:{ex.StackTrace}");
            }
        }
    }
}
