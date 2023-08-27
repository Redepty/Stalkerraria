using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Summoner
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class HunterHood : ModItem
    {
        public static int SummonerDamageIncrease = 5;
        public static int SetBonusManaIncrease = 20;
        public static int AddictiveSummonerDamageBonus = 20;
        public static int AddictiveDefenceBonus = 2;

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.buyPrice(0, 0, 30, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += SummonerDamageIncrease / 100f;
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<HunterCloak>() && legs.type == ModContent.ItemType<HunterLeggings>();
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Summon) += AddictiveSummonerDamageBonus / 100f; // Increase dealt damage for summoner weapon classes by 20%
            player.statDefense += AddictiveDefenceBonus;
            player.statManaMax2 += SetBonusManaIncrease;
        }
    }
}