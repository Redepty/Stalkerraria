using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace Stalkerraria.Common.ItemDropRules.DropConditions
{
    public class EpicArtDropCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.hardMode;
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
