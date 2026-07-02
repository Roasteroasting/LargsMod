using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace LargsMod.Configs
{
    public class ClientConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [DefaultValue(true)]
        public bool ShowMomentumBar;
    }
}