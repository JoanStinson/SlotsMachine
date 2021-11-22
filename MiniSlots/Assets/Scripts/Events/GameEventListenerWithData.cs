using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class GameEventListenerWithData : MonoBehaviour
{
    [SerializeField] private GameEventWithData _gameEvent;
    [SerializeField] private UnityEvent<CreditsRewardsEventData> _unityEvent;

    public GameEventListenerWithData(GameEventWithData gameEvent, UnityEvent<CreditsRewardsEventData> unityEvent)
    {
        _gameEvent = gameEvent;
        _unityEvent = unityEvent;
    }

    public void Awake() => _gameEvent?.Register(this);

    public void OnDestroy() => _gameEvent?.Deregister(this);

    public virtual void TriggerEvent(CreditsRewardsEventData gameEventData) => _unityEvent?.Invoke(gameEventData);
}