using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace RoyalTerraria14Quest.NPCs
{
    public class RoyalQuestGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if(Main.rand.Next(100) == 0)
            {
                if (npc.lifeMax > 5 && npc.value > 0f)
                {
                    if (!World.RoyalWorld.forgeJewelActivated)
                    {
                        Item.NewItem(npc.getRect(), mod.ItemType<Items.ForgeEssence>(), 1);
                    }
                    else
                    {
                        Item.NewItem(npc.getRect(), ItemID.SilverCoin, 20);
                    }
                }
            }
        }
    }
}