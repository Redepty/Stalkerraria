using Stalkerraria.Content.Projectiles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Weapons
{
    public class Knife : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.CopperShortsword);
            Item.damage = 20;
            Item.width = 42;
            Item.height = 42;
            Item.shoot = ModContent.ProjectileType<KnifeProjectile>();
        }
    }
}
