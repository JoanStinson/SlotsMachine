namespace JGM.Game.Events
{
    public interface ICreditsPopupData : IGameEventData
    {
        int CreditsAmount { get; }
    }
}