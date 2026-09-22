using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using HarmonyLib;
using UltrakULL.json;
using UnityEngine;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(GabrielVoice))]
public static class GabrielSubtitlesSwap
{
    public static MethodInfo LocalizeTauntSubtitleMethodInfo = AccessTools.Method(
            typeof(GabrielSubtitlesSwap),
            nameof(GabrielSubtitlesSwap.LocalizeTauntSubtitle),
            new[] { typeof(string), typeof(GabrielVoice) }
    );


    [HarmonyTranspiler]
    [HarmonyPatch(nameof(GabrielVoice.PhaseChange))]
    [HarmonyPatch(nameof(GabrielVoice.TauntNow))]
    public static IEnumerable<CodeInstruction> GabrielSubtitleTranspiler(IEnumerable<CodeInstruction> instructions)
    {
        return new CodeMatcher(SubtitleLocalizer.InjectLocalize2(instructions, LocalizeTauntSubtitleMethodInfo, OpCodes.Ldelem_Ref))
            .MatchForward(false, new CodeMatch(i => i.Calls(LocalizeTauntSubtitleMethodInfo)))
            .Insert(new CodeInstruction(OpCodes.Ldarg_0))
            .InstructionEnumeration();
    }

    public static string LocalizeTauntSubtitle(string input, GabrielVoice gv)
    {
        if (LanguageManager.IsEnglish)
            return input;

        var s = LanguageManager.CurrentLanguage?.subtitles;
        
        // Gabriel 2nd
        // Just for robustness
        if (gv.gameObject.name.Contains("2nd"))
            return (input switch
            {
                "YOU NEED. MORE. POWER!" => s.subtitles_gabrielSecondTaunt1,
                "Come get some BLOOD!" => s.subtitles_gabrielSecondTaunt2,
                "What is this FEELING?" => s.subtitles_gabrielSecondTaunt3,
                "NOTHING BUT SCRAP!" => s.subtitles_gabrielSecondTaunt4,
                "YOU'RE GETTING RUSTY, MACHINE!" => s.subtitles_gabrielSecondTaunt5,
                "IS THIS WHAT I LOST TO!?" => s.subtitles_gabrielSecondTaunt6,
                "TIME TO RIGHT MY WRONG!" => s.subtitles_gabrielSecondTaunt7,
                "LET'S SETTLE THIS!" => s.subtitles_gabrielSecondTaunt8,
                "I'LL SHOW YOU DIVINE JUSTICE!" => s.subtitles_gabrielSecondTaunt9,
                "Come on, machine! Fight me like an ANIMAL!" => s.subtitles_gabrielSecondTaunt10,
                "I've never had a fight like this before!" => s.subtitles_gabrielSecondTaunt11,
                "Show me what you were made for!" => s.subtitles_gabrielSecondTaunt12,
                "Now THIS is a fight worthy of God's Will!" => s.subtitles_gabrielSecondTaunt13,
                "I'll show you TRUE splendor!" => s.subtitles_gabrielSecondTaunt14,
                "IS THAT THE BEST YOU'VE GOT!?" => s.subtitles_gabrielSecondPhaseChange,

                "Machine" => s.subtitles_gabrielSecondFight1,
                "I will cut you down" => s.subtitles_gabrielSecondFight2,
                "Break you apart" => s.subtitles_gabrielSecondFight3,
                "Splay the gore of your profane form across the STARS!" => s.subtitles_gabrielSecondFight4,
                "I will grind you down until the very sparks CRY FOR MERCY!" => s.subtitles_gabrielSecondFight5,
                "My hands shall RELISH ENDING YOU..." => s.subtitles_gabrielSecondFight6,
                "HERE" => s.subtitles_gabrielSecondFight7,
                "AND" => s.subtitles_gabrielSecondFight8,
                "NOW!" => s.subtitles_gabrielSecondFight9,
                "Limbo" => s.subtitles_gabrielSecondIntro1,
                "Lust" => s.subtitles_gabrielSecondIntro2,
                "All gone..." => s.subtitles_gabrielSecondIntro3,
                "With Gluttony soon to follow." => s.subtitles_gabrielSecondIntro4,
                "Your kind know nothing but hunger" => s.subtitles_gabrielSecondIntro5,
                "Purged all life on the upper layers" => s.subtitles_gabrielSecondIntro6,
                "And yet they remain unsatiated..." => s.subtitles_gabrielSecondIntro7,
                "As do you." => s.subtitles_gabrielSecondIntro8,
                "You've taken everything from me, machine" => s.subtitles_gabrielSecondIntro9,
                "And now all that remains is" => s.subtitles_gabrielSecondIntro10,
                "PERFECT" => s.subtitles_gabrielSecondIntro11,
                "HATRED" => s.subtitles_gabrielSecondIntro12,
                "Twice!?" => s.subtitles_gabrielSecondDefeated1,
                "Beaten by an object... Twice!" => s.subtitles_gabrielSecondDefeated2,
                "I've only known the taste of victory," => s.subtitles_gabrielSecondDefeated3,
                "But this taste... Is-" => s.subtitles_gabrielSecondDefeated4,
                "Is this my blood?" => s.subtitles_gabrielSecondDefeated5,
                "I've never known such..." => s.subtitles_gabrielSecondDefeated6,
                "Such... relief..?" => s.subtitles_gabrielSecondDefeated7,
                "I- I need some time to think..." => s.subtitles_gabrielSecondDefeated8,
                "We will meet again, machine" => s.subtitles_gabrielSecondDefeated9,
                "May your woes be many..." => s.subtitles_gabrielSecondDefeated10,
                "and your days few" => s.subtitles_gabrielSecondDefeated11,

                _ => input,
            }).Or(input);

        return (input switch
        {
            "The light is perfection" => s.subtitles_gabriel_taunt1,
            "You defy the light" => s.subtitles_gabriel_taunt2,
            "A mere object" => s.subtitles_gabriel_taunt3,
            "Not. Even. Mortal." => s.subtitles_gabriel_taunt4,
            "You are less than nothing" => s.subtitles_gabriel_taunt5,
            "Foolishness, machine. Foolishness." => s.subtitles_gabriel_taunt6,
            "You're an error to be corrected" => s.subtitles_gabriel_taunt7,
            "There can be only light" => s.subtitles_gabriel_taunt8,
            "An imperfection to be cleansed" => s.subtitles_gabriel_taunt9,
            "Your crime is existence" => s.subtitles_gabriel_taunt10,
            "You make even the devil cry" => s.subtitles_gabriel_taunt11,
            "You are outclassed" => s.subtitles_gabriel_taunt12,
            "Enough!" => s.subtitles_gabriel_phaseChange,
            "BEHOLD! THE POWER OF AN ANGEL" => s.subtitles_gabriel_fightStart,

            "Machine" => s.subtitles_gabriel_intro1,
            "Turn back now." => s.subtitles_gabriel_intro2,
            "The layers of this palace are not for your kind" => s.subtitles_gabriel_intro3,
            "Turn back or you will be crossing the will of God" => s.subtitles_gabriel_intro4,
            "Your choice is made" => s.subtitles_gabriel_intro5,
            "As the righteous hand of the father" => s.subtitles_gabriel_intro6,
            "I shall rend you apart" => s.subtitles_gabriel_intro7,
            "And you will become inanimate once more" => s.subtitles_gabriel_intro8,
            "What..?" => s.subtitles_gabriel_defeated1,
            "How can this be?" => s.subtitles_gabriel_defeated2,
            "Bested by this..." => s.subtitles_gabriel_defeated3,
            "this thing..?" => s.subtitles_gabriel_defeated4,
            "You insignificant FUCK!" => s.subtitles_gabriel_defeated5,
            "THIS IS NOT OVER!" => s.subtitles_gabriel_defeated6,
            "May your woes be many" => s.subtitles_gabriel_defeated7,
            "and your days few" => s.subtitles_gabriel_defeated8,
            "Machine, I know you're here" => s.subtitles_gabrielHeresy1,
            "I can smell the insolent stench of your bloodstained hands" => s.subtitles_gabrielHeresy2,
            "I await you down below..." => s.subtitles_gabrielHeresy3,
            "COME TO ME" => s.subtitles_gabrielHeresy4,
            "Be not afraid, sinner" => s.subtitles_gabrielBoat1,
            "Your devotion to God shows goodness in you" => s.subtitles_gabrielBoat2,
            "Plentiful indeed" => s.subtitles_gabrielBoat3,
            "The heart is willing, but the body must rest" => s.subtitles_gabrielBoat4,
            "Lest you squander one of the Lord's creation." => s.subtitles_gabrielBoat5,

            _ => input,
        }).Or(input);
    }
}
