using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using TMPro;
using UltrakULL.json;

namespace UltrakULL.Harmony_Patches;

[HarmonyPatch(typeof(CheatsManager))]
public static class CheatsManagerPatch
{
    [HarmonyPatch(nameof(CheatsManager.StartRebind))] [HarmonyPostfix]
    public static void StartRebind_Postfix(CheatsManager __instance, ref ICheat cheat) 
    {
        __instance.menuItems[cheat].bindButtonText.text = LanguageManager.CurrentLanguage.cheats.cheats_pressAnyKey;
    }

    /// <summary>
    /// It basically get a methodInfo of key getter
    /// And a MethodInfo of our translation function
    /// Then place the translation call after the getter to translate its return value.
    /// 
    /// // cheatMenuItem.longName.text = allRegisteredCheat.Key;
	/// IL_0064: ldfld class [Unity.TextMeshPro]TMPro.TMP_Text CheatMenuItem::longName
	/// IL_0069: ldloca.s 1
	/// IL_006b: call instance !0 valuetype [netstandard]System.Collections.Generic.KeyValuePair`2<string, class [netstandard]System.Collections.Generic.List`1<class ICheat>>::get_Key()
    /// <= INSERT HERE!
	/// IL_0070: callvirt instance void [Unity.TextMeshPro]TMPro.TMP_Text::set_text(string)
    /// </summary>
    [HarmonyPatch(nameof(CheatsManager.RebuildMenu)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> RebuildMenu_Transpiler(IEnumerable<CodeInstruction> instructions, ILGenerator generator)
    {
        var categoryKeyGetter = AccessTools.PropertyGetter(
            typeof(KeyValuePair<string, List<ICheat>>),
            nameof(KeyValuePair<string, List<ICheat>>.Key));

        var localizeCategory = AccessTools.Method(
            typeof(CheatsManagerPatch),
            nameof(LocalizeCategory));
            
        return new CodeMatcher(instructions, generator)
            .MatchForward(false, new CodeMatch(instruction => instruction.Calls(categoryKeyGetter)))
            .ThrowIfNotMatch("Could not find the cheat category key in CheatsManager.RebuildMenu")
            .Advance(1)
            .Insert(new CodeInstruction(OpCodes.Call, localizeCategory))
            .InstructionEnumeration();
    }

    private static string LocalizeCategory(string category)
    {
        if (LanguageManager.IsEnglish)
        {
            return category;
        }

        return category switch
        {
            "META" => LanguageManager.CurrentLanguage.cheats.cheats_categoryMeta,
            "SANDBOX" => LanguageManager.CurrentLanguage.cheats.cheats_categorySandbox,
            "GENERAL" => LanguageManager.CurrentLanguage.cheats.cheats_categoryGeneral,
            "MOVEMENT" => LanguageManager.CurrentLanguage.cheats.cheats_categoryMovement,
            "WEAPONS" => LanguageManager.CurrentLanguage.cheats.cheats_categoryWeapons,
            "ENEMIES" => LanguageManager.CurrentLanguage.cheats.cheats_categoryEnemies,
            "VISUAL" => LanguageManager.CurrentLanguage.cheats.cheats_categoryVisual,
            "SPECIAL" => LanguageManager.CurrentLanguage.cheats.cheats_categorySpecial,
            _ => category
        };
    }


    [HarmonyPatch(nameof(CheatsManager.UpdateCheatState),new Type[] { typeof(CheatMenuItem), typeof(ICheat) })] [HarmonyPostfix]
    public static void UpdateCheatState_Postfix(CheatMenuItem item, ICheat cheat)
    {
        item.longName.text = Cheats.GetCheatName(cheat.Identifier);

        string status = Cheats.GetCheatStatus(
            cheat.IsActive
                ? cheat.ButtonEnabledOverride
                : cheat.ButtonDisabledOverride);

        item.stateText.text = status ?? (cheat.IsActive
            ? LanguageManager.CurrentLanguage.cheats.cheats_activated
            : LanguageManager.CurrentLanguage.cheats.cheats_deactivated);

        if (string.IsNullOrEmpty(
            MonoSingleton<CheatBinds>.Instance.ResolveCheatKey(cheat.Identifier)))
        {
            item.bindButtonText.text = LanguageManager.CurrentLanguage.cheats.cheats_pressToBind;
        }

        item.resetBindButton.GetComponentInChildren<TMP_Text>().text =
            LanguageManager.CurrentLanguage.cheats.cheats_delete;
    }

    [HarmonyPatch(nameof(CheatsManager.RenderCheatsInfo)), HarmonyTranspiler]
    public static IEnumerable<CodeInstruction> RenderCheatsInfo_Transpiler(
        IEnumerable<CodeInstruction> instructions,
        ILGenerator generator)
    {
        var longNameGetter = AccessTools.PropertyGetter(
            typeof(ICheat),
            nameof(ICheat.LongName));

        var localizeCheatName = AccessTools.Method(
            typeof(CheatsManagerPatch),
            nameof(LocalizeCheatName));

        return new CodeMatcher(instructions, generator)
            .MatchForward(false, new CodeMatch(instruction => instruction.Calls(longNameGetter)))
            .ThrowIfNotMatch("Could not find ICheat.LongName in CheatsManager.RenderCheatsInfo")
            .SetInstruction(new CodeInstruction(OpCodes.Call, localizeCheatName))
            .InstructionEnumeration();
    }

    private static string LocalizeCheatName(ICheat cheat)
    {
        if (LanguageManager.IsEnglish)
        {
            return cheat.LongName;
        }

        string localizedName = Cheats.GetCheatName(cheat.Identifier);
        return string.IsNullOrEmpty(localizedName) || localizedName == cheat.Identifier
            ? cheat.LongName
            : localizedName;
    }

    [HarmonyPatch(nameof(CheatsManager.RenderCheatsInfo)), HarmonyPostfix]
    public static void RenderCheatsInfo_Postfix()
    {
        if (LanguageManager.IsEnglish)
        {
            return;
        }

        var cheatsInfo = MonoSingleton<CheatsController>.Instance?.cheatsInfo;

        cheatsInfo.text = cheatsInfo.text
            .Replace(
                "NAVMESH OUT OF DATE",
                LanguageManager.CurrentLanguage.cheats.cheats_navmeshOutdated1)
            .Replace(
                "(Rebuild navigation in cheats menu)",
                LanguageManager.CurrentLanguage.cheats.cheats_navmeshOutdated2)
            .Replace(
                "Spawner Arm in slot 6",
                LanguageManager.CurrentLanguage.cheats.cheats_spawnerArmSlot);
    }
}
