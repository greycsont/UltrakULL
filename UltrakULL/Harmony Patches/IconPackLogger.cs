using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using UnityEngine;
using static UltrakULL.CommonFunctions;
using Object = UnityEngine.Object;

namespace UltrakULL.Harmony_Patches
{
    [HarmonyPatch]
    public static class IconPackLogger
    {
        private static MonoBehaviour _coroutineStarter;
        private static bool _pendingLog;

        private static Type FindType(string typeName)
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type t = asm.GetType(typeName);
                if (t != null) return t;
                foreach (var type in asm.GetTypes())
                {
                    if (type.Name == typeName) return type;
                }
            }
            return null;
        }

        [HarmonyPatch(typeof(SceneHelper), "OnSceneLoaded")]
        [HarmonyPostfix]
        private static void OnSceneLoaded()
        {
            _pendingLog = true;
            if (_coroutineStarter == null)
            {
                var go = new GameObject("IconPackLogger_CoroutineStarter");
                _coroutineStarter = go.AddComponent<DummyMonoBehaviour>();
            }
            _coroutineStarter.StartCoroutine(DelayedLog());
        }

        [HarmonyPatch(typeof(IconManager), "Reload")]
        [HarmonyPostfix]
        private static void OnReload()
        {
            _pendingLog = true;
            if (_coroutineStarter == null)
            {
                var go = new GameObject("IconPackLogger_CoroutineStarter");
                _coroutineStarter = go.AddComponent<DummyMonoBehaviour>();
            }
            _coroutineStarter.StartCoroutine(DelayedLog());
        }

        private static IEnumerator DelayedLog()
        {
            yield return new WaitForEndOfFrame();
            yield return null;
            if (!_pendingLog) yield break;
            _pendingLog = false;

            Logging.Message("=== IconPackLogger ===");
            LogCurrentIconPack();
            Logging.Message("=== IconPackLogger END ===");
        }

        private static void LogCurrentIconPack()
        {
            try
            {
                Type iconManagerType = FindType("IconManager");
                if (iconManagerType == null) return;

                object iconManager = GetSingletonInstance(iconManagerType);
                if (iconManager == null)
                {
                    var all = Object.FindObjectsOfTypeAll(iconManagerType);
                    if (all != null && all.Length > 0)
                        iconManager = all[0];
                }
                if (iconManager == null) return;

                int packId = 0;
                var packIdProp = iconManagerType.GetProperty("CurrentIconPackId",
                    BindingFlags.Public | BindingFlags.Instance);
                if (packIdProp != null)
                    packId = (int)packIdProp.GetValue(iconManager);

                object currentIcons = GetPropertyOrField(iconManager, "CurrentIcons");
                if (currentIcons == null) return;

                var so = currentIcons as ScriptableObject;
                Logging.Message($"iconPackId={packId} icons='{so?.name ?? "?"}' ({currentIcons.GetType().Name})");

                var fields = currentIcons.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                foreach (var f in fields)
                {
                    try
                    {
                        object val = f.GetValue(currentIcons);
                        if (val is Sprite sp)
                        {
                            Logging.Message($"  {f.Name}: '{sp.name}' ({sp.texture.width}x{sp.texture.height})");
                        }
                        else if (val is Array arr)
                        {
                            Logging.Message($"  {f.Name}[{arr.Length}]:");
                            for (int i = 0; i < Math.Min(arr.Length, 60); i++)
                            {
                                var el = arr.GetValue(i);
                                if (el == null) continue;
                                var elFields = el.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                                string key = "?";
                                string sn = "null";
                                foreach (var ef in elFields)
                                {
                                    object ev = ef.GetValue(el);
                                    if (ef.Name == "key" || ef.Name == "Key")
                                        key = ev?.ToString() ?? "?";
                                    if (ev is Sprite s)
                                        sn = $"'{s.name}' ({s.texture.width}x{s.texture.height})";
                                }
                                Logging.Message($"    [{i}] '{key}' -> {sn}");
                            }
                        }
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                Logging.Warn($"[IconPackLogger] {ex.Message}");
            }
        }

        private static object GetSingletonInstance(Type type)
        {
            try
            {
                Type mono = FindType("MonoSingleton`1");
                if (mono != null)
                {
                    var g = mono.MakeGenericType(type);
                    var p = g.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
                    if (p != null) return p.GetValue(null);
                }
            }
            catch { }
            try
            {
                var p = type.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static);
                if (p != null) return p.GetValue(null);
            }
            catch { }
            return null;
        }

        private static object GetPropertyOrField(object obj, string name)
        {
            var p = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (p != null) return p.GetValue(obj);
            var f = obj.GetType().GetField(name, BindingFlags.Public | BindingFlags.Instance);
            if (f != null) return f.GetValue(obj);
            p = obj.GetType().GetProperty(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (p != null) return p.GetValue(obj);
            f = obj.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Instance);
            if (f != null) return f.GetValue(obj);
            return null;
        }

        private class DummyMonoBehaviour : MonoBehaviour { }
    }
}
