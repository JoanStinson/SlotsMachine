using JGM.Game.Events;
using JGM.Game.Utils;
using TMPro;
using UnityEngine;

namespace JGM.Game.UI
{
    public class CreditsPopup : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void Initialize(TextMeshProUGUI textMeshProUGUI)
        {
            _text = textMeshProUGUI;
        }

        public void ShowCredits(IGameEventData gameEventData)
        {
            ShowCredits(gameEventData as ICreditsPopupData);
        }

        public void ShowCredits(ICreditsPopupData creditsPopupData)
        {
            Debug.Assert(creditsPopupData != null);
            var creditsAmount = creditsPopupData.CreditsAmount;
            _text.text = $"Credits: {creditsAmount}";
            _text.enabled = true;
            gameObject.SetActive(true);
            StartCoroutine(ObjectDisabler.DisableGOAfterDelay(gameObject));
        }
    }
}