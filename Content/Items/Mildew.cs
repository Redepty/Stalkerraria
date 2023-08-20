using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items
{
    public class Mildew : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 42;

            Item.maxStack = Item.CommonMaxStack;
            Item.value = Item.buyPrice(silver: 7, copper: 50);
        }
    }
}