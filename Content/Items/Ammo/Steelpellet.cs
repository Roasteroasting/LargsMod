using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Projectiles;

namespace LargsMod.Content.Items.Ammo
{
    public class Steelpellet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;

            Item.damage = 8;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.knockBack = 1.5f;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;

            Item.ammo = ModContent.ItemType<PelletAmmo>();
            Item.shoot = ModContent.ProjectileType<SteelpelletProjectile>();
            Item.shootSpeed = 7.25f;

            Item.value = Item.buyPrice(copper: 1);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe(30)
                .AddRecipeGroup("LargsMod:AnyIronBar")
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}