using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LargsMod.Content.DamageClasses;
using LargsMod.Common;
using LargsMod.Content.Items;

namespace LargsMod.Content.Players
{
    public class LargsPlayer : ModPlayer
    {
        public bool TargetingModuleEquipped;
        public float TargetingDamageMultiplier = 1f;

        public float momentum;
        private int decayTimer;
        public int thermiloadCooldown;

        private const float GainRate = 0.25f;
        private const float DecayRate = 0.5f;
        private const int DecayDelay = 30;

        public override void ResetEffects()
        {
            TargetingModuleEquipped = false;
            TargetingDamageMultiplier = 1f;
        }

        public override void PostUpdate()
        {
            bool hasInput =
                Player.controlLeft ||
                Player.controlRight ||
                Player.controlUp ||
                Player.controlDown ||
                Player.controlJump;

            bool isMoving = Player.velocity.LengthSquared() > 0.1f;

            bool isGrappling = Player.grapCount > 0;

            if (thermiloadCooldown > 0)
            {
                thermiloadCooldown--;
            }

            if (!isGrappling && hasInput && isMoving)
            {
                momentum += GainRate;
                decayTimer = 0;
            }
            else
            {
                decayTimer++;

                if (decayTimer >= DecayDelay)
                {
                    momentum -= DecayRate;
                }
            }

            momentum = MathHelper.Clamp(momentum, 0f, 100f);
        }

        public override void ModifyWeaponDamage(Item item, ref StatModifier damage)
        {
            if (item.DamageType == ModContent.GetInstance<Largs>() &&
                item.ModItem is LargsWeapon weapon)
            {
                float maxMultiplier = weapon.WeaponType == LargsWeaponType.Mobile
                    ? 2f
                    : 1.3f;

                float multiplier = 1f + (momentum / 100f) * (maxMultiplier - 1f);
                damage *= multiplier;
            }
        }
    }
}
