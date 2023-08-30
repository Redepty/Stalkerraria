using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using System.Collections.Generic;
using Terraria.ModLoader.IO;
using Stalkerraria.Content.Buffs;
using Stalkerraria.Content.Items.Accessories;
using Stalkerraria.Common.ItemDropRules.DropConditions;
using Stalkerraria.Content.Biomes;

namespace Stalkerraria.Content.NPCs.Anomalies
{
    public class FunnelAnomaly : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 2;
        }

        public override void SetDefaults()
        {
            NPC.width = 80;
            NPC.height = 70;
            NPC.damage = 1;
            NPC.defense = 0;
            NPC.lifeMax = 1500;
            NPC.HitSound = SoundID.NPCHit6;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 0f;
            NPC.knockBackResist = 0f;
            NPC.aiStyle = -1;
            AIType = NPCID.TargetDummy;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(""),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.InModBiome<Wasteland>() ? 0.4f : 0 ;
        }

        // public override float SpawnChance(NPCSpawnInfo spawnInfo) => NPC.downedMechBossAny && Main.eclipse && spawnInfo.Player.ZoneOverworldHeight ? 0.07f : 0;

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.15f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;
        }

        public override void AI() => NPC.spriteDirection = NPC.direction;

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.rand.NextBool(2))
            {
                int bufftype = ModContent.BuffType<RadiationDebuff1>();
                target.AddBuff(bufftype, 3 * 60);
            }

            else if (Main.rand.NextBool(4))
            {
                int bufftype = ModContent.BuffType<RadiationDebuff2>();
                target.AddBuff(bufftype, 3 * 60);
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BloodStoneArt>(), 2));
            npcLoot.Add(ItemDropRule.ByCondition(new RareArtDropCondition(), ModContent.ItemType<BileStoneArt>(), 4));
            npcLoot.Add(ItemDropRule.ByCondition(new EpicArtDropCondition(), ModContent.ItemType<PacifierArt>(), 20));
        }
    }
}
