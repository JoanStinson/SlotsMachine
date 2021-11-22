using TMPro;
using UnityEngine;

namespace JGM.Game.UI
{
    public class UITextSetter : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _text;

        public void SetText(string text)
        {
            _text.text = text;
        }
    }
}