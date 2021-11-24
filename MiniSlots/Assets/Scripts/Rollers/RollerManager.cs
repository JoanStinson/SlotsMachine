using JGM.Game.Audio;
using JGM.Game.Events;
using JGM.Game.Libraries;
using JGM.Game.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.Game.Rollers
{
    public class RollerManager : MonoBehaviour
    {
        public const int NumberOfRowsInGrid = 0;
        public const int NumberOfColumnsInGrid = 5;

        [SerializeField] private GameEvent _checkSpinResultEvent;

        [Inject] private IAudioService _audioService;
        [Inject] private RollerFactory _rollerFactory;
        [Inject] private RollerSequencesLibrary _rollerSequencesLibrary;
        [Inject] private SpriteLibrary _spriteAssets;

        private Roller[] _rollers;
        private IGrid _gridOfStoppedRollerItemsOnScreen;

        private const float _startingRollerXPosition = -477f;
        private const float _spacingBetweenRollers = 238.5f;
        private const float _delayBetweenRollersInSeconds = 0.25f;

        private void Start()
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
                var roller = _rollerFactory.Create();
                roller.transform.SetParent(transform);
                var rollerLocalPosition = Vector3.right * (_startingRollerXPosition + (i * _spacingBetweenRollers));
                roller.transform.localPosition = rollerLocalPosition;
                roller.transform.localScale = Vector3.one;
                roller.Initialize(_rollerSequencesLibrary.Assets[i], _spriteAssets);
                _rollers[i] = roller;
            }
        }

        private IEnumerator SpinRollers()
        {
            _audioService.Play("Spin Roller", true);
            for (int i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].StartSpin();
                yield return new WaitForSeconds(_delayBetweenRollersInSeconds);
            }
            for (uint i = 0; i < _rollers.Length; ++i)
            {
                _rollers[i].StartSpinCountdown();
                yield return new WaitWhile(() => _rollers[i].IsSpinning);
                yield return new WaitForSeconds(_delayBetweenRollersInSeconds);
                _rollers[i].GetRollerItemsOnScreen(out List<int> itemsOnScreen);
                _gridOfStoppedRollerItemsOnScreen.SetColumnValues(i, itemsOnScreen);
            }
            _audioService.Stop("Spin Roller");
            _checkSpinResultEvent.Trigger(new SpinResultData(_gridOfStoppedRollerItemsOnScreen));
        }
    }
}