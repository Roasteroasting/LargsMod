using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using LargsMod.Content.DamageClasses;
using Terraria.Audio;

namespace LargsMod.Content.Projectiles
{
    public class FirepelletProjectile : ModProjectile
    {
        private bool extinguished;

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.DamageType = ModContent.GetInstance<Largs>();

            Projectile.penetrate = 1;

            Projectile.timeLeft = 600;

            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Projectile.wet)
            {
                SoundEngine.PlaySound(SoundID.LiquidsWaterLava, Projectile.Center);

                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.Smoke,
                        Projectile.velocity.X * 0.15f,
                        Projectile.velocity.Y * 0.15f
                    );
                }

                for (int i = 0; i < 5; i++)
                {
                    Dust.NewDust(
                        Projectile.position,
                        Projectile.width,
                        Projectile.height,
                        DustID.Ash,
                        Projectile.velocity.X * 0.15f,
                        Projectile.velocity.Y * 0.15f
                    );
                }

                extinguished = true;
                Projectile.Kill();
                return;
            }

            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.velocity.Y += 0.15f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 180);
        }

        public override void OnKill(int timeLeft)
        {
            if (extinguished)
                return;

            SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);

            for (int i = 0; i < 8; i++)
            {
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    DustID.WoodFurniture,
                    Projectile.velocity.X * 0.2f,
                    Projectile.velocity.Y * 0.2f
                );
            }
        }
    }
}