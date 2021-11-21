using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EventGroup
{
    public GameEvent gameEvent;
    public UnityEvent onTriggerEvent;
}

public class GameEventsListener : MonoBehaviour
{
    [SerializeField]
    private List<EventGroup> _gameEvents = new List<EventGroup>();
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
        foreach (var listener in _gameEventListeners)
        {
            listener?.OnDestroy();
        }
    }
}