using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Stalkerraria.Content.Projectiles;

namespace Stalkerraria.Content.Items.Weapons
{
    public class RustyChain : ModItem
    {
        public override void SetDefaults()
        {
            Item.DefaultToWhip(ModContent.ProjectileType<RustyChainProjectile>(), 25, 2, 4);
            Item.rare = ItemRarityID.Green;
            Item.autoReuse = true;
            Item.channel = true;
        }

        public override bool MeleePrefix()
        {
            return true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<ScrapIngot>(), 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
