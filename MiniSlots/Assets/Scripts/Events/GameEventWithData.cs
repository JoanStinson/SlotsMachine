using System;
using System.Collections.Generic;
using UnityEngine;

public interface IGameEventData
{

}

[Serializable]
public class CreditsRewardsEventData : IGameEventData
{
    public int creditsAmount = 0;

    public CreditsRewardsEventData(int creditsAmount)
    {
        this.creditsAmount = creditsAmount;
    }
}

//[System.Serializable]
//public class LevelChangeEvent : UnityEvent<int> { }

[CreateAssetMenu(menuName = "Game Event With Data", fileName = "New Game Event With Data")]
public class GameEventWithData : ScriptableObject
{
    public CreditsRewardsEventData gameEventData;

    private HashSet<GameEventListenerWithData> _listeners = new HashSet<GameEventListenerWithData>();

    public void Register(GameEventListenerWithData listener) => _listeners.Add(listener);

    public void Deregister(GameEventListenerWithData listener) => _listeners.Remove(listener);

    public void Trigger()
    {
        foreach (var listener in _listeners)
        {
            listener?.TriggerEvent(gameEventData);
        }
    }
}