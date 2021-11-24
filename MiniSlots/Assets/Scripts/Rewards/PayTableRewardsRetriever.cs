using JGM.Game.Libraries;
using JGM.Game.Patterns;
using Zenject;

namespace JGM.Game.Rewards
{
    public class PayTableRewardsRetriever : IPayTableRewardsRetriever
    {
        [Inject]
        private PayTable _payTable;

        public int RetrieveReward(LineResult result)
        {
            int counter = result.ItemCount;
            int itemType = result.FirstItemTypeFoundInLine;
            int credits = 0;

            if (counter < _payTable.MinItemCountForReward)
            {
                return credits;
            }

            if (counter > _payTable.MaxItemCountForReward)
            {
                counter = _payTable.MaxItemCountForReward;
            }

            for (int i = 0; i < _payTable.Assets[itemType].Rewards.Length; ++i)
            {
                if (_payTable.Assets[itemType].Rewards[i].ItemsAmount == counter)
                {
                    credits = _payTable.Assets[itemType].Rewards[i].CreditsAmount;
                    break;
                }
            }

            return credits;
        }
    }
}