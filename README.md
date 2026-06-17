# qwqCounterStrikePlugin

一个 Counter-Strike 2 服务端插件，玩家在聊天框输入 `qwq`，服务端回复 `qwq!`。

基于 [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp) 框架，使用 C# (.NET 10) 编写。

## 快速开始

### 部署到服务器

1. **安装 Metamod:Source**  
   参考 https://cs2.poggu.me/metamod/installation/  
   下载对应的发行版，比如 Linux 版，解压到 `csgo/` 目录

   解压后结构：
   ```
   csgo/addons/
   └── metamod/
   ```

2. **安装 CounterStrikeSharp**  
   下载 [with-runtime 版本](https://github.com/roflmuffin/CounterStrikeSharp/releases)  
   解压 `addons/` 合并到 `csgo/` 目录

   合并后结构：
   ```
   csgo/
   ├── addons/
   │   ├── metamod/
   │   └── counterstrikesharp/
   │       ├── api/
   │       ├── dotnet/
   │       └── plugins/
   ```

3. **放入插件**
   从 [Releases](https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/latest) 下载 `.dll` 和 `.pdb` 文件到插件目录：
   ```bash
   TAG=<最新版本号>
   cd csgo/addons/counterstrikesharp/plugins/
   wget "https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/download/$TAG/qwqCounterStrikePlugin-$TAG.dll"
   wget "https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/download/$TAG/qwqCounterStrikePlugin-$TAG.pdb"
   ```

4. **启动服务器**
   ```bash
   ./cs2 -dedicated -game csgo +map de_dust2 +sv_lan 1
   ```

   控制台看到 `qwq CounterStrike Plugin loaded successfully!` 即加载成功。

5. **进游戏测试**  
   聊天框输入 `qwq` → 收到绿色回复 `qwq!`

### 实操记录

Debian13机器 完整部署命令：

```bash
# 1. 解压 Metamod 到 CS2 目录
# 正确结构: csgo/addons/
#              ├── metamod/
#              ├── metamod.vdf
#              └── metamod_x64.vdf
tar -xzf /home/mac/SSoftwareFiles/mmsource/mmsource-2.0.0-git1402-linux.tar.gz \
  -C "/root/.local/share/Steam/steamapps/common/Counter-Strike Global Offensive/game/csgo/"

# 解压后检查
ls /root/.local/share/Steam/steamapps/common/Counter-Strike\ Global\ Offensive/game/csgo/addons/

# 2. 装 CounterStrikeSharp
# 正确结构: csgo/addons/{metamod/, counterstrikesharp/{api/, dotnet/, plugins/}}
cp -r /home/mac/SSoftwareFiles/css/ccs-with-runtime/addons/* \
  "/root/.local/share/Steam/steamapps/common/Counter-Strike Global Offensive/game/csgo/addons/"

# 检查结构
tree /root/.local/share/Steam/steamapps/common/Counter-Strike\ Global\ Offensive/game/csgo/addons/


# 3. 下载插件到插件目录（去 Releases 找最新 tag 替换）
TAG=v0.0.1-5
cd "/root/.local/share/Steam/steamapps/common/Counter-Strike Global Offensive/game/csgo/addons/counterstrikesharp/plugins/"
proxychains4 wget "https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/download/$TAG/qwqCounterStrikePlugin-$TAG.dll"
proxychains4 wget "https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/download/$TAG/qwqCounterStrikePlugin-$TAG.pdb"

# 5. 启动服务器
/root/.local/share/Steam/steamapps/common/Counter-Strike\ Global\ Offensive/game/bin/linuxsteamrt64/cs2 \
  -dedicated -game csgo +map de_dust2 +sv_lan 1

# 或者使用启动脚本
/home/mac/SSoftwareFiles/cs2ds/cs2ds.sh
```

## GitHub Actions

推送到 GitHub 时，**commit 信息中的关键词控制流水线行为**。  
详细说明见 [`.github/workflows/build.md`](.github/workflows/build.md)。

| 关键词 | 构建 | 发布 Release |
|---|---|---|
| `build action` | ✅ | ❌ |
| `build release` | ✅ | ✅ |
