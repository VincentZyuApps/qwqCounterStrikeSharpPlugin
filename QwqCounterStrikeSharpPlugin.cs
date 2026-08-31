using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Modules.Events;
using CounterStrikeSharp.API.Modules.Utils;
using Microsoft.Extensions.Logging;

namespace qwqCounterStrikeSharpPlugin;

public class QwqCounterStrikeSharpPlugin : BasePlugin
{
    private const string PlayerJoinedMessage = "qwq！！！";
    private const string PlayerLeftMessage = "qwq.....";

    public override string ModuleName => "qwq CounterStrikeSharp Plugin";
    public override string ModuleVersion => "0.2.0";

    public override void Load(bool hotReload)
    {
        RegisterEventHandler<EventPlayerConnectFull>(OnPlayerConnectFull);
        RegisterEventHandler<EventPlayerDisconnect>(OnPlayerDisconnect);

        RegisterEventHandler<EventPlayerChat>((@event, _) =>
        {
            Logger.LogInformation($"EventPlayerChat fired: userid={@event.Userid}, text='{@event.Text}', teamonly={@event.Teamonly}");

            var player = Utilities.GetPlayerFromUserid(@event.Userid);
            if (player == null)
            {
                Logger.LogInformation("player is NULL");
                return HookResult.Continue;
            }
            if (!player.IsValid)
            {
                Logger.LogInformation("player is invalid");
                return HookResult.Continue;
            }

            Logger.LogInformation($"player={player.PlayerName}, steamid={player.SteamID}");

            if (@event.Text.Trim().ToLower() == "qwq")
                player.PrintToChat($" {ChatColors.Green}qwq!");

            return HookResult.Continue;
        });
    }

    private static HookResult OnPlayerConnectFull(EventPlayerConnectFull @event, GameEventInfo info)
    {
        var player = @event.Userid;
        if (player is null || !player.IsValid || player.IsBot || player.IsHLTV)
        {
            return HookResult.Continue;
        }

        Server.NextFrame(() => Server.PrintToChatAll($" {ChatColors.Green}{PlayerJoinedMessage}"));
        return HookResult.Continue;
    }

    private static HookResult OnPlayerDisconnect(EventPlayerDisconnect @event, GameEventInfo info)
    {
        if (!@event.EverFullyConnected)
        {
            return HookResult.Continue;
        }

        var player = @event.Userid;
        if (player is not null && (player.IsBot || player.IsHLTV))
        {
            return HookResult.Continue;
        }

        if (player is null && (string.IsNullOrWhiteSpace(@event.Networkid) ||
                               @event.Networkid.Equals("BOT", StringComparison.OrdinalIgnoreCase)))
        {
            return HookResult.Continue;
        }

        Server.PrintToChatAll($" {ChatColors.Green}{PlayerLeftMessage}");
        return HookResult.Continue;
    }
}
