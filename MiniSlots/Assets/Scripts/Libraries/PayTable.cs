using JGM.Game.Rollers;
using System;
using UnityEngine;

namespace JGM.Game.Libraries
{
    [CreateAssetMenu(fileName = "New Pay Table", menuName = "Libraries/Pay Table")]
    public class PayTable : AssetLibrary<Prize>
    {
        public int MinItemCountForReward => _minItemCountForReward;
        public int MaxItemCountForReward => _maxItemCountForReward;

        [SerializeField] private int _minItemCountForReward;
        [SerializeField] private int _maxItemCountForReward;
    }

    [Serializable]
    public class Prize
    {
        public RollerItemType Type;
        public Reward[] Rewards;
    }

    [Serializable]
    public class Reward
    {
        public int ItemsAmount;
        public int CreditsAmount;
    }
}