using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Projectiles;

namespace LargsMod.Content.Items.Ammo
{
    public class VileSpit : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;

            Item.damage = 6;
            Item.DamageType = ModContent.GetInstance<Largs>();
            Item.knockBack = 1.25f;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;

            Item.ammo = ModContent.ItemType<PelletAmmo>();

            Item.shoot = ModContent.ProjectileType<VileSpitProjectile>();
            Item.shootSpeed = 9f;

            Item.value = Item.buyPrice(copper: 2);
            Item.rare = ItemRarityID.White;
        }

        public override void SetStaticDefaults()
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe(30)
                .AddIngredient(ItemID.RottenChunk, 3)
                .AddTile(TileID.DemonAltar)
                .Register();
        }
    }
}
