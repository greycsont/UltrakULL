using System.Linq;
using PluginConfig.API;
using PluginConfig.API.Decorators;

namespace UltrakULL;

public static class AngryUtil
{
    public static void ApplyHeaders(ConfigPanel panel, (string original, string translation)[] headers)
    {
        if (panel == null)
            return;

        foreach (var field in panel.GetAllFields())
        {
            if (field is not ConfigHeader header)
                continue;

            foreach (var (original, translation) in headers)
            {
                if (header.text == original && !StringHelper.IsEmpty(translation))
                {
                    header.text = translation;
                    break;
                }
            }
        }
    }

    public static void LocalizeNotifierHeader(ConfigHeader header, string color, string englishPrefix, string template)
    {
        header.text = string.Join("\n", header.text
            .Split('\n')
            .Select(line => RewriteTemplateLine(line, color, englishPrefix, "</color>", template)));

        string RewriteTemplateLine(string line, string color, string englishPrefix, string close, string template)
        {
            // Example: "<color=#1F1E33> Update available for (LevelName)</color>"
            string open = color + englishPrefix;

            if (!line.StartsWith(open) || !line.EndsWith(close))
                return line;

            // <color=#1F1E33> Update available for |(LevelName)|</color>
            // The (LevelName) has been taken out
            string inner = line.Substring(open.Length, line.Length - open.Length - close.Length);
            if (string.IsNullOrEmpty(inner))
                return line;

            return color + string.Format(template, inner) + close;
        }
    }
}