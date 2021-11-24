namespace JGM.Game.Events
{
    public class CreditsPopupData : IGameEventData
    {
        public readonly int CreditsAmount;

        public CreditsPopupData(int creditsAmount)
        {
            CreditsAmount = creditsAmount;
        }
    }
}