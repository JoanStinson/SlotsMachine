using JGM.Game.Audio;
using JGM.Game.Events;
using JGM.Game.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace JGM.Game.Rewards
{
    public class SpinResultRewardsRetriever : MonoBehaviour
    {
        [Inject] private IAudioService _audioService;
        [Inject] private IEventTriggerService _eventTriggerService;
        [Inject] private IGridToLineConverter _gridToLineConverter;
        [Inject] private ILinePatternChecker _linePatternChecker;
        [Inject] private IPayTableRewardsRetriever _payTableRewardsRetriever;

        private LineType[] _lineTypes;

        private void Awake()
        {
            _lineTypes = new LineType[(int)LineType.Size];
            for (int i = 0; i < (int)LineType.Size; ++i)
            {
                _lineTypes[i] = (LineType)i;
            }
        }

        public void CheckSpinResult(IGameEventData gameEventData)
        {
            var grid = (gameEventData as SpinResultData).SpinResultGrid;
            StartCoroutine(RetrieveRewards(grid));
        }

        private IEnumerator RetrieveRewards(IGrid grid, float delayBetweenRewardsInSeconds = 5f)
        {
            for (int i = 0; i < _lineTypes.Length; ++i)
            {
                _gridToLineConverter.GetLineValuesFromGrid(_lineTypes[i], grid, out List<int> valuesInLine);
                var lineResult = _linePatternChecker.GetResultFromLine(valuesInLine);
                int lineCredits = _payTableRewardsRetriever.RetrieveReward(lineResult as LineResult);
                if (lineCredits > 0)
                {
                    _eventTriggerService.Trigger("Show Line", new LinePopupData(i));
                    _eventTriggerService.Trigger("Show Credits", new CreditsPopupData(lineCredits));
                    _audioService.Play("Win Credits");
                    yield return new WaitForSeconds(delayBetweenRewardsInSeconds);
                }
            }
            _eventTriggerService.Trigger("Can Spin Again");
        }
    }
}