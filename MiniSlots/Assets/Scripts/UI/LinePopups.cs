using JGM.Game.Events;
using JGM.Game.Utils;
using UnityEngine;

namespace JGM.Game.UI
{
    public class LinePopups : MonoBehaviour
    {
        [SerializeField]
        private Transform[] _lines;

        public void ShowLinePopup(IGameEventData gameEventData)
        {
            var lineIndex = (gameEventData as LinePopupData).LineIndex;
            _lines[lineIndex].gameObject.SetActive(true);
            StartCoroutine(DisableGameObjectAfterDelay.DisableGOAfterDelay(_lines[lineIndex].gameObject));
        }
    }
}