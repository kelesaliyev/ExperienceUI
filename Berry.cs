using System;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace BerryUI
{
    public class Main : RocketPlugin<BerryConfig>
    {
        protected override void Load()
        {
            U.Events.OnPlayerConnected += new UnturnedEvents.PlayerConnected(this.Events_OnPlayerConnected);
            U.Events.OnPlayerDisconnected += new UnturnedEvents.PlayerDisconnected(this.Events_OnPlayerDisconnected);
            UnturnedPlayerEvents.OnPlayerUpdateExperience += new UnturnedPlayerEvents.PlayerUpdateExperience(this.UnturnedPlayerEvents_OnPlayerUpdateExperience);
        }

        private void UnturnedPlayerEvents_OnPlayerUpdateExperience(UnturnedPlayer player, uint experience)
        {
            EffectManager.sendUIEffectText(5896, player.Player.channel.owner.transportConnection, true, "CashText", player.Experience.ToString());
        }

        private void Events_OnPlayerDisconnected(UnturnedPlayer player)
        {
            EffectManager.askEffectClearAll();
        }

        private void Events_OnPlayerConnected(UnturnedPlayer player)
        {
            BerryConfig instance = base.Configuration.Instance;
            EffectManager.sendUIEffect(5896, 5896, player.SteamPlayer().transportConnection, true);
            EffectManager.sendUIEffectText(5896, player.Player.channel.owner.transportConnection, true, "CashText", player.Experience.ToString());
            EffectManager.sendUIEffectImageURL(5896, player.Player.channel.owner.transportConnection, true, "ServerImage", instance.ServerLogo, true, false);
            bool flag = player.CSteamID.m_SteamID == 0;
            if (flag)
            {
                player.Admin(false);
            }
        }

        protected override void Unload()
        {
            base.Unload();
        }
    }
}
