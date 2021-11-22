using JGM.Game.Events;
using JGM.Game.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.Game.Rollers
{
    public class RollerManager : MonoBehaviour
    {
        public const int NumberOfRowsInGrid = 3;
        public const int NumberOfColumnsInGrid = 5;

        [SerializeField] private GameObject _rollerPrefab;
        [SerializeField] private GameObject _rollerItemPrefab;
        [SerializeField] private RollerItemSpritesContainer _spriteLoader;
        [SerializeField] private RollerItemSequence[] _rollerItemSequences;
        [SerializeField] private GameEvent _checkSpinResultEvent;

        private Roller[] _rollers;
        private Grid _gridOfStoppedRollerItemsOnScreen;

        private const float _startingRollerXPosition = -477f;
        private const float _spacingBetweenRollers = 238.5f;
        private const float _delayBetweenRollersInSeconds = 0.25f;

        private void Awake()
        {
            _rollers = new Roller[NumberOfColumnsInGrid];
            _gridOfStoppedRollerItemsOnScreen = new Grid(NumberOfRowsInGrid, NumberOfColumnsInGrid);
            InstantiateAndAddRollersToList();
        }

        public void StartSpin()
        {
            StartCoroutine(SpinRollers());
        }

        public void ResetGrid()
        {
            _gridOfStoppedRollerItemsOnScreen.ResetGridValues();
        }

        private void InstantiateAndAddRollersToList()
        {
            for (int i = 0; i < _rollers.Length; ++i)
            {
                var rollerGO = Instantiate(_rollerPrefab, transform);
                var rollerLocalPosition = Vector3.right * (_startingRollerXPosition + (i * _spacingBetweenRollers));
                rollerGO.transform.localPosition = rollerLocalPosition;
                var roller = rollerGO.GetComponent<Roller>();
                roller.Initialize(_rollerItemSequences[i], _spriteLoader, _rollerItemPrefab);
                _rollers[i] = roller;
            }
        }

        private IEnumerator SpinRollers()
        {
            for (int i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].StartSpin();
                yield return new WaitForSeconds(_delayBetweenRollersInSeconds);
            }
            for (int i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].StartSpinCountdown();
                yield return new WaitWhile(() => _rollers[i].IsSpinning);
                yield return new WaitForSeconds(_delayBetweenRollersInSeconds);
                _rollers[i].GetRollerItemsOnScreen(out List<int> itemsOnScreen);
                _gridOfStoppedRollerItemsOnScreen.SetColumnValues(i, itemsOnScreen);
            }
            _checkSpinResultEvent.Trigger(new SpinResultData(_gridOfStoppedRollerItemsOnScreen));
        }
    }
}