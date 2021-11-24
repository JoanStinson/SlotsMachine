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
        [SerializeField] private GameEvent _showLineEvent;
        [SerializeField] private GameEvent _showCreditsEvent;
        [SerializeField] private GameEvent _canSpinAgainEvent;

        [Inject] private IAudioService _audioService;
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
                //Debug.Log($"LINE {i + 1} REWARDED CREDITS: {lineCredits}");
                if (lineCredits > 0)
                {
                    _showLineEvent.Trigger(new LinePopupData(i));
                    _showCreditsEvent.Trigger(new CreditsPopupData(lineCredits));
                    _audioService.Play("Win Credits");
                    yield return new WaitForSeconds(delayBetweenRewardsInSeconds);
                }
            }
            _canSpinAgainEvent.Trigger();
        }
    }
}