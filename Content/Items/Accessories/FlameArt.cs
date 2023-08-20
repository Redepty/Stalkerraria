using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Stalkerraria.Content.Items.Accessories
{
	public class FlameArt : ModItem
	{
		public static readonly int regenBoost = 2;

		public override void SetDefaults()
		{
			Item.width = 42;
			Item.height = 42;
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += regenBoost;
			player.aggro -= 1;
		}
	}
}
