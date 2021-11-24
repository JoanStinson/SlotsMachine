using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Events
{
    public class GameEventsListener : MonoBehaviour
    {
        [SerializeField]
        private List<CustomGameEventGroup> _gameEvents = new List<CustomGameEventGroup>();
        private List<GameEventListener> _gameEventListeners = new List<GameEventListener>();

        private void Awake()
        {
            foreach (var gameEvent in _gameEvents)
            {
                var gameEventListener = new GameEventListener(gameEvent.gameEvent, gameEvent.onTriggerEvent);
                gameEventListener.Awake();
                _gameEventListeners.Add(gameEventListener);
            }
        }

        private void OnDestroy()
        {
            foreach (var gameEventListener in _gameEventListeners)
            {
                gameEventListener?.OnDestroy();
            }
        }
    }
}