using System.Collections.Generic;


public class AngryBundles
{
    /// <summary>
    /// Guid -> bundle
    /// </summary>
    public Dictionary<string, AngryBundle> bundles = new Dictionary<string, AngryBundle>();
}

/// <summary>
/// https://github.com/eternalUnion/AngryLevelLoader/blob/release/AngryLevelLoader/DataTypes/AngryBundleData.cs
/// </summary>
public class AngryBundle
{
    /// <summary>
    /// The name of the bundle
    /// </summary>
    public string bundleName;

    /// <summary>
    /// AngryLevelLoader.DataTypes.LevelInfo.LevelId -> AngryLevel
    /// </summary>
    public Dictionary<string, AngryLevel> levels = new Dictionary<string, AngryLevel>();
}

/// <summary>
/// https://github.com/eternalUnion/AngryLevelLoader/blob/release/AngryLevelLoader/DataTypes/AngryLevelData.cs
/// </summary>
public class AngryLevel
{
    /// <summary>
    /// AngryLevelLoader.DataTypes.LevelInfo.LevelName
    /// Name of the level shown in the bundle
    /// </summary>
    public string levelNameInBundle;

    /// <summary>
    /// StockLevelInfo.LayerName
    /// Layer of the level
    /// used in Title drop
    /// Layer /// xxx or whatever
    /// </summary>
    public string levelLayer;

    /// <summary>
    /// StockLevelInfo.LevelName
    /// Name of the level
    /// used in Title drop
    /// </summary>
    public string levelName;

    /// <summary>
    /// StockLevelInfo.TipOfTheDay
    /// Tip of the day
    /// Used in Shop at the FirstRoom
    /// </summary>
    public string tipOfTheDay;

    /// <summary>
    /// AngryLevelLoader.DataTypes.LevelInfo.levelChallengeText
    /// Challenge of the level
    /// </summary>
    public string challenge;

    /// <summary>
    /// Notes of the translator
    /// could be contact information or sth
    /// </summary>
    public string translatorNotes;

    /// <summary>
    /// HudMessages
    /// the key is the original's hudmessage, value is the translated
    /// </summary>
    public Dictionary<string, string> hudMessages = new();

    /// <summary>
    /// Boooks
    /// the key is the original book's information, value is the translated
    /// </summary>
    public Dictionary<string, string> books = new();
}