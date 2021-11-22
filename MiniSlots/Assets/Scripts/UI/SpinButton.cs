using JGM.Game.Events;
using UnityEngine;
using UnityEngine.UI;

namespace JGM.Game.UI
{
    [RequireComponent(typeof(Button))]
    public class SpinButton : MonoBehaviour
    {
        [SerializeField]
        private EmptyGameEvent _startSpinEvent;

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
}