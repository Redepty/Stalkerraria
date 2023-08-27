using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Stalkerraria.Content.Tiles;
using Stalkerraria.Content.Biomes;
using static Terraria.Main.CurrentFrameFlags;
using static tModPorter.ProgressUpdate;

namespace Stalkerraria
{
    public class WastelandGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            tasks.Insert(genIndex + 1, new PassLegacy("Adding zone", delegate
            {
                WorldGen.TileRunner(Main.spawnTileX, Main.spawnTileY, 42, 30, ModContent.TileType<WastelandGrass>(), true, 15, 0, true, true);
            }));
        }
    }
}