using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Summoner
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class HunterCloak : ModItem
    {
        public static int MaxMinionsIncrease = 1;

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 3; // The amount of defense the item will give when equipped
            Item.buyPrice(0, 0, 30, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.maxMinions += MaxMinionsIncrease;
        }
    }
}
