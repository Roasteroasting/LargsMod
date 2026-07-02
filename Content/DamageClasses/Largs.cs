using Terraria;
using Terraria.ModLoader;

namespace LargsMod.Content.DamageClasses
{
	public class Largs : DamageClass
	{
		public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
		{
			if (damageClass == DamageClass.Generic)
				return StatInheritanceData.Full;

			return StatInheritanceData.None;
		}

		public override bool GetEffectInheritance(DamageClass damageClass)
		{
			return false;
		}

		public override void SetDefaultStats(Player player)
		{

		}

		public override bool UseStandardCritCalcs => true;

    }
}