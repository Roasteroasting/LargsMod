using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Common;
using LargsMod.Content.DamageClasses;
using LargsMod.Content.Items.Ammo;
using Microsoft.Xna.Framework;

namespace LargsMod.Content.Items.Weapons
{
    public class TungstenSlingshot : LargsWeapon
    {
        public override LargsWeaponType WeaponType => LargsWeaponType.Static;

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-8f, 0f);
        }

        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = ModContent.GetInstance<Largs>();

            Item.width = 32;
            Item.height = 32;

            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Shoot;

            Item.noMelee = true;
            Item.knockBack = 2.3f;

            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;

            Item.shoot = ProjectileID.PurificationPowder;
            Item.useAmmo = ModContent.ItemType<PelletAmmo>();
            Item.shootSpeed = 8f;

            Item.value = Item.buyPrice(silver: 2);
            Item.rare = ItemRarityID.White;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.TungstenBar, 4)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
