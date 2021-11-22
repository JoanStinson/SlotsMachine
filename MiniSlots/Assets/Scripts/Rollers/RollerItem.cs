using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game.Rollers
{
    public class RollerItem : MonoBehaviour
    {
        [SerializeField] private Image _itemImage;

        private Roller _roller;
        private float _moveSpeed;
        private float _bottomLimit;
        private RollerItemType _rollerItemType;
        public RollerItemType ItemType => _rollerItemType;

        public void Initialize(Roller roller, RollerItemType rollerItemType, Sprite sprite, float moveSpeed, float bottomLimit)
        {
            _roller = roller;
            _rollerItemType = rollerItemType;
            _itemImage.sprite = sprite;
            _moveSpeed = moveSpeed;
            _bottomLimit = bottomLimit;
            _itemImage.gameObject.SetActive(true);
        }

        public void Spin()
        {
            transform.localPosition -= _moveSpeed * Time.deltaTime * Vector3.up;
            if (transform.localPosition.y < _bottomLimit)
            {
                transform.localPosition = _roller.GetLastItemLocalPosition() + _roller.GetSpacingBetweenItemsVector();
                _roller.MoveFirstItemToTheBack();
            }
        }
    }
}