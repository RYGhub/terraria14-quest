using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RoyalTerraria14Quest.Items
{
    public class ForgeEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Forge Essence");
            Tooltip.SetDefault("A tiny fragment of the Forge Jewel");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.maxStack = 500;
            item.rare = 1;
            item.value = Item.sellPrice(0, 0, 20, 0);
        }
    }
}
