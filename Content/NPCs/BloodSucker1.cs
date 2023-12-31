﻿using Terraria;
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
using Stalkerraria.Content.Items;
using Stalkerraria.Content.Biomes;
using Stalkerraria.Common.ItemDropRules.DropConditions;
using Stalkerraria.Content.Items.Accessories;
using Stalkerraria.Content.Items.Weapons;

namespace Stalkerraria.Content.NPCs
{
    public class BloodSucker1 : ModNPC
    {

        public int VersionsCount = 2;

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 3;
        }

        public override void SetDefaults()
        {
            NPC.width = 38;
            NPC.height = 48;
            NPC.damage = 30;
            NPC.defense = 10;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit6;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 100;
            NPC.knockBackResist = 0.25f;
            NPC.aiStyle = 3;
            AIType = NPCID.Mummy;
        }

        private ref float MoveSpeed => ref NPC.ai[1];
        private ref float MoveSpeedY => ref NPC.ai[2];
        private ref float Counter => ref NPC.ai[3];

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[]
            {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,
                new FlavorTextBestiaryInfoElement(""),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.InModBiome<Wasteland>() ? 0.5f / VersionsCount : 0;
        }

        /*public override void HitEffect(int hitDirection, double damage)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Alien1").Type, 1f);
                for (int i = 0; i < 4; ++i)
                    Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("Alien2").Type, 1f);
            }
        }*/

        public override void FindFrame(int frameHeight)
        {
            NPC.frameCounter += 0.2f;
            NPC.frameCounter %= Main.npcFrameCount[NPC.type];
            int frame = (int)NPC.frameCounter;
            NPC.frame.Y = frame * frameHeight;
        }

        public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
        {
            if (Main.rand.NextBool(2)) target.AddBuff(BuffID.Bleeding, 5 * 60);
        }

        public override void AI()
        {
            NPC.spriteDirection = NPC.direction;
            if (NPC.life <= NPC.lifeMax * 0.25f)
            {
                NPC.hide = true;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ScrapMetal>(), 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RustyTube>(), 4));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BigScrapMetal>(), 7));
        }
    }
}
