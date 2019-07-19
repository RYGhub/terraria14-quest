using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RoyalTerraria14Quest.Items
{
    public class JewelSlots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jewel Slots");
            Tooltip.SetDefault("You should not have this");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 0;
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.createTile = mod.TileType<Tiles.JewelSlots>();
            item.placeStyle = 0;
        }
    }
}
