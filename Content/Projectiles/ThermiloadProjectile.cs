using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LargsMod.Content.DamageClasses;

namespace LargsMod.Content.Projectiles
{
    public class ThermiloadProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.DamageType = ModContent.GetInstance<Largs>();

            Projectile.timeLeft = 2;
            Projectile.penetrate = -1;

            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Explode();
        }

        private void Explode()
        {
            Vector2 center = Projectile.Center;

            Projectile.width = 120;
            Projectile.height = 120;
            Projectile.Center = center;

            SpawnExplosionEffects(center);

            if (Projectile.owner == Main.myPlayer)
            {
                Projectile.Damage();
            }

            Projectile.Kill();
        }

        private void SpawnExplosionEffects(Vector2 center)
        {
            for (int i = 0; i < 25; i++)
            {
                Dust dust = Dust.NewDustDirect(
                    center,
                    120,
                    120,
                    DustID.Smoke,
                    Main.rand.NextFloat(-3f, 3f),
                    Main.rand.NextFloat(-3f, 3f),
                    150,
                    default,
                    1.5f
                );

                dust.noGravity = false;
            }

            for (int i = 0; i < 15; i++)
            {
                Dust dust = Dust.NewDustDirect(
                    center,
                    120,
                    120,
                    DustID.Torch,
                    Main.rand.NextFloat(-4f, 4f),
                    Main.rand.NextFloat(-4f, 4f),
                    100,
                    default,
                    2f
                );

                dust.noGravity = true;
            }

            for (int i = 0; i < 10; i++)
            {
                Dust dust = Dust.NewDustDirect(
                    center,
                    0,
                    0,
                    DustID.Firework_Red,
                    Main.rand.NextFloat(-5f, 5f),
                    Main.rand.NextFloat(-5f, 5f),
                    100,
                    default,
                    2f
                );

                dust.noGravity = true;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 600);
        }
    }
}