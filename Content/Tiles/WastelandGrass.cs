using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Tiles
{
    public class WastelandGrass : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMerge[Type][Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileMerge[TileID.Dirt][Type] = true;

            TileID.Sets.Grass[Type] = true;
            TileID.Sets.Conversion.Grass[Type] = true;

            AddMapEntry(new Color(154, 206, 120));
        }

        public override void RandomUpdate(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Tile tileBelow = Framing.GetTileSafely(i, j + 1);
            Tile tileAbove = Framing.GetTileSafely(i, j - 1);

            //Try place vine
            if (WorldGen.genRand.NextBool(15) && !tileBelow.HasTile && !(tileBelow.LiquidType == LiquidID.Lava))
            {
                if (!tile.BottomSlope)
                {
                    tileBelow.TileType = (ushort)ModContent.TileType<WastelandVines>();
                    tileBelow.HasTile = true;
                    WorldGen.SquareTileFrame(i, j + 1, true);
                    if (Main.netMode == NetmodeID.Server)
                    {
                        NetMessage.SendTileSquare(-1, i, j + 1, 3, TileChangeType.None);
                    }
                }
            }

            //try place foliage
            if (WorldGen.genRand.NextBool(50) && !tileAbove.HasTile && !(tileBelow.LiquidType == LiquidID.Lava))
            {
                if (!tile.BottomSlope && !tile.TopSlope && !tile.IsHalfBlock && !tile.TopSlope)
                {
                    tileAbove.TileType = (ushort)ModContent.TileType<WastelandFoliage0>();
                    tileAbove.HasTile = true;
                    tileAbove.TileFrameY = 0;
                    tileAbove.TileFrameX = (short)(WorldGen.genRand.Next(8) * 18);
                    WorldGen.SquareTileFrame(i, j + 1, true);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, i, j - 1, 3, TileChangeType.None);
                }
            }

            // try place another foliage
            if (WorldGen.genRand.NextBool(50) && !tileAbove.HasTile && !(tileBelow.LiquidType == LiquidID.Lava))
            {
                if (!tile.BottomSlope && !tile.TopSlope && !tile.IsHalfBlock && !tile.TopSlope)
                {
                    tileAbove.TileType = (ushort)ModContent.TileType<WastelandFoliage1>();
                    tileAbove.HasTile = true;
                    tileAbove.TileFrameY = 0;
                    tileAbove.TileFrameX = (short)(WorldGen.genRand.Next(8) * 18);
                    WorldGen.SquareTileFrame(i, j + 1, true);
                    if (Main.netMode == NetmodeID.Server)
                        NetMessage.SendTileSquare(-1, i, j - 1, 3, TileChangeType.None);
                }
            }

            //Try spread dirt
            if (Main.rand.NextBool(Main.dayTime && j < Main.worldSurface ? 5 : 8))
            {
                List<Point> adjacents = OpenAdjacents(i, j, TileID.Dirt);
                if (adjacents.Count > 0)
                {
                    Point p = adjacents[Main.rand.Next(adjacents.Count)];
                    if (HasOpening(p.X, p.Y))
                    {
                        Framing.GetTileSafely(p.X, p.Y).TileType = (ushort)ModContent.TileType<WastelandGrass>();
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, p.X, p.Y, 1, TileChangeType.None);
                    }
                }
            }

            //Try spread grass
            if (Main.rand.NextBool(Main.dayTime && j < Main.worldSurface ? 5 : 8))
            {
                List<Point> adjacents = OpenAdjacents(i, j, TileID.Grass);
                if (adjacents.Count > 0)
                {
                    Point p = adjacents[Main.rand.Next(adjacents.Count)];
                    if (HasOpening(p.X, p.Y))
                    {
                        Framing.GetTileSafely(p.X, p.Y).TileType = (ushort)ModContent.TileType<WastelandGrass>();
                        if (Main.netMode == NetmodeID.Server)
                            NetMessage.SendTileSquare(-1, p.X, p.Y, 1, TileChangeType.None);
                    }
                }
            }
        }

        private List<Point> OpenAdjacents(int i, int j, int type)
        {
            var p = new List<Point>();
            for (int k = -1; k < 2; ++k)
                for (int l = -1; l < 2; ++l)
                    if (!(l == 0 && k == 0) && Framing.GetTileSafely(i + k, j + l).HasTile && Framing.GetTileSafely(i + k, j + l).TileType == type)
                        p.Add(new Point(i + k, j + l));
            return p;
        }

        private bool HasOpening(int i, int j)
        {
            for (int k = -1; k < 2; ++k)
                for (int l = -1; l < 2; ++l)
                    if (!Framing.GetTileSafely(i + k, j + l).HasTile)
                        return true;
            return false;
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (!fail) //Change self into dirt
            {
                fail = true;
                Framing.GetTileSafely(i, j).TileType = TileID.Dirt;
            }
        }
    }
}