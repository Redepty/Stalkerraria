using Microsoft.Xna.Framework;
using Stalkerraria.Content.Buffs;
using Stalkerraria.Content.NPCs;
using Stalkerraria.Content.Tiles;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Stalkerraria.Content.Tiles
{
    public class BanditBossTent : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.addTile(Type);

            DustType = DustID.Stone;

            AddMapEntry(new Color(40, 40, 40));
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<BlackMark>(), 12);
            }
        }
        public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY) => offsetY = 2;


        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16, j * 16, ModContent.NPCType<BanditBoss>());

        }
    }
}