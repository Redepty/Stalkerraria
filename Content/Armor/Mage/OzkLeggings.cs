using Stalkerraria.Content.Items;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Armor.Mage
{
    // The AutoloadEquip attribute automatically attaches an equip texture to this item.
    // Providing the EquipType.Body value here will result in TML expecting X_Arms.png, X_Body.png and X_FemaleBody.png sprite-sheet files to be placed next to the item's main texture.
    [AutoloadEquip(EquipType.Legs)]
    public class OzkLeggings : ModItem
    {
        public static int MeleeKnockbackBonus = 2;

        public override LocalizedText Tooltip => base.Tooltip.WithFormatArgs(MeleeKnockbackBonus);

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
            player.GetKnockback(DamageClass.Melee) += MeleeKnockbackBonus;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RaincoatBreastplate>())
                .AddIngredient(ModContent.ItemType<SwampStone>(), 6)
                .AddIngredient(ModContent.ItemType<Mildew>(), 6)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
