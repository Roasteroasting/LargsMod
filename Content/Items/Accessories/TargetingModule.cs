using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Content.Players;

namespace LargsMod.Content.Items.Accessories
{
    public class TargetingModule : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 16;

            Item.accessory = true;

            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<LargsPlayer>().TargetingModuleEquipped = true;
        }
    }
}