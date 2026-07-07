## UltrakULL (Apodidae Remix)
A UltrakULL fork based on core part of 1.3.0 and GameObject Path and patch of 1.3.1

Currently it supports Simplfied Chinese only, WIP

一个核心部分基于1.3.0，补丁和 GameObject 路径基于1.3.1的fork

目前只支持简体中文，还在开发中（

## 项目情况
目前只支持文本相关，配音相关还是1.3.0非异步的那套，纹理替换更是没开始搞（

## 如何安装
在安装之前请确保你已经安装过了 UltrakULL 或者说汉化，因为本项目不附带翻译文本文件

在 ULTRAKILL/BepInEx/plugins 里找到 UltrakULL 的插件位置，用这个压缩包里的 UltrakULL.dll 替换掉之前的插件并把压缩包里的字体包放到 UltrakULL.dll 的同一文件夹/路径下 

## 为什么不给原作者提交 pr 而是自己单开一个 repo
出了一大堆烦心事，反正我算是单飞了，整个项目乱的一塌糊涂有太多想改的地方了

如果你在意发生了什么，请去听一下 katagiri - silly-willy-nilly，大概就是这样

`说句不好听的如果我把 pr 提上去别人 AI 一审 token 直接耗完了，copliot都不是按次数算了，现在还有按次数算的 LLM 吗（`

哪怕是现在我也觉得自己的repo也是一团乱麻，但是和其他的对比我这个已经算是可以说是清爽的

如果你觉得可能没那么乱，请查阅本repo ./UltrakULL/Translations/Scenes/Act3.cs 拉到最底下，这个之后会清理的

如果有任何问题请先觉得我是vibecoder，至于为什么他都天天拿自己vibecoding给自己声称clearwater完全删除其他所有人的贡献这种事实上的错误把整个事件极端化找补我稍微拿这个当下挡箭牌怎么了

如果称自己vibecoding就能把自己的错误撇得干干净净，那当我用相同的理由时也没理由指责我
## 以知BUG
关卡选择界面里关卡的通关等级的P明显往下了好多

## 字体
VCROSD的后备字体: 破晓像素体 (我知道这个字体不是特别适配但我找不到更好的了，找到的最好的是方正的那些像素字体但他要花钱授权，而且搞不好如果只买了一部分的授权另一部分没搞定然后一不小心直接赔的倾家荡产。如果找到更好的字体可以联系我)

武器/电子血宫终端等: 缝合像素字体 10px

博物馆字体：文渊宋体

7-S这类终端字体：文泉驿点阵宋体 16px

## 鸣谢
6r3^2n: VCROSD字体方面的相关建议

## 关于字体包:
basegameasset.bundle: 附带了原游戏的GFSGaraldus字体生成的字体资产，博物馆要用，别替换就对了（

fontpack.bundle：这里面有4个字体资产：MainFont，MuseumFont， SecretFont 和 TerminalFont，目前mod是直接用对应的字符串加载这些字体资产的，所以如果你要修改的话记得把生成后的资产文件名修改为对应的字符串

如果你要获取游戏本体的资产，请使用 VanityReprise，这是一个专门用于 ULTRAKILL 的 AssetRipper fork。用他生成 Rude Project 后用 Unity 编辑器打开你就能看到所有资产

详情请看 [第一集 - 迈出第一步 [创作 ULTRAKILL 自定义关卡 (通过 Rude!)] | Small_____](https://www.bilibili.com/video/BV1uoJw6rE4e)

assetbundle打包方面... 这个一句两句确实难讲清所以如果有人现在就有需要直接联系我（ 虽然后续肯定会出视频的

## 为什么知道有BUG还发
本README写与2026/7/4

再不发没时间练图了rc3出分92w我都想一巴掌拍死我自己，虽然这改变不了我是个大漏勺的事实

## 结语
关注雨燕攻略组喵

这个图书馆怎么感觉是把人骗进来杀的啊，这是什么图书馆啊（

我知道这个mod名字有点弱智但我已经把更弱智的名字否决了，比如 `TV size` `DT Mode` `feat. xxxxxx` `Sped Up Ver.`以及

`"最強災厄魔神兇刃暴君暗雲狂鬼凶悪終焉襲撃爆砕莫大破滅殺戮崩壊暗黒妹・六六六" Remix` 这种东西

## 1.0.1?
修复了部分风格不会翻译的问题，为什么会有部分风格不走字典查询啊

## 1.0.2？
修复了MirrorReaper和Providence少一行strategy的问题
修复了Power字幕没翻译的问题（ 但这个1.0.1时是故意没加的所以不算修复，md这低能power补丁只想着启动时加载一种语言就行了吗

