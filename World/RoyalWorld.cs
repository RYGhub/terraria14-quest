using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace RoyalTerraria14Quest.World
{
    public class RoyalWorld : ModWorld
    {
        public static bool natureJewelActivated;
        public static bool tideJewelActivated;
        public static bool forgeJewelActivated;

        public static int jewelsActivated
        {
            get
            {
                int count = 0;
                if (natureJewelActivated) count++;
                if (tideJewelActivated) count++;
                if (forgeJewelActivated) count++;
                return count;
            }
        }

        public static bool AllJewelsActivated
        {
            get
            {
                return natureJewelActivated && tideJewelActivated && forgeJewelActivated;
            }
        }

        public override void Initialize()
        {
            natureJewelActivated = false;
            tideJewelActivated = false;
            forgeJewelActivated = false;
        }

        public override TagCompound Save()
        {
            var gems = new List<string>();
            if (natureJewelActivated)
            {
                gems.Add("nature");
            }
            if (tideJewelActivated)
            {
                gems.Add("water");
            }
            if (forgeJewelActivated)
            {
                gems.Add("fiery");
            }

            return new TagCompound
            {
                ["gems"] = gems
            };
        }

        public override void Load(TagCompound tag)
        {
            var gems = tag.GetList<string>("gems");
            natureJewelActivated = gems.Contains("nature");
            tideJewelActivated = gems.Contains("water");
            forgeJewelActivated = gems.Contains("fiery");
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte gems = new BitsByte(natureJewelActivated, tideJewelActivated, forgeJewelActivated);
            writer.Write(gems);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte gems = reader.ReadByte();
            natureJewelActivated = gems[0];
            tideJewelActivated = gems[1];
            forgeJewelActivated = gems[2];
        }
    }
}
