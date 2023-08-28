using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
	public class BatteryArt : ModItem
	{
		public static readonly float speedBoost = 0.25f;
        public static readonly float jumpBoost = 0.25f;
        public static readonly int atackSpeedBoost = 10;


        public override void SetDefaults() 
		{
			Item.width = 42;
			Item.height = 42;
			Item.rare = ItemRarityID.LightPurple;
			Item.value = 70000;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += speedBoost;
			player.maxRunSpeed += speedBoost * 5f;
            player.runAcceleration += speedBoost * 2f;
            player.autoJump = true;
            player.jumpSpeedBoost += jumpBoost;
            player.GetAttackSpeed(DamageClass.Generic) += atackSpeedBoost / 100f;
        }
	}
}
