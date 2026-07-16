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
            var p = player.GetModPlayer<LargsPlayer>();
            p.TargetingModuleEquipped = true;
            // Reduce damage slightly when using the targeting module to balance built-in targeting.
            // This keeps the damage penalty tied to the accessory itself, not the targeting system.
            p.TargetingDamageMultiplier = 0.85f; // 15% damage reduction by default
        }
    }
}