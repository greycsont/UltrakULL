using UltrakULL.json;

using static UltrakULL.SceneObjects;

namespace UltrakULL;

public static class PrimeSanctumStrings
{
    public static string GetSecretText()
    {
        var t = LanguageManager.CurrentLanguage.primeSanctum;

        switch (GetCurrentSceneName())
        {
            case "Level P-1":
                return t.primeSanctum_first_secretText1 + "\n"
                    + t.primeSanctum_first_secretText2 + "\n\n"
                    + t.primeSanctum_first_secretText3 + "\n\n"
                    + t.primeSanctum_first_secretText4 + "\n"
                    + t.primeSanctum_first_secretText5 + "\n\n"
                    + t.primeSanctum_first_secretText6 + "\n\n"
                    + t.primeSanctum_first_secretText7 + "\n\n"
                    + t.primeSanctum_first_secretText8 + "\n\n"
                    + t.primeSanctum_first_secretText9;

            case "Level P-2":
                return t.primeSanctum_second_secretText1 + "\n"
                    + t.primeSanctum_second_secretText2 + "\n"
                    + t.primeSanctum_second_secretText3 + "\n\n"
                    + t.primeSanctum_second_secretText4 + "\n\n"
                    + t.primeSanctum_second_secretText5 + "\n\n"
                    + t.primeSanctum_second_secretText6 + "\n\n"
                    + t.primeSanctum_second_secretText7 + "\n\n"
                    + t.primeSanctum_second_secretText8 + "\n\n"
                    + t.primeSanctum_second_secretText9 + "\n\n"
                    + t.primeSanctum_second_secretText10 + "\n\n"
                    + t.primeSanctum_second_secretText11 + "\n\n"
                    + t.primeSanctum_second_secretText12 + "\n\n"
                    + t.primeSanctum_second_secretText13 + "\n\n";

            default:
                return "Unknown secret text";
        }
    }
}
