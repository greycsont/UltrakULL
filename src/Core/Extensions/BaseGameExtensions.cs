using System.Linq;
using UnityEngine;

namespace UltrakULL;

public static class BaseGameExtensions
{
    public static GameObject GetPanel(this CyberGrindSettingsNavigator navigator, string name) =>
        navigator.allPanels.FirstOrDefault(panel => panel.name == name);
}
