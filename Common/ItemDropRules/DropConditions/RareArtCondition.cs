using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace Stalkerraria.Common.ItemDropRules.DropConditions
{
    public class RareArtDropCondition : IItemDropRuleCondition
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
            return null;
        }
    }
}