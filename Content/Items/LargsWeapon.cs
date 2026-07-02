using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using LargsMod.Common;

namespace LargsMod.Content.Items
{
    public abstract class LargsWeapon : ModItem
    {
        public virtual LargsWeaponType WeaponType => LargsWeaponType.Mobile;

        public override void ModifyTooltips(System.Collections.Generic.List<TooltipLine> tooltips)
        {
            string typeText = WeaponType == LargsWeaponType.Mobile
                ? "Mobile Weapon"
                : "Static Weapon";
            
            var line = new TooltipLine(Mod, "LargsWeaponType", typeText);
            line.OverrideColor = WeaponType == LargsWeaponType.Mobile ? Color.Orange : Color.Cyan;
            tooltips.Add(line);
        }
    }
}