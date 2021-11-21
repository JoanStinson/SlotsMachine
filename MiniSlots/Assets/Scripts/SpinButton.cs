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

    public void TriggerStartSpinEvent()
    {
        _startSpinEvent.Trigger();
    }

    public void SetButtonInteraction(bool makeInteractable)
    {
        _spinButton.interactable = makeInteractable;
    }
}
