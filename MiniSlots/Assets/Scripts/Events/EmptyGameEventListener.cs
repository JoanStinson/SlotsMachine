using System;
using UnityEngine;
using UnityEngine.Events;

namespace JGM.Game.Events
{
    [Serializable]
    public class EmptyGameEventListener : MonoBehaviour
    {
        [SerializeField] private EmptyGameEvent _gameEvent;
        [SerializeField] private UnityEvent _onTriggerEvent;

        public void Awake() => _gameEvent?.Register(this);

        public void OnDestroy() => _gameEvent?.Deregister(this);

        public virtual void TriggerEvent() => _onTriggerEvent?.Invoke();
    }
}