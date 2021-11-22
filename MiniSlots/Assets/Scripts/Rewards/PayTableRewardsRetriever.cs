using JGM.Game.Patterns;

namespace JGM.Game.Rewards
{
    public class PayTableRewardsRetriever
    {
        private readonly PayTable _payTable;
        private readonly int _minimumItemCountForReward;
        private readonly int _maximumItemCountForReward;

        public PayTableRewardsRetriever(PayTable payTable, int minItemCountForReward, int maxItemCountForReward)
        {
            _payTable = payTable;
            _minimumItemCountForReward = minItemCountForReward;
            _maximumItemCountForReward = maxItemCountForReward;
        }

        public int RetrieveReward(LineResult result)
        {
            int counter = result.ItemCount;
            int itemType = result.FirstItemTypeFoundInLine;
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