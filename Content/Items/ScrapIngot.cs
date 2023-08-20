using Stalkerraria.Content.Items.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items
{
    public class ScrapIngot : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42; // The item texture's width
            Item.height = 42; // The item texture's height

            Item.maxStack = Item.CommonMaxStack; // The item's max stack value
            Item.value = 0; // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ScrapMetal>())
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe(2)
                .AddIngredient(ModContent.ItemType<BigScrapMetal>())
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RustyTube>())
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
