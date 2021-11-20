using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private UnityEvent _unityEvent;

    public GameEventListener(GameEvent gameEvent, UnityEvent unityEvent)
    {
        _gameEvent = gameEvent;
        _unityEvent = unityEvent;
    }

    private void Awake() => _gameEvent?.Register(this);

    private void OnDestroy() => _gameEvent?.Deregister(this);

    public virtual void TriggerEvent() => _unityEvent?.Invoke();
}