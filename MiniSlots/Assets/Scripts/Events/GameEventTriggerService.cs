using JGM.Game.Libraries;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace JGM.Game.Events
{
    public class GameEventTriggerService : MonoBehaviour, IEventTriggerService
    {
        [Inject]
        private GameEventLibrary _gameEventAssets;

        private Dictionary<string, GameEvent> _eventsLibrary;

        private void Awake()
        {
            _eventsLibrary = new Dictionary<string, GameEvent>();
            for (int i = 0; i < _gameEventAssets.Assets.Length; ++i)
            {
                _eventsLibrary.Add(_gameEventAssets.Assets[i].name, _gameEventAssets.Assets[i]);
            }
        }

        public void Trigger(in string eventName, IEventData eventData = null)
        {
            if (!_eventsLibrary.ContainsKey(eventName))
            {
                Debug.LogWarning("Trying to trigger an event that doesn't exist!");
                return;
            }
            var gameEvent = _eventsLibrary[eventName];
            gameEvent.Trigger(eventData as IGameEventData);
        }
    }
}