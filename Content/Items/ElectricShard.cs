using Stalkerraria.Content.Items.Accessories;
using Stalkerraria.Content.Items.Weapons;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items
{
    public class ElectricShard : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42; // The item texture's width
            Item.height = 42; // The item texture's height

            Item.maxStack = Item.CommonMaxStack; // The item's max stack value
            Item.value = 10000; // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            CreateRecipe(3)
                .AddIngredient(ModContent.ItemType<FrequencyCrystalArt>())
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe(5)
                .AddIngredient(ModContent.ItemType<HeliumArt>())
                .AddTile(TileID.Anvils)
                .Register();

            CreateRecipe(7)
                .AddIngredient(ModContent.ItemType<BatteryArt>())
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
