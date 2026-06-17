using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Utils;
using CounterStrikeSharp.API.Modules.Commands;

namespace qwqCounterStrikePlugin;

public class QwqPlugin : BasePlugin
{
    public override string ModuleName => "qwq CounterStrike Plugin";
    public override string ModuleVersion => "0.1.0";

    public override void Load(bool hotReload)
    {
        AddCommandListener("say", (player, info) =>
        {
            if (player == null || !player.IsValid) return HookResult.Continue;

            if (info.ArgString?.Trim() == "qwq")
                player.PrintToChat($" {ChatColors.Green}qwq!");

            return HookResult.Continue;
        });
    }
}
