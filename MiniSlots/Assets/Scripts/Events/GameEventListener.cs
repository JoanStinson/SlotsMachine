using System;
using UnityEngine;

namespace JGM.Game.Events
{
    [Serializable]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityCustomGameDataEvent _onTriggerEvent;

        public GameEventListener(GameEvent unityGameEvent, UnityCustomGameDataEvent unityCustomGameDataEvent)
        {
            _gameEvent = unityGameEvent;
            _onTriggerEvent = unityCustomGameDataEvent;
        }

        public void Awake() => _gameEvent?.Register(this);

        public void OnDestroy() => _gameEvent?.Deregister(this);

        public virtual void TriggerEvent(in IGameEventData eventData) => _onTriggerEvent?.Invoke(eventData);
    }
}