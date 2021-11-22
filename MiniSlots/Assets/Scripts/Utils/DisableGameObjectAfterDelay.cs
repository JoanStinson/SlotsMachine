using System.Collections;
using UnityEngine;

namespace JGM.Game.Utils
{
    public class DisableGameObjectAfterDelay : MonoBehaviour
    {
        [SerializeField]
        private float _delayInSecondsToDisable = 5f;

        public void DisableGameObject()
        {
            StartCoroutine(DisableAfterDelay());
        }

        private IEnumerator DisableAfterDelay()
        {
            yield return new WaitForSeconds(_delayInSecondsToDisable);
            gameObject.SetActive(false);
        }
    }
}