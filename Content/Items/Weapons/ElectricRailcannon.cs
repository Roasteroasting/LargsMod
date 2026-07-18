using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LargsMod.Common;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Projectiles;
using Terraria.DataStructures;
using LargsMod.Content.Players;

namespace LargsMod.Content.Items.Weapons
{
    public class ElectricRailcannon : LargsWeapon
    {
        public override LargsWeaponType WeaponType => LargsWeaponType.Mobile;

        public override void SetDefaults()
        {
            Item.damage = 425;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;
            Item.knockBack = 0f;

            Item.UseSound = SoundID.Item43;
            Item.autoReuse = false;

            Item.shoot = ModContent.ProjectileType<ElectricRailcannonProjectile>();
            Item.shootSpeed = 0f;

            Item.rare = ItemRarityID.Red;
            Item.value = Item.buyPrice(gold: 10);
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LargsPlayer>().electricRailcannonCooldown <= 0;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            var mp = player.GetModPlayer<LargsPlayer>();
            mp.electricRailcannonCooldown = 16 * 60; // 16 seconds

            Vector2 dir = Vector2.Normalize(Main.MouseWorld - player.Center);

            Projectile.NewProjectile(
                source,
                player.Center,
                dir,
                type,
                damage,
                0f,
                player.whoAmI
            );

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Nanites, 150)
                .AddRecipeGroup("LargsMod:AnyAdamantiteBar", 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
