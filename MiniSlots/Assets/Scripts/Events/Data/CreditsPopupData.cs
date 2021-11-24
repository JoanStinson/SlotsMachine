namespace JGM.Game.Events
{
    public interface ICreditsPopupData : IGameEventData
    {
        int CreditsAmount { get; }
    }

    public class CreditsPopupData : ICreditsPopupData
    {
        public int CreditsAmount { get; private set; }

        public CreditsPopupData(int creditsAmount)
        {
            CreditsAmount = creditsAmount;
        }
    }
}