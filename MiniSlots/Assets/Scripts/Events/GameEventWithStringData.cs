using System;
using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Events
{
    [CreateAssetMenu(menuName = "Game Event With String Data", fileName = "New Game Event With String Data")]
    public class GameEventWithStringData : ScriptableObject
    {
        public string stringData;

        private HashSet<GameEventListenerWithStringData> _listeners = new HashSet<GameEventListenerWithStringData>();

        public void Register(GameEventListenerWithStringData listener) => _listeners.Add(listener);

        public void Deregister(GameEventListenerWithStringData listener) => _listeners.Remove(listener);

        public void Trigger()
        {
            foreach (var listener in _listeners)
            {
                listener?.TriggerEvent(stringData);
            }
        }
    }
}