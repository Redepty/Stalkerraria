using Microsoft.Xna.Framework;
using Stalkerraria.Content.Items;
using System.ComponentModel;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Weapons
{
    public class AKS47Y : ModItem
    {
        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 62; // Hitbox width of the item
            Item.height = 32; // Hitbox height of the item
            Item.scale = 0.75f;
            Item.rare = ItemRarityID.Green; // Item rarity

            // Use Properties
            Item.useTime = 8; // The item's use time is ticks
            Item.useAnimation = 8; // The lenght of the item's use animation lenght in ticks
            Item.useStyle = ItemUseStyleID.Shoot; // The item's use style
            Item.autoReuse = true; // Autoreuse is avaible for this weapon
            Item.UseSound = SoundID.Item11; // Sound that plays when you use item

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged; // Sets the damage type of ranged
            Item.damage = 3; // Sets the item's damage
            Item.knockBack = 0.8f; // Sets the item's knockback
            Item.noMelee = true; // So the item's animation doesn't do damage

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // Eto nado
            Item.shootSpeed = 16f; // The speed of projectile
            Item.useAmmo = AmmoID.Bullet; // The "ammo Id" of the ammo item that this weapon uses.
        }
        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }

        public override void AddRecipes()
        {
            Recipe recipe1 = CreateRecipe()
                .AddIngredient<Mildew>(8)
                .AddIngredient<SwampStone>(5)
                .AddIngredient(ItemID.SilverCoin, 50)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}

