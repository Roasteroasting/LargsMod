using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Common;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Items.Ammo;
using LargsMod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace LargsMod.Content.Items.Weapons
{
    public class MoltenSlingshot : LargsWeapon
    {
        public override LargsWeaponType WeaponType => LargsWeaponType.Static;

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, 0f);
        }

        public override void SetDefaults()
        {
            Item.damage = 26;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;
            Item.knockBack = 2.5f;

            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = ModContent.ItemType<PelletAmmo>();
            Item.shootSpeed = 10f;

            Item.value = Item.buyPrice(gold: 2);
            Item.rare = ItemRarityID.Orange;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            // Convert black pellets into fire pellets
            if (type == ModContent.ProjectileType<BlackpelletProjectile>())
            {
                type = ModContent.ProjectileType<FirepelletProjectile>();
            }

            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HellstoneBar, 12)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
