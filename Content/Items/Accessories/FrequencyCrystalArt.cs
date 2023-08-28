using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
	public class FrequencyCrystalArt : ModItem
	{
		public static readonly int atackSpeedBoost = 10;
		public static readonly float speedBoost = 0.08f;

		public override void SetDefaults() 
		{
			Item.width = 42;
			Item.height = 42;
			Item.rare = ItemRarityID.Blue;
			Item.value = 30000;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += speedBoost;
			player.GetAttackSpeed(DamageClass.Generic) += atackSpeedBoost / 100f;
        }
	}
}
