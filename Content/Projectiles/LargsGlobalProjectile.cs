using Terraria;
using Terraria.ModLoader;

namespace LargsMod.Content.Projectiles
{
    public class LargsGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public bool CanHome = false;

        public float HomingRange = 600f;
        public float HomingStrength = 1f;
    }
}