using Stalkerraria.Content.Projectiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria;
using Terraria.Graphics.CameraModifiers;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Stalkerraria.Content.Items.Weapons
{
    public class ToxicSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.autoReuse = true;

            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.knockBack = 4;
            Item.crit = 4;


            Item.value = 2000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;

            Item.shoot = ModContent.ProjectileType<KisselProjectile>();
            Item.shootSpeed = 8f; // Speed of the projectiles the sword will shoot
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<RustySword>())
                .AddIngredient(ModContent.ItemType<KisselShard>(), 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
