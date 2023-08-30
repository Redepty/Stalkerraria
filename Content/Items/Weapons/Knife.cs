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
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.damage = 10;
            Item.width = 42;
            Item.height = 42;
            Item.UseSound = SoundID.Item1;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.shoot = ModContent.ProjectileType<KnifeProjectile>();
        }
    }
}
