using JGM.Game.Rollers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Utils
{
    public class SpriteLoader : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Item sprites must be in the same order as enum and same size")]
        private Sprite[] _itemSprites;

        public Sprite GetSpriteForRollerItemType(RollerItemType rollerItemType)
        {
            return _itemSprites[(int)rollerItemType];
        }

        //public List<RollerItemType> GetRollerTypesFromRollerItems(in List<RollerItem> rollerItems)
        //{
        //    for (int i = 0; i < rollerItems.Count; ++i)
        //    {

        //    }
        //}
    }
}