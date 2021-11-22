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

        public void ShowCredits(IGameEventData gameEventData)
        {
            var creditsAmount = (gameEventData as CreditsPopupData).CreditsAmount;
            _text.text = $"Credits: {creditsAmount}";
            _text.enabled = true;
            gameObject.SetActive(true);
            StartCoroutine(DisableGameObjectAfterDelay.DisableGOAfterDelay(gameObject));
        }
    }
}

