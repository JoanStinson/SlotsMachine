using JGM.Game.Patterns;

namespace JGM.Game.Rewards
{
    public interface IPayTableRewardsRetriever
    {
        int RetrieveReward(LineResult result);
    }
}