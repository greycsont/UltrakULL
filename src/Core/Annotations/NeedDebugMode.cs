namespace UltrakULL;

/// <summary>
/// What is Debug mode?
/// it's basically a mode for translater to know when there's a text not translated
/// Atm when there's a text not translated, it will just display null
/// in the incoming future update the non-translated text will not be placed
/// this is a pointer to indicate which part need to implement that mode
/// </summary>
public class NeedDebugMode : System.Attribute
{
}