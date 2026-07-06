using Microsoft.Xna.Framework;
using Terraria;
using LargsMod.Content.Players;
using LargsMod.Content.Projectiles;

namespace LargsMod.Common
{
    public static class HomingHelper
    {
        public static void UpdateHoming(Projectile projectile, float range = 600f)
        {
            var homing = projectile.GetGlobalProjectile<LargsGlobalProjectile>();

            if (!homing.CanHome)
                return;

            Player player = Main.player[projectile.owner];

            if (!player.active)
                return;

            NPC target = TargetingHelper.FindTarget(player, homing.HomingRange);

            if (target == null || !target.active || target.friendly)
                return;

            float speed = projectile.velocity.Length();

            if (speed < 6f)
                speed = 6f;

            Vector2 direction = target.Center - projectile.Center;

            if (direction.LengthSquared() < 0.001f)
                return;

            direction.Normalize();

            projectile.velocity = direction * speed;
        }
    }
}