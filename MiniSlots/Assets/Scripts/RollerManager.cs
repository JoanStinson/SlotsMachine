using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerManager : MonoBehaviour
{
    [SerializeField] private GameObject _rollerPrefab;
    [SerializeField] private GameEvent _stoppedSpinEvent;
    [SerializeField] private SpriteLoader _spriteLoader;
    [SerializeField] private RollerItemSequence[] _rollerItemSequences;
    [SerializeField] private PayTable _payTable;

    private const int _numberOfRollers = 5;
    private Roller[] _rollers;
    private float _startingRollerXPosition = -477f;
    private float _spacingBetweenRollers = 238.5f;
    private float _delayInSecondsBetweenRollers = 0.25f;
    private Grid _grid;
    private GridToLineConverter _gridToLineTransformer;

    private void Start()
    {
        _rollers = new Roller[_numberOfRollers];
        _grid = new Grid(3, 5);
        for (int i = 0; i < _rollers.Length; ++i)
        {
            var rollerGO = Instantiate(_rollerPrefab, transform);
            var localPosition = Vector3.right * (_startingRollerXPosition + (i * _spacingBetweenRollers));
            rollerGO.transform.localPosition = localPosition;
            var roller = rollerGO.GetComponent<Roller>();
            roller.Initialize(Vector3.zero, _rollerItemSequences[i], _spriteLoader);
            _rollers[i] = roller;
        }
    }

    public void StartSpin()
    {
        StartCoroutine(SpinAllRollers());
    }

    private IEnumerator SpinAllRollers()
    {
        for (int i = 0; i < _rollers.Length; ++i)
        {
            _rollers[i].StartSpin();
            yield return new WaitForSeconds(_delayInSecondsBetweenRollers);
        }
        for (int i = 0; i < _rollers.Length; ++i)
        {
            _rollers[i].StartStopSpinCountdown();
            yield return new WaitWhile(() => _rollers[i].IsSpinning);
            yield return new WaitForSeconds(_delayInSecondsBetweenRollers);
            _grid.SetColumnValues(i, _rollers[i].GetRollerItemsOnScreen());
        }
        CheckSpinResult();
        _grid.ResetGrid();
        _stoppedSpinEvent.Trigger();
    }

    private void CheckSpinResult()
    {
        LinePatternChecker linePatternChecker = new LinePatternChecker();
        _gridToLineTransformer = new GridToLineConverter();
        RewardsChecker rewardsChecker = new RewardsChecker(_payTable, 2);

        List<int> firstLine = new List<int>();
        _gridToLineTransformer.GetValuesInHorizontalLine(_grid, out firstLine, 0);
        LineResult firstLineResult = linePatternChecker.GetResultFromLine(firstLine);
        int firstLineCredits = rewardsChecker.GetRewardInCreditsFromResult(firstLineResult);

        List<int> secondLine = new List<int>();
        _gridToLineTransformer.GetValuesInHorizontalLine(_grid, out secondLine, 1);
        LineResult secondLineResult = linePatternChecker.GetResultFromLine(secondLine);
        int secondLineCredits = rewardsChecker.GetRewardInCreditsFromResult(secondLineResult);

        List<int> thirdLine = new List<int>();
        _gridToLineTransformer.GetValuesInHorizontalLine(_grid, out thirdLine, 2);
        LineResult thirdLineResult = linePatternChecker.GetResultFromLine(thirdLine);
        int thirdLineCredits = rewardsChecker.GetRewardInCreditsFromResult(thirdLineResult);

        List<int> fourthLine = new List<int>();
        _gridToLineTransformer.GetValuesInWLine(_grid, out fourthLine);
        LineResult fourthLineResult = linePatternChecker.GetResultFromLine(fourthLine);
        int fourthLineCredits = rewardsChecker.GetRewardInCreditsFromResult(fourthLineResult);

        List<int> fifthLine = new List<int>();
        _gridToLineTransformer.GetValuesInVLine(_grid, out fifthLine);
        LineResult fifthLineResult = linePatternChecker.GetResultFromLine(fifthLine);
        int fifthLineCredits = rewardsChecker.GetRewardInCreditsFromResult(fifthLineResult);

        print("1st LINE: " + firstLineCredits + " | 2nd LINE: " + secondLineCredits + " | 3rd LINE: " + thirdLineCredits + " | 4th LINE: " + fourthLineCredits + " | 5th LINE: " + fifthLineCredits);
    }
}
