using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LargsMod.Common
{
    public static class TargetingHelper
    {
        public static NPC FindTarget(Player player, float maxRange, bool requireLineOfSight = true)
        {
            NPC closestTarget = null;
            float closestDistance = maxRange;

            foreach (NPC npc in Main.npc)
            {
                if (!npc.active)
                    continue;

                if (!npc.CanBeChasedBy())
                    continue;

                float distance = Vector2.Distance(player.Center, npc.Center);

                if (distance > closestDistance)
                    continue;

                if (requireLineOfSight &&
                    !Collision.CanHit(player.Center, 1, 1, npc.Center, 1, 1))
                    continue;

                closestDistance = distance;
                closestTarget = npc;
            }

            return closestTarget;
        }
    }
}