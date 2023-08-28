using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
    public class HeliumArt : ModItem
    {
        public static readonly float speedBoost = 0.15f;
        public static readonly float jumpBoost = 0.5f;

        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.value = 50000;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed += speedBoost;
            player.runAcceleration += speedBoost;
            player.autoJump = true;
            player.jumpSpeedBoost += jumpBoost;
        }
    }
}
