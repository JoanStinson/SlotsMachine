using System;
using UnityEngine;
using UnityEngine.Events;

namespace JGM.Game.Events
{
    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    [Serializable]
    public class GameEventListenerWithStringData : MonoBehaviour
    {
        [SerializeField] private GameEventWithStringData _gameEvent;
        [SerializeField] private StringEvent _unityEvent;

        public GameEventListenerWithStringData(GameEventWithStringData gameEvent, StringEvent unityEvent)
        {
            _gameEvent = gameEvent;
            _unityEvent = unityEvent;
        }

        public void Awake() => _gameEvent?.Register(this);

        public void OnDestroy() => _gameEvent?.Deregister(this);

        public virtual void TriggerEvent(string gameEventData) => _unityEvent?.Invoke(gameEventData);

        public void AddDelegateToUnityEvent(Action<string> newCallback)
        {
            _unityEvent.AddListener((stringnew) => newCallback(stringnew));
        }
    }
}