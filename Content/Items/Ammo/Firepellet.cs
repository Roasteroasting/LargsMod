using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Projectiles;

namespace LargsMod.Content.Items.Ammo
{
    public class Firepellet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;

            Item.damage = 4;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.knockBack = 1f;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;

            Item.ammo = ModContent.ItemType<PelletAmmo>();
            Item.shoot = ModContent.ProjectileType<FirepelletProjectile>();
            Item.shootSpeed = 8f;

            Item.value = Item.buyPrice(copper: 1);
            Item.rare = ItemRarityID.White;
        }

        public override void SetStaticDefaults()
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe(15)
                .AddIngredient<Blackpellet>(15)
                .AddIngredient(ItemID.Torch)
                .Register();
        }
    }
}