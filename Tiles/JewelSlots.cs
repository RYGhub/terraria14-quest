using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;

namespace RoyalTerraria14Quest.Tiles
{
    public class JewelSlots : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileNoAttach[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 9;
            TileObjectData.newTile.Origin = new Terraria.DataStructures.Point16(4, 1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.addTile(Type);

            dustType = DustID.Stone;
            minPick = 9999;
            soundStyle = SoundID.Tink;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Jewel Slots");
            AddMapEntry(new Color(1f, 1f, 1f), name);
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Tile tile = Main.tile[i, j];

            if (tile.frameX != 144) return;
            if (tile.frameY != 36) return;
           
            if(World.RoyalWorld.natureJewelActivated)
            {
                Texture2D texture = mod.GetTexture("Items/NatureJewel");

                Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
                if (Main.drawToScreen)
                {
                    zero = Vector2.Zero;
                }

                Vector2 position = new Vector2((i - 8) * 16 - (int)Main.screenPosition.X + 12, (j - 2) * 16 - (int)Main.screenPosition.Y + 8);
                position += zero;

                Main.spriteBatch.Draw(texture, position, Color.White);
            }

            if (World.RoyalWorld.forgeJewelActivated)
            {
                Texture2D texture = mod.GetTexture("Items/ForgeJewel");

                Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
                if (Main.drawToScreen)
                {
                    zero = Vector2.Zero;
                }

                Vector2 position = new Vector2((i - 5) * 16 - (int)Main.screenPosition.X + 12, (j - 2) * 16 - (int)Main.screenPosition.Y + 8);
                position += zero;

                Main.spriteBatch.Draw(texture, position, Color.White);
            }

            if (World.RoyalWorld.tideJewelActivated)
            {
                Texture2D texture = mod.GetTexture("Items/TideJewel");

                Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
                if (Main.drawToScreen)
                {
                    zero = Vector2.Zero;
                }

                Vector2 position = new Vector2((i - 2) * 16 - (int)Main.screenPosition.X + 12, (j - 2) * 16 - (int)Main.screenPosition.Y + 8);
                position += zero;

                Main.spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public override void RightClick(int i, int j)
        {
            if(World.RoyalWorld.AllJewelsActivated)
            {
                Main.NewText("The gate to the Journey's End is now open!", Color.Yellow);
                Main.PlaySound(SoundID.Pixie);
            }
            else
            {
                Main.NewText("Some jewels are missing.", Color.Yellow);
                Main.PlaySound(SoundLoader.customSoundType, -1, -1, mod.GetSoundSlot(SoundType.Custom, "Sounds/MeepMerp.ogg"));
            }
        }

        public override void MouseOverFar(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            if (World.RoyalWorld.AllJewelsActivated)
            {
                player.showItemIcon = true;
                player.showItemIcon2 = mod.ItemType<Items.JewelSlots>();
            }
            else
            {
                player.showItemIcon = false;
                player.showItemIconText = string.Format("{0} / 3", World.RoyalWorld.jewelsActivated);
            }
        }
    }
}