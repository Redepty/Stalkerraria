using Microsoft.Xna.Framework;
using Stalkerraria.Content.Buffs;
using Stalkerraria.Content.NPCs;
using Stalkerraria.Content.Tiles;
using System.Linq;
using System.Security.Policy;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Stalkerraria.Content.Tiles
{
    public class BanditTent : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.DrawYOffset = 2;
            TileObjectData.newTile.RandomStyleRange = 6;
            TileObjectData.addTile(Type);

            DustType = DustID.Ash;

            AddMapEntry(new Color(40, 40, 40));
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<BlackMark>(), 12);
            }
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int texture = Main.rand.Next(0, 3);

            switch (texture) 
            {
                case 0:
                    NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16, j * 16, ModContent.NPCType<Bandit0>());
                    break;
                case 1:
                    NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16, j * 16, ModContent.NPCType<Bandit1>());
                    break;
                case 2:
                    NPC.NewNPC(new EntitySource_TileBreak(i, j), i * 16, j * 16, ModContent.NPCType<Bandit2>());
                    break;
            }
        }
    }
}