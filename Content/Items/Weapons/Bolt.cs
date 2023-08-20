using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Weapons
{
    public class Bolt : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = 0;
            Item.DefaultToThrownWeapon(ModContent.ProjectileType<Projectiles.BoltProjectile>(), 17, 25f, true);
            Item.damage = 1;
            Item.knockBack = 1f;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.width = 0;
            Item.height = 0;
            Item.buyPrice(copper: 1);
        }
    }
}
