using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RoyalTerraria14Quest.Items
{
    public class NatureEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Essence");
            Tooltip.SetDefault("A tiny fragment of the Nature Jewel");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.maxStack = 500;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 25);
            recipe.AddIngredient(ItemID.MudBlock, 20);
            recipe.AddIngredient(ItemID.Cactus, 2);
            recipe.AddIngredient(ItemID.GlowingMushroom, 2);
            recipe.AddIngredient(ItemID.PurificationPowder, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
