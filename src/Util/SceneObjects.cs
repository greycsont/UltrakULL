using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UltrakULL;

public static class SceneObjects
{
    private static readonly Dictionary<string, GameObject> RootObjectCache = new();
    private static readonly Dictionary<(GameObject, string), GameObject> ChildCache = new();

    public static void ClearObjectCaches(Scene scene, LoadSceneMode mode)
    {
        RootObjectCache.Clear();
        ChildCache.Clear();
    }

    public static GameObject GetInactiveRootObject(string objectName)
    {
        if (RootObjectCache.TryGetValue(objectName, out GameObject cached))
        {
            if (cached != null)
                return cached;
            RootObjectCache.Remove(objectName);
        }

        List<GameObject> roots = new();
        SceneManager.GetActiveScene().GetRootGameObjects(roots);
        foreach (GameObject root in roots)
        {
            if (root != null && root.name == objectName)
            {
                RootObjectCache[objectName] = root;
                return root;
            }
        }

        return null;
    }

    public static string GetCurrentSceneName()
    {
        return SceneHelper.CurrentScene;
    }

    public static GameObject FindDescendant(GameObject parentObject, params string[] childPath)
    {
        if (parentObject == null || childPath == null || childPath.Length == 0)
            return null;

        GameObject currentObject = parentObject;
        foreach (string childName in childPath)
        {
            currentObject = GetGameObjectChild(currentObject, childName);
            if (currentObject == null)
                return null;
        }

        return currentObject;
    }

    public static GameObject GetGameObjectChild(GameObject parentObject, string childToFind)
    {
        if (parentObject == null)
            return null;

        var key = (parentObject, childToFind);
        if (ChildCache.TryGetValue(key, out GameObject cached))
        {
            if (cached != null)
                return cached;
            ChildCache.Remove(key);
        }

        Transform transform = parentObject.transform.Find(childToFind);
        GameObject result = transform != null ? transform.gameObject : null;
        ChildCache[key] = result;
        return result;
    }

    public static Text GetTextfromGameObject(GameObject gameObject)
    {
        return gameObject == null ? null : gameObject.GetComponent<Text>();
    }

    public static TextMeshProUGUI GetTextMeshProUGUI(GameObject gameObject)
    {
        return gameObject == null ? null : gameObject.GetComponent<TextMeshProUGUI>();
    }

    public static T FindComponent<T>(GameObject gameObject, params string[] childPath) where T : Component
    {
        var targetObject = childPath == null || childPath.Length == 0 ? gameObject : FindDescendant(gameObject, childPath);
        return targetObject != null ? targetObject.GetComponent<T>() : null;
    }

    public static GameObject GetObject(string path)
    {
        string rootPath;
        string restPath = null;

        if (!path.Contains('/'))
            rootPath = path;
        else
        {
            string[] pathParts = path.Split(new[] { '/' }, 2);
            rootPath = pathParts[0];
            restPath = pathParts[1];
        }

        List<GameObject> roots = new();
        SceneManager.GetActiveScene().GetRootGameObjects(roots);
        GameObject rootPart = roots.FirstOrDefault(child => child.name == rootPath);
        if (rootPart == null)
            return null;

        return restPath == null
            ? rootPart
            : rootPart.transform.Find(restPath).gameObject;
    }
}
