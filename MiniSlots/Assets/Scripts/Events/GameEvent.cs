using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        private HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

        public void Register(GameEventListener listener) => _listeners.Add(listener);

        public void Deregister(GameEventListener listener) => _listeners.Remove(listener);

        public void Trigger(in IGameEventData eventData = null)
        {
            Debug.Log($"'<color=green>{name}</color>' game event was triggered!");
            foreach (var listener in _listeners)
            {
                listener?.TriggerEvent(eventData);
            }
        }
    }
}