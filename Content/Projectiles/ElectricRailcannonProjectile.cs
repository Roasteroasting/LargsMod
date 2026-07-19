using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using LargsMod.Content.DamageClasses;

namespace LargsMod.Content.Projectiles
{
    public class ElectricRailcannonProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 4;
            Projectile.height = 4;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.DamageType = ModContent.GetInstance<Largs>();

            Projectile.timeLeft = 2;
            Projectile.penetrate = -1;

            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            // Perform an instant hitscan from the projectile center in its velocity direction
            Vector2 start = Projectile.Center;
            Vector2 dir = Projectile.velocity;
            if (dir == Vector2.Zero) dir = Vector2.UnitX;
            dir.Normalize();

            float maxDistance = 1200f;
            Vector2 end = start + dir * maxDistance;

            // Find first solid tile along the line and detect if the beam passes through water
            float step = 8f;
            Vector2 hitPoint = end;
            bool foundWater = false;
            for (float d = 0; d <= maxDistance; d += step)
            {
                Vector2 check = start + dir * d;
                int tx = (int)(check.X / 16f);
                int ty = (int)(check.Y / 16f);
                if (tx >= 0 && tx < Main.maxTilesX && ty >= 0 && ty < Main.maxTilesY)
                {
                    var tile = Main.tile[tx, ty];
                    if (tile != null)
                    {
                        // Liquid detection: LiquidAmount > 0 and LiquidType == 0 (water)
                        if (tile.LiquidAmount > 0 && tile.LiquidType == LiquidID.Water)
                        {
                            foundWater = true;
                        }

                        if (tile.HasTile && Main.tileSolid[tile.TileType])
                        {
                            hitPoint = check;
                            break;
                        }
                    }
                }
            }

            // Spawn electric dust along beam for visuals
            for (float d = 0; d <= Vector2.Distance(start, hitPoint); d += 16f)
            {
                Vector2 pos = start + dir * d;
                Dust.NewDust(pos - new Vector2(2f, 2f), 4, 4, DustID.Electric, 0f, 0f, 150, default, 1f);
            }

            // Damage NPCs along the beam
            List<int> hit = new List<int>();

            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC npc = Main.npc[i];
                if (!npc.active || npc.friendly || npc.dontTakeDamage)
                    continue;

                float collisionPoint = 0f;
                if (Collision.CheckAABBvLineCollision(npc.Hitbox.TopLeft(), npc.Hitbox.Size(), start, hitPoint, 6f, ref collisionPoint))
                {
                    hit.Add(i);
                }
            }

            if (Projectile.owner == Main.myPlayer)
            {
                foreach (int idx in hit)
                {
                    NPC npc = Main.npc[idx];
                    if (npc != null && npc.active)
                    {
                        npc.SimpleStrikeNPC(Projectile.damage, 0);
                    }
                }

                // If the beam passed through water, damage wet NPCs not already hit by the beam
                if (foundWater)
                {
                    for (int i = 0; i < Main.maxNPCs; i++)
                    {
                        if (hit.Contains(i))
                            continue;

                        NPC npc = Main.npc[i];
                        if (!npc.active || npc.friendly || npc.dontTakeDamage)
                            continue;

                        if (npc.wet)
                        {
                            int conductiveDamage = Math.Max(1, Projectile.damage / 4);
                            npc.SimpleStrikeNPC(conductiveDamage, 0);
                        }
                    }
                }
            }

            Projectile.Kill();
        }
    }
}
