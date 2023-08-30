using Microsoft.Xna.Framework;
using System;
using System.Linq;
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
using Stalkerraria.Content.Biomes;
using Stalkerraria.Content.Items.Accessories;
using Stalkerraria.Content.Armor.Mage;
using Stalkerraria.Content.Armor.Summoner;
using Stalkerraria.Content.Items.Weapons;
using Stalkerraria.Content.Armor.Melee;
using Stalkerraria.Content.Armor.Ranger;

namespace Stalkerraria.Content.NPCs.TownNPCs
{
    [AutoloadHead]
    public class Sidorovich : ModNPC
    {

        public const string ShopName = "Shop";
        private static Profiles.StackedNPCProfile NPCProfile;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25; // The total amount of frames the NPC has
             
            NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs. This is the remaining frames after the walking frames.
            NPCID.Sets.AttackFrameCount[Type] = 4; // The amount of frames in the attacking animation.
            NPCID.Sets.DangerDetectRange[Type] = 700; // The amount of pixels away from the center of the NPC that it tries to attack enemies.
            NPCID.Sets.AttackType[Type] = 1; // The type of attack the Town NPC performs. 0 = throwing, 1 = shooting, 2 = magic, 3 = melee
            NPCID.Sets.AttackTime[Type] = 90; // The amount of time it takes for the NPC's attack animation to be over once it starts.
            NPCID.Sets.AttackAverageChance[Type] = 30; // The denominator for the chance for a Town NPC to attack. Lower numbers make the Town NPC appear more aggressive.
            NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.
            NPCID.Sets.ShimmerTownTransform[NPC.type] = false; // This set says that the Town NPC has a Shimmered form. Otherwise, the Town NPC will become transparent when touching Shimmer like other enemies.

            NPCID.Sets.ShimmerTownTransform[Type] = false; // Allows for this NPC to have a different texture after touching the Shimmer liquid.

            // Influences how the NPC looks in the Bestiary
            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
                Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
                              // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
                              // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            // Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
            // NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
            NPC.Happiness
                .SetBiomeAffection<Wasteland>(AffectionLevel.Love) // Example Person prefers the forest..
            ; // < Mind the semicolon!
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true; // Sets NPC to be a Town NPC
            NPC.friendly = true; // NPC Will not attack player
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;

            AnimationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)
        { // Requirements for the town NPC to spawn.
            for (int k = 0; k < Main.maxPlayers; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                // Player has to have either an ExampleItem or an ExampleBlock in order for the NPC to spawn
                if (player.inventory.Any(item => item.type == ModContent.ItemType<FlameArt>() || item.type == ModContent.ItemType<FrequencyCrystalArt>() || item.type == ModContent.ItemType<KisselArt>() || item.type == ModContent.ItemType<BloodStoneArt>()))
                {
                    return true;
                }
            }
            return false;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = ShopName; // Name of the shop tab we want to open.
            }
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add("Проходи не задерживайся.");
            chat.Add("Как дела, сталкер?");
            chat.Add("Эй! Иди сюда, подкину тебе кое-чего!");
            chat.Add("Хабар принёс?");
            chat.Add("Ну удачной охоты, сталкер.", 0.8);
            chat.Add("Ну а консервных банок чё не насобирал?", 0.1);

            return chat; // chat is implicitly cast to a string.
        }

        public override void AddShops()
        {
            var npcShop = new NPCShop(Type, ShopName)
                .Add<RaincoatHelmet>()
                .Add<RaincoatBreastplate>()
                .Add<RaincoatLeggings>()
                .Add<HunterHood>()
                .Add<HunterCloak>()
                .Add<HunterLeggings>()
                .Add<Helmet>()
                .Add<BodyArmor>()
                .Add<Jeans>()
                .Add<LockpickHood>()
                .Add<LockpickBreastplate>()
                .Add<LockpickLeggings>()
                .Add<Bolt>();
    
            npcShop.Register(); // Name of this shop tab
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ProjectileID.Bullet;
            attackDelay = 1;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
        public override bool CanGoToStatue(bool toKingStatue) => true;

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("Stalkerraria/Content/NPCs/TownNPCs/Sidorovich_Head");
    }
}
