using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Common;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Items.Ammo;
using LargsMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;

namespace LargsMod.Content.Items.Weapons

{
    public class Bloodshot : LargsWeapon
    {
        public override LargsWeaponType WeaponType => LargsWeaponType.Static;

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, 0f);
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;
            Item.knockBack = 2.5f;

            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = ModContent.ItemType<PelletAmmo>();
            Item.shootSpeed = 9f;

            Item.value = Item.buyPrice(silver: 10);
            Item.rare = ItemRarityID.Orange;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // If firing a Vertepellet, increase its damage slightly when shot from Bloodshot.
            if (type == ModContent.ProjectileType<VertepelletProjectile>())
            {
                damage = Math.Max(1, (int)(damage * 1.25f));
            }

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 6)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
