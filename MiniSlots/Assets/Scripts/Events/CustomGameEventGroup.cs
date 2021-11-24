using System;

namespace JGM.Game.Events
{
    [Serializable]
    public class CustomGameEventGroup
    {
        public GameEvent gameEvent;
        public UnityCustomGameDataEvent onTriggerEvent;
    }
}