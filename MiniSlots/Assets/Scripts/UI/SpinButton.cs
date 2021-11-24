using JGM.Game.Audio;
using JGM.Game.Events;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace JGM.Game.UI
{
    [RequireComponent(typeof(Button))]
    public class SpinButton : MonoBehaviour
    {
        [SerializeField]
        private GameEvent _startSpinEvent;

        [Inject]
        private IAudioService _audioService;

        private Button _spinButton;

        private void Awake()
        {
            _spinButton = GetComponent<Button>();
        }

        public void TriggerStartSpinEvent()
        {
            _audioService.Play("Press Button");
            StartCoroutine(SendStartSpinEventAfterAudioFinishedPlaying());
        }

        private IEnumerator SendStartSpinEventAfterAudioFinishedPlaying()
        {
            yield return new WaitWhile(() => _audioService.IsPlaying("Press Button"));
            _startSpinEvent.Trigger();
        }

        public void SetButtonInteraction(bool makeInteractable)
        {
            _spinButton.interactable = makeInteractable;
        }
    }
}