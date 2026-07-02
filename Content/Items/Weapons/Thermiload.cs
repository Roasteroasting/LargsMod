using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Projectiles;
using LargsMod.Content.Items.Crafting;
using LargsMod.Common;
using LargsMod.Content.Players;

namespace LargsMod.Content.Items.Weapons
{
    public class Thermiload : LargsWeapon
    {
        public override LargsWeaponType WeaponType => LargsWeaponType.Mobile;

        public override void SetDefaults()
        {
            Item.damage = 120;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.width = 40;
            Item.height = 40;

            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.noMelee = true;
            Item.autoReuse = false;

            Item.UseSound = SoundID.Item14;

            Item.shoot = ModContent.ProjectileType<ThermiloadProjectile>();
            Item.shootSpeed = 0f;

            Item.rare = ItemRarityID.LightRed;
            Item.value = Item.buyPrice(gold: 5);
        }

        public override bool CanUseItem(Player player)
        {
            return player.GetModPlayer<LargsPlayer>().thermiloadCooldown <= 0;
        }

        public override bool Shoot(Player player,
            Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source,
            Vector2 position,
            Vector2 velocity,
            int type,
            int damage,
            float knockback)
        {
            player.GetModPlayer<LargsPlayer>().thermiloadCooldown = 900;
            
            Vector2 target = Main.MouseWorld;

            Projectile.NewProjectile(
                source,
                target,
                Vector2.Zero,
                type,
                damage,
                knockback,
                player.whoAmI
            );

            return false;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Thermite>(), 10)
                .AddIngredient(ItemID.Bomb, 10)
                .AddTile(TileID.Anvils)
                .AddTile(TileID.Hellforge)
                .Register();
        }
    }
}