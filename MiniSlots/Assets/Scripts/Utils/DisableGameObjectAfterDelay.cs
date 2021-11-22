using System.Collections;
using UnityEngine;

namespace JGM.Game.Utils
{
    public static class DisableGameObjectAfterDelay
    {
        public static IEnumerator DisableGOAfterDelay(GameObject gameObject, float delayToDisableInSeconds = 5f)
        {
            yield return new WaitForSeconds(delayToDisableInSeconds);
            gameObject.SetActive(false);
        }
    }
}