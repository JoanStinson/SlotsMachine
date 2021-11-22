using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game.Rollers
{
    public class RollerItem : MonoBehaviour
    {
        public RollerItemType Type { get; private set; }

        [SerializeField]
        private Image _image;

        private Roller _roller;
        private float _moveSpeed;
        private float _bottomLimit;

        public void Initialize(Roller roller, RollerItemType type, Sprite sprite, float moveSpeed, float bottomLimit)
        {
            _roller = roller;
            Type = type;
            _image.sprite = sprite;
            _moveSpeed = moveSpeed;
            _bottomLimit = bottomLimit;
        }

        public void Spin()
        {
            transform.localPosition -= _moveSpeed * Time.deltaTime * Vector3.up;
            if (transform.localPosition.y < _bottomLimit)
            {
                transform.localPosition = _roller.GetLastItemLocalPosition() + _roller.GetSpacingBetweenItems();
                _roller.MoveFirstItemToTheBack();
            }
        }
    }
}