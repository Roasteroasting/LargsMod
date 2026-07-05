using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using LargsMod.Common;
using LargsMod.Content.Players;

namespace LargsMod.Content.Projectiles
{
    public abstract class BasePelletProjectile : ModProjectile
    {
        protected virtual float Gravity => 0.15f;

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.DamageType = ModContent.GetInstance<Content.DamageClasses.Largs>();

            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.velocity.Y += Gravity;

            HandleTargeting();
        }

        protected virtual void HandleTargeting()
        {
            Player player = Main.player[Projectile.owner];

            if (!player.active)
                return;

            if (!player.GetModPlayer<LargsPlayer>().TargetingModuleEquipped)
                return;

            NPC target = TargetingHelper.FindTarget(player, 600f);

            if (target == null || !target.active || target.friendly)
                return;

            float speed = Projectile.velocity.Length();

            if (speed < 6f)
                speed = 6f;

            Vector2 direction = target.Center - Projectile.Center;

            if (direction.LengthSquared() < 0.001f)
                return;

            direction.Normalize();

            Projectile.velocity = direction * speed;
        }
    }
}