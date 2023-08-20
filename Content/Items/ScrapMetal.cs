using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items
{
    public class ScrapMetal : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42; // The item texture's width
            Item.height = 42; // The item texture's height

            Item.maxStack = Item.CommonMaxStack; // The item's max stack value
            Item.value = 0; // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
            Item.rare = ItemRarityID.Blue;
        }
    }
}
