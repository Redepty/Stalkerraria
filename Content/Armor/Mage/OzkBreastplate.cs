using Stalkerraria.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Mage
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Body)]
    public class OzkBreastplate : ModItem
    {
        public static int MaxManaIncrease = 40;
        public static float MagicDamageBonus = 0.10f;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MaxManaIncrease);

        public override void SetStaticDefaults()
        {
            ArmorIDs.Body.Sets.HidesHands[Item.bodySlot] = false;
        }

        public override void SetDefaults()
        {
            Item.width = 18; // Width of the item
            Item.height = 18; // Height of the item
            Item.value = 2000; // How many coins the item is worth
            Item.rare = ItemRarityID.Pink; // The rarity of the item
            Item.defense = 2; // The amount of defense the item will give when equipped
        }

        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += MaxManaIncrease; // Increase how many mana points the player can have by 40
            player.GetDamage(DamageClass.Magic) += MagicDamageBonus;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RaincoatBreastplate>())
                .AddIngredient(ModContent.ItemType<SwampStone>(), 6)
                .AddIngredient(ModContent.ItemType<Mildew>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
