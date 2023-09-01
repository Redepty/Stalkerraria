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

namespace Stalkerraria.Content
{
    public class WastelandGen : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Living Trees"));
            tasks.Insert(genIndex - 1, new PassLegacy("Adding zone", delegate
            {
                int startX = (Main.maxTilesX / 2) + WorldGen.genRand.Next(150, 250);
                int endX = startX + WorldGen.genRand.Next(300, 350) + Main.maxTilesY / 200;
                int attempts = 0;
                bool validLocation = false;
                for (int i = startX; i < endX; i++)
                {
                    int y = (int)(Main.worldSurface * 0.5f);
                    while (y < Main.worldSurface)
                    {
                        if (WorldGen.SolidTile(i, y))
                        {
                            if (i == startX)
                            {
                                Dictionary<ushort, int> dictionary = new Dictionary<ushort, int>();
                                WorldUtils.Gen(new Point(startX, y + 15), new Shapes.Rectangle(endX - startX, 30), new Actions.TileScanner(TileID.Dirt, TileID.Cloud, TileID.LivingWood).Output(dictionary));
                                int dirtCount = dictionary[TileID.Dirt];
                                int cloudCount = dictionary[TileID.Cloud] + dictionary[TileID.LivingWood];
                                if (dirtCount > endX * 30 / 3 && cloudCount == 0)
                                {
                                    validLocation = true;
                                }
                                else if (cloudCount != 0)
                                {
                                    y++;
                                }
                            }
                            if (validLocation || attempts >= 40)
                            {
                                WorldGen.EmptyLiquid(i, y);
                                WorldGen.TileRunner(i, y, WorldGen.genRand.Next(35, 45), WorldGen.genRand.Next(10, 15), ModContent.TileType<WastelandGrass>());
                            }
                            else
                            {
                                attempts++;
                                endX--;
                                startX--;
                                i = startX;
                            }
                            break;
                        }
                        y++;
                    }
                }
            }));

        }
    }
}