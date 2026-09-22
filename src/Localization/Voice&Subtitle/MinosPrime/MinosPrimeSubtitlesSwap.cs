using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches.Subtitles;

[HarmonyPatch(typeof(MinosPrime))]
public class MinosPrimeSubtitlesSwap
{
    public static MethodInfo LocalizeMinosSubtitleMethodInfo = AccessTools.Method(
            typeof(MinosPrimeSubtitlesSwap),
            nameof(MinosPrimeSubtitlesSwap.LocalizeMinosSubtitle),
            new[] { typeof(string) }
    );

	[HarmonyTranspiler]
	[HarmonyPatch(nameof(MinosPrime.Combo))]
	[HarmonyPatch(nameof(MinosPrime.Boxing))]
	[HarmonyPatch(nameof(MinosPrime.RiderKick))]
	[HarmonyPatch(nameof(MinosPrime.DropAttack))]
	[HarmonyPatch(nameof(MinosPrime.Dropkick))]
	[HarmonyPatch(nameof(MinosPrime.Enrage))]
	private static IEnumerable<CodeInstruction> MinosPrime_SubtitlePatch(IEnumerable<CodeInstruction> instructions)
	{
		return SubtitleLocalizer.InjectLocalize2(instructions, LocalizeMinosSubtitleMethodInfo);
    }

    private static string LocalizeMinosSubtitle(string input)
    {
        if (LanguageManager.IsEnglish)
            return input;

        var s = LanguageManager.CurrentLanguage.subtitles;

        return (input switch
		{
			"Prepare thyself!" => s.subtitles_minosPrime_attack1,
			"Thy end is now!" => s.subtitles_minosPrime_attack2,
			"Die!" => s.subtitles_minosPrime_attack3,
			"Crush!" => s.subtitles_minosPrime_attack4,
			"Judgement!" => s.subtitles_minosPrime_attack5,
			"WEAK" => s.subtitles_minosPrime_phaseChange,
			_ => input,
		}).Or(input);
    }
}
