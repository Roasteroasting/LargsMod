using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Common;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Items.Ammo;
using Microsoft.Xna.Framework;

namespace LargsMod.Content.Items.Weapons
{
    public class RotInflictor : LargsWeapon
    {
        public override LargsWeaponType WeaponType => LargsWeaponType.Static;

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, 0f);
        }

        public override bool Shoot(Player player, Terraria.DataStructures.EntitySource_ItemUse_WithAmmo source, Microsoft.Xna.Framework.Vector2 position, Microsoft.Xna.Framework.Vector2 velocity, int type, int damage, float knockback)
        {
            // If firing a VileSpit projectile, increase its damage slightly when shot from RotInflictor.
            if (type == ModContent.ProjectileType<Content.Projectiles.VileSpitProjectile>())
            {
                damage = (int)(damage * 1.25f);
                if (damage < 1) damage = 1;
            }

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void SetDefaults()
        {
            Item.damage = 11;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;
            Item.knockBack = 2.5f;

            Item.UseSound = SoundID.Item20;
            Item.autoReuse = false;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = ModContent.ItemType<PelletAmmo>();
            Item.shootSpeed = 9f;

            Item.value = Item.buyPrice(silver: 12);
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.DemoniteBar, 6)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
