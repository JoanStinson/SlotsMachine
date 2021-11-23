using JGM.Game.Audio;
using JGM.Game.Events;
using JGM.Game.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grid = JGM.Game.Patterns.Grid;

namespace JGM.Game.Rewards
{
    public class SpinResultRewardsRetriever : MonoBehaviour
    {
        [SerializeField] private PayTable _payTable;
        [SerializeField] private GameEvent _showLineEvent;
        [SerializeField] private GameEvent _showCreditsEvent;
        [SerializeField] private EmptyGameEvent _canSpinAgainEvent;
        [SerializeField] private SfxAudioPlayer _sfxAudioPlayer;

        private LineType[] _lineTypes;
        private GridToLineConverter _gridToLineConverter;
        private LinePatternChecker _linePatternChecker;
        private PayTableRewardsRetriever _payTableRewardsRetriever;

        private void Awake()
        {
            _lineTypes = new LineType[(int)LineType.Size];
            for (int i = 0; i < (int)LineType.Size; ++i)
            {
                _lineTypes[i] = (LineType)i;
            }
            _gridToLineConverter = new GridToLineConverter();
            _linePatternChecker = new LinePatternChecker();
            _payTableRewardsRetriever = new PayTableRewardsRetriever(_payTable, 2, 4);
        }

        public void CheckSpinResult(IGameEventData gameEventData)
        {
            var grid = (gameEventData as SpinResultData).SpinResultGrid;
            StartCoroutine(RetrieveRewards(grid));
        }

        private IEnumerator RetrieveRewards(Grid grid, float delayBetweenRewardsInSeconds = 5f)
        {
            for (int i = 0; i < _lineTypes.Length; ++i)
            {
                _gridToLineConverter.GetValuesFromLine(_lineTypes[i], grid, out List<int> valuesInLine);
                var lineResult = _linePatternChecker.GetResultFromLine(valuesInLine);
                int lineCredits = _payTableRewardsRetriever.RetrieveReward(lineResult);
                //Debug.Log($"LINE {i + 1} REWARDED CREDITS: {lineCredits}");
                if (lineCredits > 0)
                {
                    _showLineEvent.Trigger(new LinePopupData(i));
                    _showCreditsEvent.Trigger(new CreditsPopupData(lineCredits));
                    _sfxAudioPlayer.PlayOneShot("Win Credits");
                    yield return new WaitForSeconds(delayBetweenRewardsInSeconds);
                }
            }
            _canSpinAgainEvent.Trigger();
        }
    }
}