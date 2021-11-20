using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SpinButton : MonoBehaviour
{
    [SerializeField] 
    private GameEvent _startSpinEvent;

    private Button _spinButton;

    private void Awake()
    {
        _spinButton = GetComponent<Button>();
    }

    public void StartSpin()
    {
        _startSpinEvent.Trigger();
        _spinButton.interactable = false;
    }

    public void SpinStopped()
    {
        _spinButton.interactable = true;
    }
}
