## UltrakULL (Apodidae Remix)
A UltrakULL fork based on core part of 1.3.0 and GameObject Path and patch of 1.3.1

Currently it supports Simplfied Chinese only, WIP

一个核心部分基于1.3.0，补丁和 GameObject 路径基于1.3.1的fork

目前只支持简体中文，还在开发中（

## Project Status
The only issue left is the FontAsset's underlay.

## 如何安装
在安装之前请确保你已经安装过了 UltrakULL 或者说汉化，因为本项目不附带翻译文本文件

在 ULTRAKILL/BepInEx/plugins 里找到 UltrakULL 的插件位置，用这个压缩包里的 UltrakULL.dll 替换掉之前的插件并把压缩包里的字体包放到 UltrakULL.dll 的同一文件夹/路径下 

## 已知BUG
u1s1电子血宫那个显示当前播放音乐用的是unity的默认字体啊
结果自动转成了用VCROSD，但我这真没办法（

## Changelog
### 1.0.1?
- 修复了部分风格不会翻译的问题，为什么会有部分风格不走字典查询啊

### 1.0.2？
- 修复了MirrorReaper和Providence少一行strategy的问题

- 修复了Power字幕没翻译的问题 `但这个1.0.1时是故意没加的所以不算修复`

- 修复了部分风格带颜色富文本但没翻译会被检测为有翻译导致StyleHUD出现神秘`+  x2`之类的问题

### 1.1.0?
- 将VCR OSD MONO 配套字体从凤凰点阵体修改为文泉驿点阵宋体 12px

- 修改了文泉驿点阵宋体 12px和16px/VCROSD fallback font和秘密终端 fallback font 的渲染模式为SDFAA_HINTED，牺牲了一点字体的美观/准确性换来了低分辨率下拥有更高的清晰度

- 将 缝合像素字体 10px 的baseline增加了5 `bassline drop(`

- 修复了关卡选择界面里关卡通关等级文字靠下的问题 `这雷埋得有点深过头了`

- 修复了3-2和6-2的过场动画结尾字幕没有阴影的问题

- LanguageManager Rework(?)，为了兼容其他语言，所以接下来就是大量的breaking change了（

`如果你在意为什么会牺牲美观可以看一下什么是Hinting: https://learn.microsoft.com/en-us/typography/truetype/hinting`

`当然这篇FreeType的更新文档在例子上我觉得更加直观一点：https://freetype.org/freetype2/docs/hinting/subpixel-hinting.html`

### 1.2.0？
- 修复了电子血宫的音乐 The Cyber Grind 显示错位 issue by RewTwn

- 修复了钓上鱼后的文字没阴影 / outline

- 修复了钓上鱼后的文字大小不对

- 修复了钓上鱼后的文字没有打开动画

- 修改了(?)钓上鱼后的结算文字不会自动换行的问题

### 1.3.0?
- 中文字体从纯dynamic atlas population变成大部分static+小部分dynamic补缺，性能应该会比之前好很多

- 加入了纹理替换，支持静态批处理后处理（我说带一堆原游戏资产拿OpenCV搞Sliding Window搞什么）

- 加入了音频替换缓存

- 添加了测试性的替换所有TMP的字体的方法（underlay不太对所以暂时不能用）

- 移除了2-S的配音支持 

## 字体
VCROSD的后备字体: 文泉驿点阵宋体 12px

武器/电子血宫终端等: 缝合像素字体 10px

博物馆字体：文渊宋体

7-S这类终端字体：文泉驿点阵宋体 16px

## 鸣谢
6r3^2n: VCROSD字体方面的相关建议
RewTwn：bug

特别鸣谢 NeverminD71011, egg34, baiyu2413, sr1317以及参与ATC的大家（

## 关于字体包:
basegameasset.bundle: 附带了原游戏的GFSGaraldus字体生成的字体资产，博物馆要用，别替换就对了（

fontpack.bundle：这里面有4个字体资产：MainFont，MuseumFont， SecretFont 和 TerminalFont，目前mod是直接用对应的字符串加载这些字体资产的，所以如果你要修改的话记得把生成后的资产文件名修改为对应的字符串

如果你要获取游戏本体的资产，请使用 VanityReprise，这是一个专门用于 ULTRAKILL 的 AssetRipper fork。用他生成 Rude Project 后用 Unity 编辑器打开你就能看到所有资产

详情请看 [第一集 - 迈出第一步 [创作 ULTRAKILL 自定义关卡 (通过 Rude!)] | Small_____](https://www.bilibili.com/video/BV1uoJw6rE4e)

assetbundle打包方面... 这个一句两句确实难讲清所以如果有人现在就有需要直接联系我（ 虽然后续肯定会出视频的

## 彩蛋
本README写于2026/7/4

再不发没时间练图了rc3出分92w我都想一巴掌拍死我自己，虽然这改变不了我是个大漏勺的事实

本条消息写于2026/7/8
r1赢了

本条消息写于2026/7/17
图池怎么这么难我怎么一张图都出不了分

本条消息写于2026/7/30
感谢6r3^2n在决赛的支持，虽然那天状态拉完了拉了个大的（

## 结语
关注雨燕攻略组喵

## 为什么不给原作者提交 pr 而是自己单开一个 repo
你知道吗，vibe coding产出的项目是极其难以维护的

更别说完全不考虑当前代码结构的vibe coding

反正我不想继续在vibe后上的屎上雕花所以自己单开了