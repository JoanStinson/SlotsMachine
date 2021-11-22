using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Events
{
    [CreateAssetMenu(menuName = "Event/Empty Game Event", fileName = "New Empty Game Event")]
    public class EmptyGameEvent : ScriptableObject
    {
        private HashSet<EmptyGameEventListener> _listeners = new HashSet<EmptyGameEventListener>();

        public void Register(EmptyGameEventListener listener) => _listeners.Add(listener);

        public void Deregister(EmptyGameEventListener listener) => _listeners.Remove(listener);

        public void Trigger()
        {
            Debug.Log($"'<color=green>{name}</color>' game event was triggered!");
            foreach (var listener in _listeners)
            {
                listener?.TriggerEvent();
            }
        }
    }
}