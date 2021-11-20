using System.Collections;
using UnityEngine;

public class RollerManager : MonoBehaviour
{
    [SerializeField] private GameObject _rollerPrefab;
    [SerializeField] private GameEvent _stoppedSpinEvent;

    private const int _numberOfRollers = 5;
    private Roller[] _rollers;
    private float _startingRollerXPosition = -477f;
    private float _spacingBetweenRollers = 238.5f;

    private void Start()
    {
        _rollers = new Roller[_numberOfRollers];
        for (int i = 0; i < _rollers.Length; ++i)
        {
            var rollerGO = Instantiate(_rollerPrefab, transform);
            var localPosition = Vector3.right * (_startingRollerXPosition + (i * _spacingBetweenRollers));
            rollerGO.transform.localPosition = localPosition;
            var roller = rollerGO.GetComponent<Roller>();
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
            yield return new WaitWhile(() => _rollers[i].IsSpinning);
        }
        _stoppedSpinEvent.Trigger();
    }
}
