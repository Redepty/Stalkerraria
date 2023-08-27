using System;
using Stalkerraria.Content.Tiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Common.Systems
{
    public class WastelandTileCount : ModSystem
    {
        public int exampleBlockCount;

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            exampleBlockCount = tileCounts[ModContent.TileType<WastelandGrass>()];
        }
    }
}