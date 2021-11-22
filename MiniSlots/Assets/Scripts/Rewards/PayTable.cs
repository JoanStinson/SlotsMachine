using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Pay Table", fileName = "New Pay Table")]
public class PayTable : ScriptableObject
{
    [SerializeField]
    private Prize[] _prizes;
    public Prize[] Prizes => _prizes;
}

[Serializable]
public class Prize
{
    public RollerItemType type;
    public Reward[] rewards;
}

[Serializable]
public class Reward
{
    public int itemsAmount;
    public int creditsAmount;
}