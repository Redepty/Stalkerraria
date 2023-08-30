using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.NPCs
{
    public class Bandit2 : ModNPC
    {
        private int bulletTimer;
        private int bulletCooldown = 2 * 60;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 20;
            NPC.defense = 7;
            NPC.lifeMax = 100;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AIType = NPCID.Mummy;
        }

        public override void AI()
        {
            NPC.TargetClosest();
            if (NPC.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient && bulletTimer >= bulletCooldown)
            {
                var source = NPC.GetSource_FromAI();
                Vector2 position = NPC.Center;
                Vector2 targetPosition = Main.player[NPC.target].Center;
                Vector2 direction = targetPosition - position;
                direction.Normalize();
                float speed = 10f;
                int type = ProjectileID.BulletDeadeye;
                int damage = 5; //If the projectile is hostile, the damage passed into NewProjectile will be applied doubled, and quadrupled if expert mode, so keep that in mind when balancing projectiles if you scale it off NPC.damage (which also increases for expert/master)
                for (int i = 0; i < 8; i++)
                {
                    Projectile.NewProjectile(source, position, (direction * speed).RotatedByRandom(MathHelper.ToRadians(20)), type, damage, 0f, Main.myPlayer);
                }
                bulletTimer = 0;
            }
            bulletTimer++;

            NPC.spriteDirection = NPC.direction;
        }
    }
}
