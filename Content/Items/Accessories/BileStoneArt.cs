using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Stalkerraria.Content.Buffs;

namespace Stalkerraria.Content.Items.Accessories
{
    public class BileStoneArt : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<RadiationDebuff1>()] = true;
            player.potionDelayTime -= 5 * 60;
        }
    }
}
