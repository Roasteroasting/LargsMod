using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using LargsMod.Content.DamageClasses;

namespace LargsMod.Content.Projectiles
{
    public class CrystalpelletProjectile : ModProjectile
    {
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
            Projectile.rotation = Projectile.velocity.ToRotation();
            Projectile.velocity.Y += 0.10f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            ExplodeShards();
        }

        public override void OnKill(int timeLeft)
        {
            ExplodeShards();
        }

        private void ExplodeShards()
        {
            SoundEngine.PlaySound(SoundID.Item27, Projectile.Center);

            Vector2 center = Projectile.Center;

            int radius = 80;

            int shardDamage = 8;

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];

                if (!npc.active || npc.friendly)
                    continue;

                float dist = Vector2.Distance(npc.Center, center);

                if (dist <= radius)
                {
                    npc.SimpleStrikeNPC(shardDamage, 0);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(
                    Projectile.position,
                    Projectile.width,
                    Projectile.height,
                    DustID.Glass
                );
            }
        }
    }
}