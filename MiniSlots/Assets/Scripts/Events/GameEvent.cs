using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Event", fileName = "New Game Event")]
public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

    public void Register(GameEventListener listener) => _listeners.Add(listener);

    public void Deregister(GameEventListener listener) => _listeners.Remove(listener);

    public void Trigger()
    {
        foreach (var listener in _listeners)
        {
            listener?.TriggerEvent();
        }
    }
}