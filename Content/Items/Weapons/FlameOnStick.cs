using Microsoft.Xna.Framework;
using System.ComponentModel;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Stalkerraria.Content.Buffs;
using System.Configuration;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Stalkerraria.Content.Projectiles;

namespace Stalkerraria.Content.Items.Weapons
{
    public class FlameOnStick : ModItem
    {

        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.DamageType = DamageClass.Magic; // Makes the damage register as magic. If your item does not have any damage type, it becomes true damage (which means that damage scalars will not affect it). Be sure to have a damage type.
            Item.width = 42; // Hitbox width of the item
            Item.height = 42; // Hitbox height of the item
            Item.useTime = (int)(1 * 30);
            Item.useAnimation = (int)(1 * 30);
            Item.useStyle = ItemUseStyleID.Shoot; // Makes the player use a 'Shoot' use style for the Item.
            Item.noMelee = true; // Makes the item not do damage with it's melee hitbox.
            Item.knockBack = 13;
            Item.value = Item.buyPrice(0, 0, 20);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<FlameProjectile>();
            Item.shootSpeed = 10; // How fast the item shoots the projectile.
            Item.crit = 4; // The percent chance at hitting an enemy with a crit, plus the default amount of 4.
            Item.mana = 15; // This is how much mana the item uses.
        }
    }
}
