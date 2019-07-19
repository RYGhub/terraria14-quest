using Terraria;
using Terraria.ModLoader;

namespace RoyalTerraria14Quest.Players
{
    public class QuestPlayer : ModPlayer
    {
        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if(!World.RoyalWorld.tideJewelActivated)
            {
                if (Main.rand.Next(8) == 0)
                {
                    caughtType = mod.ItemType<Items.TideEssence>();
                }
            }
        }
    }
}
