using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
    public class MomsBeadsArt : ModItem
    {
        public static readonly int regenBoost = 5;
        public static readonly int extraHealth = 50;

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = 70000;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += regenBoost;
            player.statLifeMax2 += extraHealth;
            player.nightVision = true;
        }
    }
}
