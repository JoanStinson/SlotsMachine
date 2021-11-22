using JGM.Game.Patterns;

namespace JGM.Game.Rewards
{
    public class RewardsChecker
    {
        private readonly PayTable _payTable;
        private readonly int _minimumItemCountForReward;
        private readonly int _maximumItemCountForReward;

        public RewardsChecker(PayTable payTable, int minimumItemCountForReward, int maximumItemCountForReward)
        {
            _payTable = payTable;
            _minimumItemCountForReward = minimumItemCountForReward;
            _maximumItemCountForReward = maximumItemCountForReward;
        }

        public int GetRewardInCreditsFromResult(LineResult result)
        {
            int counter = result.itemCount;
            int itemType = result.firstItemTypeFoundInLine;
            int credits = 0;

            if (counter < _minimumItemCountForReward)
            {
                return credits;
            }

            if (counter > _maximumItemCountForReward)
            {
                counter = _maximumItemCountForReward;
            }

            for (int i = 0; i < _payTable.Prizes[itemType].rewards.Length; ++i)
            {
                if (_payTable.Prizes[itemType].rewards[i].itemsAmount == counter)
                {
                    credits = _payTable.Prizes[itemType].rewards[i].creditsAmount;
                    break;
                }
            }

            return credits;
        }
    }
}