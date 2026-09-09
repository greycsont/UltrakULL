using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace UltrakULL.json;

/// <summary>
/// In the LanguageManager.cs
/// The json should be the only one in the lang
/// For the FontAsset, when switching the currentlanguage to it's own
/// load the FontAsset
/// </summary>
public sealed class Lang
{
    public JsonFormat Json { get;}

    public AngryLevelSettingTranslation angry = new AngryLevelSettingTranslation()
    {
        rootPanel = new RootPanel()
        {
            onlineLevels = "在线关卡",
            onlineLevelsHeader = "--在线关卡--",
            open = "打开",
            leaderboardBannedMods = "排行榜封禁的模组",
            pendingRecords = "待处理记录",
            sendPendingRecords = "发送待处理记录",
            changelog = "更新日志",
            settings = "设置",
            scanForLevels = "扫描关卡",
            viewReports = "查看报告",
            levelBundles = "关卡包",
            newLevelNotifier = "新关卡：{0}",
            newUpdateNotifier = "更新可用：{0}"
        },
        settingPanel = new SettingPanel()
        {
            settingsHeader = "--设置--",
            openLevelsFolder = "打开关卡目录",
            openScriptsFolder = "打开脚本目录",
            reloadFile = "重载文件",
            reloadScript = "重载脚本",
            unityLogLevel = "Unity 日志级别",
            customLevelButtonPosition = "自定义关卡按钮位置",
            customLevelButtonFrameColor = "自定义关卡按钮边框颜色",
            customLevelButtonTextColor = "自定义关卡按钮文字颜色",
            customLevelButtonColors = "自定义关卡按钮颜色",
            showLeaderboardOnLevelEnd = "结算时显示排行榜",
            showLeaderboardOnSecretLevelEnd = "秘密关结算时显示排行榜",
            defaultLeaderboardCategory = "默认排行榜分类",
            defaultLeaderboardDifficulty = "默认排行榜难度",
            defaultLeaderboardFilter = "默认排行榜过滤",
            refreshCatalogOnBoot = "启动时刷新在线目录",
            useDevelopmentBranch = "使用开发通道",
            useLocalServer = "使用本地服务器",
            levelUpdateNotifier = "关卡更新时通知",
            levelUpdateIgnoreCustomBuilds = "忽略自定义构建的更新",
            newLevelNotifierToggle = "新关卡发布时通知",
            scriptUpdateIgnoreCustomBuilds = "忽略自定义构建的更新",
            scriptCertificateIgnore = "忽略证书",
            reloadAlwaysGoToMainMenu = "主菜单快速重载",
            bundleFavSort = "按收藏排序",
            bundleSortingMode = "关卡包排序方式",
            leaderboardToggle = "向排行榜提交记录",
            dataPath = "数据路径",
            moveData = "移动数据",
            deleteOldBundles = "删除旧关卡包",
        },
        sortingOption = new SortingOption()
        {
            name = "名称",
            author = "作者",
            lastUpdate = "更新日期",
            lastPlayed = "最后游玩时间",
            votes = "投票数",
        },
        bundleStatus = new BundleStatus()
        {
            notInstalled = "未安装",
            installed = "已安装",
            updateAvailable = "有更新",
        },
        headers = new PanelHeaders()
        {
            userInterface = "用户界面",
            leaderboards = "排行榜",
            online = "在线",
            scripts = "脚本",
            compatibility = "兼容性",
            dangerZone = "危险区域",
            difficultyOverrideWarning = "难度已被游戏模式覆盖\n警告：部分关卡可能与游戏模式不兼容",
        },
        bundlePanel = new BundlePanel
        {
            by = "作者:",
            reloadFile = "重新加载文件",
            forceReloadFile = "强制重新加载文件",
            levels = "关卡",
        },
        onlineLevel = new OnlineLevel
        {
            install = "安装",
            update = "更新",
            changelog = "更新日志",
        },
        onlineSearchInfo = "显示在 {1} 里的 {0} 个结果",
    };
    public string Name => Json.metadata.langName;
    public string DisplayName => Json.metadata.langDisplayName;
    public bool IsEnglish => Json.metadata.langDisplayName == "English";
    public bool IsRightToLeft => Json.metadata.langRTL;
    public bool UseFontFallback => Json.metadata.fonts?.UseFallback ?? false;

    public string SpeechFolder { get; }
    public string TextureFolder { get; }
    public string AngryLevelFolder { get; }
    public UILayoutProfile Layout { get; }

    internal AssetBundle FontBundle { get; set; }
    public TMP_FontAsset MainFontAsset { get; set; }
    public TMP_FontAsset TerminalAsset { get; set; }
    public TMP_FontAsset SecretTerminalAsset { get; set; }
    public TMP_FontAsset MuseumAsset { get; set; }

    // Which fallbacks FontManager pushed into which game fonts while this language was active,
    // so switching away can undo exactly what this language added.
    internal readonly List<(TMP_FontAsset font, TMP_FontAsset fallback)> AppliedFallbacks = new();

    public Lang(JsonFormat json, string packageFolder = null, UILayoutProfile layout = null)
    {
        Json = json;
        Layout = layout;
        SpeechFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "audio"),
            ConfigPaths.GetLegacyAudioDirectory(Name));
        TextureFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "textures"),
            ConfigPaths.GetLegacyTextureDirectory(Name));
        AngryLevelFolder = ResolveDirectory(
            packageFolder == null ? null : Path.Combine(packageFolder, "angry"),
            ConfigPaths.GetLegacyAngryDirectory(Name)
        );

        //JsonConvert.DeserializeObject<AngryLevelBundleTranslationData>(Path.Combine(AngryLevelFolder, "angry.json"));
    }

    private static string ResolveDirectory(params string[] candidates)
        => candidates.FirstOrDefault(Directory.Exists)
        ?? candidates.First(path => path != null);

}
