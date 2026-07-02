using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Common;

namespace LargsMod.Content.Items.Crafting
{
    public class Thermite : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;

            Item.value = Item.buyPrice(silver: 1);
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("LargsMod:AnyCopperBar")
                .AddRecipeGroup("LargsMod:AnyIronBar")
                .AddTile(TileID.AlchemyTable)
                .Register();
        }
    }
}