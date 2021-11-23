using JGM.Game.Audio;
using JGM.Game.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Rollers
{
    public class Roller : MonoBehaviour
    {
        public bool IsSpinning { get; private set; }

        private List<RollerItem> _items;

        [SerializeField]
        private SfxAudioPlayer _audioPlayer;

        private const float _minSpinTimeInSeconds = 2f;
        private const float _maxSpinTimeInSeconds = 4f;
        private const float _centerItemSpeed = 4f;

        private const float _itemSpinSpeed = 2000f;
        private const float _startingItemYPosition = -143.31f;
        private const float _spacingBetweenItems = 212f;
        private const float _itemBottomLimit = -355f;

        private bool _centerItemsOnScreen = false;

        public void Initialize(RollerItemSequence itemSequence, RollerItemSpritesContainer spriteLoader, GameObject itemPrefab)
        {
            _items = new List<RollerItem>();
            InstantiateAndAddRollerItemsToList(itemSequence, spriteLoader, itemPrefab);
        }

        private void Update()
        {
            if (!IsSpinning)
            {
                CenterItemsOnScreenIfNecessary();
                return;
            }

            SpinItems();
        }

        public void StartSpin()
        {
            IsSpinning = true;
        }

        public void StartSpinCountdown()
        {
            float currentSpinTmeInSeconds = Random.Range(_minSpinTimeInSeconds, _maxSpinTimeInSeconds);
            StartCoroutine(StopSpinAfterDelay(currentSpinTmeInSeconds));
        }

        public void MoveFirstItemToTheBack()
        {
            var firstItem = _items[0];
            _items.Add(firstItem);
            _items.RemoveAt(0);
        }

        public Vector3 GetSpacingBetweenItems()
        {
            return Vector3.up * _spacingBetweenItems;
        }

        public Vector3 GetLastItemLocalPosition()
        {
            return _items[_items.Count - 1].transform.localPosition;
        }

        public void GetRollerItemsOnScreen(out List<int> itemsOnScreen)
        {
            itemsOnScreen = new List<int>();
            for (int i = RollerManager.NumberOfRowsInGrid - 1; i >= 0; --i)
            {
                itemsOnScreen.Add((int)_items[i].Type);
            }
        }

        private void InstantiateAndAddRollerItemsToList(RollerItemSequence itemSequence, RollerItemSpritesContainer spriteLoader, GameObject itemPrefab)
        {
            for (int i = 0; i < itemSequence.RollerItemTypes.Length; ++i)
            {
                var itemGO = Instantiate(itemPrefab, transform);
                var itemLocalPosition = Vector3.up * _startingItemYPosition + (i * GetSpacingBetweenItems());
                itemGO.transform.localPosition = itemLocalPosition;
                var item = itemGO.GetComponent<RollerItem>();
                var itemType = itemSequence.RollerItemTypes[i];
                var itemSprite = spriteLoader.GetSpriteForRollerItemType(itemType);
                item.Initialize(this, itemType, itemSprite, _itemSpinSpeed, _itemBottomLimit);
                _items.Add(item);
            }
        }

        private void SpinItems()
        {
            for (int i = 0; i < _items.Count; ++i)
            {
                _items[i].Spin();
            }
        }

        private IEnumerator StopSpinAfterDelay(float delayInSeconds)
        {
            yield return new WaitForSeconds(delayInSeconds);
            IsSpinning = false;
            _centerItemsOnScreen = true;
            _audioPlayer.PlayOneShot("Stop Roller");
        }

        private void CenterItemsOnScreenIfNecessary()
        {
            if (_centerItemsOnScreen)
            {
                Vector3 localPosition = Vector3.zero;
                for (int i = 0; i < _items.Count; ++i)
                {
                    localPosition = Vector3.up * _startingItemYPosition + (i * GetSpacingBetweenItems());
                    _items[i].transform.localPosition = Vector3.Lerp(_items[i].transform.localPosition, localPosition, Time.deltaTime * _centerItemSpeed);
                }
                if (_items[_items.Count - 1] && Mathf.Abs(_items[_items.Count - 1].transform.localPosition.y - localPosition.y) < 0.01f)
                {
                    _centerItemsOnScreen = false;
                }
            }
        }
    }
}