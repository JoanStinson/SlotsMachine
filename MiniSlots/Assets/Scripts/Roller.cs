using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    private int _rollerItemCount;

    [SerializeField]
    private GameObject _itemPrefab;

    private Transform _lastItemTransform;

    private List<RollerItem> _items;
    public float _spacingBetweenItems = 212f;
    public float _moveSpeed = 100f;
    public float _bottomLimit = -355f;
    private bool _isSpinning = false;
    private Vector3 _firstItemDefaultLocalPosition;

    private const float _minSpinTimeSeconds = 2f;
    private const float _maxSpinTimeSeconds = 4f;
    private float _currentSpinTmeSeconds;
    private RollerItemSequence _rollerItemSequence;
    private SpriteLoader _spriteLoader;

    public bool IsSpinning
    {
        get { return _isSpinning; }
        private set { _isSpinning = value; }
    }

    public void Initialize(Vector3 firstItemLocalPosition, RollerItemSequence rollerItemSequence, SpriteLoader spriteLoader)
    {
        _firstItemDefaultLocalPosition = firstItemLocalPosition;
        _rollerItemSequence = rollerItemSequence;
        _spriteLoader = spriteLoader;
        _rollerItemCount = rollerItemSequence.RollerItemTypes.Length;
    }

    private void Start()
    {
        _items = new List<RollerItem>();
        _firstItemDefaultLocalPosition = new Vector3(0f, -143.31f, 0f);
        for (int i = 0; i < _rollerItemCount; ++i)
        {
            var itemGO = Instantiate(_itemPrefab, transform);
            var localPosition = _firstItemDefaultLocalPosition + (i * GetSpacingBetweenItemsVector());
            itemGO.transform.localPosition = localPosition;
            var item = itemGO.GetComponent<RollerItem>();
            item.Initialize(this, _spriteLoader.GetSpriteForRollerItemType(_rollerItemSequence.RollerItemTypes[i]), _moveSpeed, _bottomLimit);
            _items.Add(item);
        }
    }

    private void Update()
    {
        if (!_isSpinning)
        {
            return;
        }

        for (int i = 0; i < _items.Count; ++i)
        {
            _items[i].Spin();
        }
    }

    public void StartSpin()
    {
        _isSpinning = true;
    }

    public void StartStopSpinCountdown()
    {
        _currentSpinTmeSeconds = Random.Range(_minSpinTimeSeconds, _maxSpinTimeSeconds);
        StartCoroutine(StopSpinAfterDelay(_currentSpinTmeSeconds));
    }

    private IEnumerator StopSpinAfterDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        StopSpin();
    }

    public void StopSpin()
    {
        _isSpinning = false;
        for (int i = 0; i < _items.Count; ++i)
        {
            var localPosition = _firstItemDefaultLocalPosition + (i * GetSpacingBetweenItemsVector());
            _items[i].transform.localPosition = Vector3.Lerp(_items[i].transform.localPosition, localPosition, 2f);
        }
    }

    public void MoveFirstItemToTheBack()
    {
        const int firstIndex = 0;
        var firstItem = _items[firstIndex];
        _items.Add(firstItem);
        _items.RemoveAt(firstIndex);
    }

    public Vector3 GetSpacingBetweenItemsVector()
    {
        return Vector3.up * _spacingBetweenItems;
    }

    public Vector3 GetLastItemLocalPosition()
    {
        return _items[_items.Count - 1].transform.localPosition;
    }
}
