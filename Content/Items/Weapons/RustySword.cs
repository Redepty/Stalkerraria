using Stalkerraria.Content.Items;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Weapons
{
    public class RustySword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.autoReuse = true;

            Item.damage = 15;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 6;
            Item.crit = 4;


            Item.value = 5000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ScrapIngot>(), 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
