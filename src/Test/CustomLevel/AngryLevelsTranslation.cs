using System.Collections.Generic;


public class AngryLevelsTranslation
{
    /// <summary>
    /// Guid -> bundle
    /// </summary>
    public Dictionary<string, AngryBundle> Bundles = new Dictionary<string, AngryBundle>();
}

/// <summary>
/// https://github.com/eternalUnion/AngryLevelLoader/blob/release/AngryLevelLoader/DataTypes/AngryBundleData.cs
/// </summary>
public class AngryBundle
{
    /// <summary>
    /// The name of the bundle
    /// </summary>
    public string BundleName;

    /// <summary>
    /// Level Id -> AngryLevelTranslationData
    /// </summary>
    public Dictionary<string, AngryLevel> Levels = new Dictionary<string, AngryLevel>();
}

/// <summary>
/// https://github.com/eternalUnion/AngryLevelLoader/blob/release/AngryLevelLoader/DataTypes/AngryLevelData.cs
/// </summary>
public class AngryLevel
{
    /// <summary>
    /// Name of the level shown in the bundle
    /// </summary>
    public string LevelNameInBundle;

    /// <summary>
    /// LevelInfo.LayerName
    /// Layer of the level
    /// used in Title drop
    /// Layer /// xxx or whatever
    /// </summary>
    public string LevelLayer;

    /// <summary>
    /// LevelInfo.LevelName
    /// Name of the level
    /// used in Title drop
    /// </summary>
    public string LevelName;

    /// <summary>
    /// LevelInfo.TipOfTheDay
    /// Tip of the day
    /// Used in Shop at the FirstRoom
    /// </summary>
    public string TipOfTheDay;

    /// <summary>
    /// Challenge of the level
    /// </summary>
    public string Challenge;

    /// <summary>
    /// Notes of the translator
    /// could be contact information or sth
    /// </summary>
    public string TranslatorNotes;

    /// <summary>
    /// HudMessages
    /// the key is the original's hudmessage, value is the translated
    /// </summary>
    public Dictionary<string, string> HudMessages;

    /// <summary>
    /// Boooks
    /// the key is the original book's information, value is the translated
    /// </summary>
    public Dictionary<string, string> Books;
}