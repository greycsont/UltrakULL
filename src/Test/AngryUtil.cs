
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
}