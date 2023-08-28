using Stalkerraria.Content.Buffs;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
    public class PacifierArt : ModItem
    {
        public static readonly int extraRegen = 1;
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;
            Item.rare = ItemRarityID.LightPurple;
            Item.value = 70000;
            Item.defense = 30;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.buffImmune[ModContent.BuffType<RadiationDebuff1>()] = true;
            player.potionDelayTime -= 5 * 60;
            player.lifeRegen += extraRegen;
            player.respawnTimer -= 5 * 60;
        }
    }
}
