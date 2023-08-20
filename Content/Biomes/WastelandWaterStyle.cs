//using Stalkerraria.Content.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Biomes
{
    public class WastelandWaterStyle : ModWaterStyle
    {
        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<WastelandWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return DustID.Water;
        }

        public override int GetDropletGore()
        {
            return 1;/*ModContent.Find<ModGore>("ExampleMod/MinionBossBody_Back").Type;*/
        }

        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }

        public override Color BiomeHairColor()
        {
            return Color.LightGreen;
        }

        public override byte GetRainVariant()
        {
            return (byte)Main.rand.Next(3);
        }
    }
}