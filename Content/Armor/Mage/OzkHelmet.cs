using Stalkerraria.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Mage
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Head value here will result in TML expecting a X_Head.png file to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Head)]
    public class OzkHelmet : ModItem
    {
        public static int MaxManaIncrease = 20;
        public static int SetBonusManaIncrease = 40;
        public static float MagicDamageBonus = 0.2f;

        public static LocalizedText SetBonusText { get; private set; }

        public override void SetStaticDefaults()
        {

            SetBonusText = this.GetLocalization("SetBonus").WithFormatArgs(MaxManaIncrease);
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Pink; // The rarity of the item
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += MaxManaIncrease; // Increase how many mana points the player can have by 20
        }

        // IsArmorSet determines what armor pieces are needed for the setbonus to take effect
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<OzkBreastplate>() && legs.type == ModContent.ItemType<OzkLeggings>();
        }

        // UpdateArmorSet allows you to give set bonuses to the armor.
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = SetBonusText.Value; // This is the setbonus tooltip: "Increases dealt damage by 20%"
            player.GetDamage(DamageClass.Magic) += MagicDamageBonus; // Increase dealt damage for magic weapon classes by 20%
            player.statManaMax2 += SetBonusManaIncrease;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RaincoatBreastplate>())
                .AddIngredient(ModContent.ItemType<SwampStone>(), 3)
                .AddIngredient(ModContent.ItemType<Mildew>(), 4)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}