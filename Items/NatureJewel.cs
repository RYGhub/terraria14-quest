using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RoyalTerraria14Quest.Items
{
    public class NatureJewel : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature Jewel");
            Tooltip.SetDefault("One of the three Legendary Jewels");
        }

        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 32;
            item.maxStack = 1;
            item.rare = 4;
            item.useStyle = 4;
            item.consumable = true;
            item.useTime = 60;
            item.useAnimation = 60;
            item.value = Item.sellPrice(1, 0, 0, 0);
            item.UseSound = SoundID.Item25;
        }
        
        public override bool CanUseItem(Player player) {
            return !(World.RoyalWorld.natureJewelActivated);
        }

        public override bool UseItem(Player player)
        {
            World.RoyalWorld.natureJewelActivated = true;
            if (Main.netMode == NetmodeID.Server)
            {
                NetMessage.SendData(MessageID.WorldData);
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.GetItem<Items.NatureEssence>(), 500);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
