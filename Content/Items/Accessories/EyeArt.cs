using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
    public class EyeArt : ModItem
    {
        public static readonly int extraHealth = 20;

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.rare = ItemRarityID.LightRed;
            Item.value = 50000;
            Item.defense = 5;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statLifeMax2 += extraHealth;
            player.nightVision = true;
        }
    }
}
