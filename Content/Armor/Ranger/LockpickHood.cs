using Stalkerraria.Content.Armor.Mage;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Ranger
{

    [AutoloadEquip(EquipType.Head)]
    public class LockpickHood : ModItem
    {

        public static int RangerArmorPenetration = 5;
        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.defense = 1; // The amount of defense the item will give when equipped
            Item.buyPrice(0, 0, 30, 0);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetArmorPenetration(DamageClass.Ranged) += RangerArmorPenetration / 100f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<LockpickBreastplate>() && legs.type == ModContent.ItemType<LockpickLeggings>();
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.ammoCost80 = true;
        }
    }
}
