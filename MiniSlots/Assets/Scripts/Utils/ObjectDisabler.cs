using System.Collections;
using UnityEngine;

namespace JGM.Game.Utils
{
    public static class ObjectDisabler
    {
        public const float DefaultDelayTime = 5f;

        public static IEnumerator DisableGOAfterDelay(GameObject gameObject, float delayToDisableInSeconds = DefaultDelayTime)
        {
            yield return new WaitForSeconds(delayToDisableInSeconds);
            gameObject.SetActive(false);
        }

        public static IEnumerator DisableAudioSourceAfterFinishedPlaying(AudioSource audioSource)
        {
            yield return new WaitWhile(() => audioSource.isPlaying);
            audioSource.gameObject.SetActive(false);
        }
    }
}