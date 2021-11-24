using System;
using UnityEngine.Events;

namespace JGM.Game.Events
{
    [Serializable]
    public class UnityCustomGameDataEvent : UnityEvent<IGameEventData> { }
}
