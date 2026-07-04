using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Projectiles;

namespace LargsMod.Content.Items.Ammo
{
    public class Crystalpellet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;

            Item.damage = 12;
            Item.DamageType = ModContent.GetInstance<Largs>();
            Item.knockBack = 1.5f;

            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true;

            Item.ammo = ModContent.ItemType<PelletAmmo>();

            Item.shoot = ModContent.ProjectileType<CrystalpelletProjectile>();
            Item.shootSpeed = 10f;

            Item.value = Item.buyPrice(copper: 3);
            Item.rare = ItemRarityID.Blue;
        }

        public override void SetStaticDefaults()
        {
        }

        public override void AddRecipes()
        {
            CreateRecipe(20)
                .AddIngredient(ItemID.CrystalShard, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}