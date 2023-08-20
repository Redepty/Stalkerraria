using Stalkerraria.Content.Armor.Melee;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Melee
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class Helmet : ModItem
    {
        public static int MaxHpIncrease = 20;
        public static float MeleeDamageBonus = 0.10f;

        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {

            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(MaxHpIncrease);
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Green; // The rarity of the item
            Item.buyPrice(0, 0, 30);
        }

        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += MeleeDamageBonus; // Increase how many mana points the player can have by 20
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<BodyArmor>() && legs.type == ModContent.ItemType<Jeans>();
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 20%"
            player.statLifeMax2 += MaxHpIncrease;
        }
    }
}
