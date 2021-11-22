using JGM.Game.Rollers;
using UnityEngine;

namespace JGM.Game.Utils
{
    public class RollerItemSpritesContainer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Item sprites must be in the same order as enum and same size")]
        private Sprite[] _itemSprites;

        public Sprite GetSpriteForRollerItemType(RollerItemType rollerItemType)
        {
            return _itemSprites[(int)rollerItemType];
        }
    }
}