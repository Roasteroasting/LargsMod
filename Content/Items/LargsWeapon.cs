using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LargsMod.Common;
using Terraria.DataStructures;
using LargsMod.Content.Projectiles;
using LargsMod.Content.Players;

namespace LargsMod.Content.Items
{
    public abstract class LargsWeapon : ModItem
    {
        public virtual bool HasBuiltInTargeting => false;

        public virtual LargsWeaponType WeaponType => LargsWeaponType.Mobile;

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            string typeText = WeaponType == LargsWeaponType.Mobile
                ? "Mobile Weapon"
                : "Static Weapon";
            
            var line = new TooltipLine(Mod, "LargsWeaponType", typeText);
            line.OverrideColor = WeaponType == LargsWeaponType.Mobile ? Color.Orange : Color.Cyan;
            tooltips.Add(line);
        }

        public override bool Shoot(
    Player player,
    EntitySource_ItemUse_WithAmmo source,
    Vector2 position,
    Vector2 velocity,
    int type,
    int damage,
    float knockback)
        {
            int proj = Projectile.NewProjectile(
                source,
                position,
                velocity,
                type,
                damage,
                knockback,
                player.whoAmI);

            var homing = Main.projectile[proj]
                .GetGlobalProjectile<LargsGlobalProjectile>();

            homing.CanHome =
                HasBuiltInTargeting ||
                player.GetModPlayer<LargsPlayer>().TargetingModuleEquipped;

            // If the spawned projectile is a pellet (inherits BasePelletProjectile), apply the accessory's damage multiplier.
            var p = Main.projectile[proj];
            var playerData = player.GetModPlayer<LargsPlayer>();
            if (playerData.TargetingDamageMultiplier != 1f && p.ModProjectile is BasePelletProjectile)
            {
                p.damage = Math.Max(1, (int)(p.damage * playerData.TargetingDamageMultiplier));
            }

            return false;
        }
    }
}