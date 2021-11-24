namespace JGM.Game.Events
{
    public class CreditsPopupData : ICreditsPopupData
    {
        public int CreditsAmount { get; private set; }

        public CreditsPopupData(int creditsAmount)
        {
            CreditsAmount = creditsAmount;
        }
    }
}