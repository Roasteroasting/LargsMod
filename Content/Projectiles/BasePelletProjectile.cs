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

            HomingHelper.UpdateHoming(Projectile);
        }
    }
}