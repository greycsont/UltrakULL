## 1.4.0
- 修复了 MANADEL LEHAHIAN 和 CHAUKIAH 的字幕没有翻译的问题
- 修复了 Gabriel 二战的 taunt13 没有翻译的问题
- 修复了 2-S，Intermission1 和 Intermission2 的文字会上下跳动的问题
- 修复了 assist consent 面板的字体大小不是 20 而是 18 的问题
- 修复了结算界面的 P 除非点数变化否则不会被翻译的问题
- 修复了 insurrectionist 在敌人信息的标题用的是它的 boss 的名字的问题
- 修复了 设置里 COLOR 界面的敌人名字没全大写的问题
- 修复了 intermission 的跳过键没翻译的问题
- 修复了 0-E 的 heat resistance 的问题
- 修复了 1-E 的警告文本没有翻译的问题
- 修复了 多次重新加载关卡后 StaticBatchingAtlasSwapper 的检测会用原纹理去检测翻译后纹理的问题
- 修复了教程的音频滑条最小值没有翻译的问题
- 修复了教程的校准状态没有翻译的问题

- 移除了 LevelString.cs 里所有硬编码的单引号（也就是 HudMessage 的信息，比如教程里的教学显示的字幕）
- 移除了 Cybergrind.cs 里所有硬编码的冒号

- 将设置里的Color页面里所有敌人名字强制大写

- 修正了因为把 `fs-tahoma-8px-v2 SDF` 打成 `fs-tahoma-8px SDF v2` 导致字体检测错误的问题

- 在（插件）/fonts/（语言Id）下添加了 layout.json，用于UI适配
- 在（插件）/fonts/（语言Id）下添加了 fontconfig.json，用于选择字体和是否作为fallback font使用

- 添加了西班牙语和捷克语的相关字体（感谢DjPixel_）

- 添加了 AngryLevelLoader 的书/标题/hudMessage/tipOfTheDay/关卡名的翻译支持
- 添加了 AngryLevelLoader 的 UI 翻译支持（除了某些更新信息以外大部分使用例都覆盖了）
- 添加了关卡传送点的翻译支持
- 添加了 custom palette 的翻译支持（当然只有官方自己的）

字段修改
- 废弃了 langHindusNumbers （实现过于脑残，不清楚currentwave要不要废弃）
- 添加了 misc.teleportLevels 字典用于翻译传送点
- 重命名 shop_colorsAlternative 为 shop_colorsAlternate（我不想指名道姓但那个神人为了个错别字改字段名破坏兼容性搞得我也要改真是）

- 添加了 Option.graphics_customColorPaletteGamebotColor;
- 添加了 Option.graphics_customColorPaletteNoir;
- 添加了 Option.graphics_customColorPalettePinkAndPurple;
- 添加了 Option.graphics_customColorPaletteRustic;
- 添加了 Option.graphics_customColorPaletteShake;
- 添加了 Option.graphics_customColorPaletteSinShitty;
- 添加了 Option.control_stats

- 添加了 Tutorial.tutorial_audioCalibrationConfirm
- 添加了 LevelTips.levelTips_sandboxCheatCode

- 移除了 act1_limboFourth_newArm
- 添加了 act1_limboFourth_newArm1 and act1_limboFourth_newArm2

- 移除了 tutorial_introReminder;
- 添加了tutorial_introReminder1 and tutorial_introReminder2;

- 添加了 fish_book11 因为有新句子 I HAVE TO SEE I HAVE TO KNOW 占了 fish_book9 的位置


## 1.3.1?
- 修复了忘记给assetbundle加载字体硬编码的问题（迁移与兼容是个大问题所以先改回硬编码）

## 1.3.0?
- 中文字体从纯dynamic atlas population变成大部分static+小部分dynamic补缺，性能应该会比之前好很多

- 加入了纹理替换，支持静态批处理后处理（我说带一堆原游戏资产拿OpenCV搞Sliding Window搞什么）

- 加入了音频替换缓存

- 添加了测试性的替换所有TMP的字体的方法（underlay不太对所以暂时不能用）

- 移除了2-S的配音支持 

## 1.2.0？
- 修复了电子血宫的音乐 The Cyber Grind 显示错位 issue by RewTwn

- 修复了钓上鱼后的文字没阴影 / outline

- 修复了钓上鱼后的文字大小不对

- 修复了钓上鱼后的文字没有打开动画

- 修改了(?)钓上鱼后的结算文字不会自动换行的问题


## 1.1.0?
- 将VCR OSD MONO 配套字体从凤凰点阵体修改为文泉驿点阵宋体 12px

- 修改了文泉驿点阵宋体 12px和16px/VCROSD fallback font和秘密终端 fallback font 的渲染模式为SDFAA_HINTED，牺牲了一点字体的美观/准确性换来了低分辨率下拥有更高的清晰度

- 将 缝合像素字体 10px 的baseline增加了5 `bassline drop(`

- 修复了关卡选择界面里关卡通关等级文字靠下的问题 `这雷埋得有点深过头了`

- 修复了3-2和6-2的过场动画结尾字幕没有阴影的问题

- LanguageManager Rework(?)，为了兼容其他语言，所以接下来就是大量的breaking change了（

`如果你在意为什么会牺牲美观可以看一下什么是Hinting: https://learn.microsoft.com/en-us/typography/truetype/hinting`

`当然这篇FreeType的更新文档在例子上我觉得更加直观一点：https://freetype.org/freetype2/docs/hinting/subpixel-hinting.html`

## 1.0.2？
- 修复了MirrorReaper和Providence少一行strategy的问题

- 修复了Power字幕没翻译的问题 `但这个1.0.1时是故意没加的所以不算修复`

- 修复了部分风格带颜色富文本但没翻译会被检测为有翻译导致StyleHUD出现神秘`+  x2`之类的问题

## 1.0.1?
- 修复了部分风格不会翻译的问题，为什么会有部分风格不走字典查询啊

