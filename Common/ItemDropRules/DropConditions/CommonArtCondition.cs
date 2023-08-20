using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace Stalkerraria.Common.ItemDropRules.DropConditions
{
    // Very simple drop condition: drop during daytime
    public class CommonArtDropCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return NPC.downedBoss1;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Aboba";
        }
    }
}