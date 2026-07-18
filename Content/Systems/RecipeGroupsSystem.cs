using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace LargsMod.Content.Systems
{
    public class RecipeGroupsSystem : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup ironGroup = new RecipeGroup(
                () => "Any Iron Bar",
                ItemID.IronBar,
                ItemID.LeadBar
            );

            RecipeGroup.RegisterGroup("LargsMod:AnyIronBar", ironGroup);

            RecipeGroup copperGroup = new RecipeGroup(
                () => "Any Copper Bar",
                ItemID.CopperBar,
                ItemID.TinBar
            );

            RecipeGroup.RegisterGroup("LargsMod:AnyCopperBar", copperGroup);

            RecipeGroup adamantiteGroup = new RecipeGroup(
                () => "Any Adamantite Bar",
                ItemID.AdamantiteBar,
                ItemID.TitaniumBar
            );

            RecipeGroup.RegisterGroup("LargsMod:AnyAdamantiteBar", adamantiteGroup);
        }
    }
}