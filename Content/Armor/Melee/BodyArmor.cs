﻿using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Melee
{

    [AutoloadEquip(EquipType.Body)]
    public class BodyArmor : ModItem
    {

        public static int MeleeDamageBonus = 5;

        public override void SetStaticDefaults()
        {
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false;
        }
        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 5; // The amount of defense the item will give when equipped
            Item.buyPrice(0, 0, 30, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee).Base += MeleeDamageBonus;
        }
    }
}
