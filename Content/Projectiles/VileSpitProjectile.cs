using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using LargsMod.Content.DamageClasses;

namespace LargsMod.Content.Projectiles
{
    public class VileSpitProjectile : BasePelletProjectile
    {
        protected override float Gravity => 0.12f;

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.DamageType = ModContent.GetInstance<Largs>();

            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;

            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            base.AI();
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Apply Cursed Inferno for a short duration
            target.AddBuff(BuffID.CursedInferno, 300);

            // Spawn some vile-appropriate dust (no sound here; sound played by certain weapons)
            for (int i = 0; i < 8; i++)
            {
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    DustID.CursedTorch);
            }
        }

        public override void OnKill(int timeLeft)
        {
            // Play a digging impact sound and spawn dust when the projectile is destroyed (e.g., hits a tile)
            SoundEngine.PlaySound(SoundID.Dig, Projectile.Center);

            for (int i = 0; i < 8; i++)
            {
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    DustID.CursedTorch);
            }
        }
    }
}
