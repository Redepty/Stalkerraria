using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Stalkerraria.Content.Buffs;
using System.Configuration;
using Terraria.DataStructures;
using Stalkerraria.Content.Projectiles;
using Stalkerraria.Content.Items.Accessories;

namespace Stalkerraria.Content.Items.Weapons
{
    public class CrystalOnStick : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 13;
            Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
            Item.width = 42; // Hitbox width of the item
            Item.height = 42; // Hitbox height of the item
            Item.useTime = (int) (0.3*30);
            Item.useAnimation = (int) (0.3*30);
            Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
            Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
            Item.knockBack = 5;
            Item.value = Item.buyPrice(0, 0, 20);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CrystalProjectile>();
            Item.shootSpeed = 10; // How fast the item shoots the projectile.
            Item.crit = 4; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
            Item.mana = 5; // This is how much mana the item uses.
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<FrequencyCrystalArt>())
                .AddIngredient(ItemID.Wood)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
