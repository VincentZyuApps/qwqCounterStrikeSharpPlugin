<div align=center>

[![Downloads](https://img.shields.io/github/downloads/__REPO__/__VERSION__/total?style=flat-square&logo=github)](https://github.com/__REPO__/releases/tag/__VERSION__)
[![CS2](https://img.shields.io/badge/for-CounterStrikeSharp-FCAC19?style=flat-square&logo=csharp&logoColor=white&labelColor=2B3980)](https://github.com/roflmuffin/CounterStrikeSharp)
[![NET](https://img.shields.io/badge/.NET-10-512BD4?style=flat-square&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)

</div>

---

### 🎯 提交记录

__COMMIT_LOG__

---

### ⬇️ 下载发布文件

| 文件 | 说明 |
|------|------------|
| [📦 `qwqCounterStrikeSharpPlugin-__VERSION__.dll`](__BASE_URL__/qwqCounterStrikeSharpPlugin-__VERSION__.dll) | 🔌 插件主程序 |
| [📦 `qwqCounterStrikeSharpPlugin-__VERSION__.pdb`](__BASE_URL__/qwqCounterStrikeSharpPlugin-__VERSION__.pdb) | 🐛 调试符号（可选，用于保留报错行号） |

### 📥 安装插件

```bash
# Steam 默认路径通常位于 ~/.local 下
cd "path/to/Steam/steamapps/common/Counter-Strike Global Offensive/game"
# 下载到插件子目录（目录名必须与 DLL 文件名一致）
cd ./csgo/addons/counterstrikesharp/plugins/
mkdir -p qwqCounterStrikeSharpPlugin
cd qwqCounterStrikeSharpPlugin
wget "__BASE_URL__/qwqCounterStrikeSharpPlugin-__VERSION__.dll"
wget "__BASE_URL__/qwqCounterStrikeSharpPlugin-__VERSION__.pdb"
mv qwqCounterStrikeSharpPlugin-__VERSION__.dll qwqCounterStrikeSharpPlugin.dll
mv qwqCounterStrikeSharpPlugin-__VERSION__.pdb qwqCounterStrikeSharpPlugin.pdb
```

### 📋 部署步骤
> 详细说明请参阅[简体中文 README](https://github.com/VincentZyuApps/qwqCounterStrikeSharpPlugin/blob/main/README.zh-cn.md)

1. ✅ 服务器已安装 Metamod:Source 与 CounterStrikeSharp
2. ✅ 将 DLL 下载到 `plugins/qwqCounterStrikeSharpPlugin/`
3. ✅ 重启服务器
4. 🎮 在聊天框输入 `qwq` → 收到绿色回复 `qwq!`
5. 👋 真人玩家进服时 → 所有人收到 `qwq！！！`；真人玩家离服时 → 所有人收到 `qwq.....`

---

### 📊 构建信息

- **构建时间**：__BUILD_DATE__
- **提交**：__COMMIT_HASH__
- **完整变更记录**：__CHANGELOG_URL__
