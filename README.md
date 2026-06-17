# qwqCounterStrikePlugin

一个 Counter-Strike 2 服务端插件，玩家在聊天框输入 `qwq`，服务端回复 `qwq!`。

基于 [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp) 框架，使用 C# (.NET 10) 编写。

## 快速开始

### 部署到服务器

1. **安装 Metamod:Source**  
   参考 https://cs2.poggu.me/metamod/installation/  
   下载对应的发行版，比如 Linux 版，解压到 `csgo/` 目录

2. **安装 CounterStrikeSharp**  
   下载 [with-runtime 版本](https://github.com/roflmuffin/CounterStrikeSharp/releases)  
   解压 `addons/` 合并到 `csgo/` 目录

   最终结构：
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
   从 [Releases](https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/latest) 下载 `.dll` 和 `.pdb` 文件：
   ```bash
   cp qwqCounterStrikePlugin-*.dll \
      csgo/addons/counterstrikesharp/plugins/
   ```

4. **启动服务器**
   ```bash
   ./cs2 -dedicated -game csgo +map de_dust2 +sv_lan 1
   ```

   控制台看到 `qwq CounterStrike Plugin loaded successfully!` 即加载成功。

5. **进游戏测试**  
   聊天框输入 `qwq` → 收到绿色回复 `qwq!`

### 实操记录

本机（Debian）完整部署命令：

```bash
# 1. 解压 Metamod 到 CS2 目录
tar -xzf /home/mac/SSoftwareFiles/mmsource/mmsource-2.0.0-git1402-linux.tar.gz \
  -C "/root/.local/share/Steam/steamapps/common/Counter-Strike Global Offensive/game/csgo/"

# 解压后检查
ls /root/.local/share/Steam/steamapps/common/Counter-Strike\ Global\ Offensive/game/csgo/addons/

# 2. 装 CounterStrikeSharp
cp -r /home/mac/SSoftwareFiles/css/ccs-with-runtime/addons/* \
  "/root/.local/share/Steam/steamapps/common/Counter-Strike Global Offensive/game/csgo/addons/"

# 3. 下载插件 Release
# 去 https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/latest
# 找到最新 tag（如 v0.0.1-5），替换下面的 TAG
TAG=v0.0.1-5
cd /tmp
wget "https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/download/$TAG/qwqCounterStrikePlugin-$TAG.dll"
wget "https://github.com/VincentZyu233/qwqCounterStrikePlugin/releases/download/$TAG/qwqCounterStrikePlugin-$TAG.pdb"

# 4. 放入插件目录
cp /tmp/qwqCounterStrikePlugin-$TAG.dll \
  "/root/.local/share/Steam/steamapps/common/Counter-Strike Global Offensive/game/csgo/addons/counterstrikesharp/plugins/"

# 5. 启动服务器
/root/.local/share/Steam/steamapps/common/Counter-Strike\ Global\ Offensive/game/bin/linuxsteamrt64/cs2 \
  -dedicated -game csgo +map de_dust2 +sv_lan 1
```

## GitHub Actions

推送到 GitHub 时，**commit 信息中的关键词控制流水线行为**。  
详细说明见 [`.github/workflows/build.md`](.github/workflows/build.md)。

| 关键词 | 构建 | 发布 Release |
|---|---|---|
| `build action` | ✅ | ❌ |
| `build release` | ✅ | ✅ |
