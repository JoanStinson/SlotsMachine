namespace JGM.Game.Events
{
    public interface IEventTriggerService
    {
        void Trigger(in string eventName, IEventData eventData = null);
    }
}