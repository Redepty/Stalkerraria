using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Stalkerraria.Content.Projectiles;

namespace Stalkerraria.Content.Items.Weapons
{
    public class GaussGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 2000;
            Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
            Item.width = 80; // Hitbox width of the item
            Item.height = 50; // Hitbox height of the item
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
            Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
            Item.knockBack = 13;
            Item.value = 1000000;
            Item.rare = ItemRarityID.Purple;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<GaussGunLaser>();
            Item.shootSpeed = 60; // How fast the item shoots the projectile.
            Item.crit = 50; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
            Item.mana = 200; // This is how much mana the item uses.
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }
    }
}
