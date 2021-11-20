using UnityEngine;

public class RollerItem : MonoBehaviour
{
    private Roller _roller;
    private float _moveSpeed;
    private float _bottomLimit;

    public void Initialize(Roller roller, float moveSpeed, float bottomLimit)
    {
        _roller = roller;
        _moveSpeed = moveSpeed;
        _bottomLimit = bottomLimit;
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
