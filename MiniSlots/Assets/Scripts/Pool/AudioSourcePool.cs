using JGM.Game.Utils;
using UnityEngine;

namespace JGM.Game.Pool
{
    public class AudioSourcePool : ComponentPool<AudioSource>
    {
        private readonly MonoBehaviour _monoBehaviour;

        public AudioSourcePool(int poolSize, Transform poolParent, MonoBehaviour monoBehaviour) : base(poolSize, poolParent)
        {
            _monoBehaviour = monoBehaviour;
        }

        public void Play(in AudioClip audioClip, bool loop = false)
        {
            if (!loop)
            {
                PlayOneShot(audioClip);
            }
            else
            {
                PlayLooped(audioClip);
            }
        }

        public void Stop(in AudioClip audioClip)
        {
            foreach (var audioSource in _pool)
            {
                if (audioSource.isPlaying && audioSource.clip == audioClip)
                {
                    audioSource.Stop();
                    audioSource.gameObject.SetActive(false);
                    break;
                }
            }
        }

        public bool IsPlaying(in AudioClip audioClip)
        {
            foreach (var audioSource in _pool)
            {
                if (audioSource.gameObject.activeSelf && audioSource.clip == audioClip)
                {
                    return audioSource.isPlaying;
                }
            }
            return false;
        }

        public void SetVolume(in AudioClip audioClip, in float volume)
        {
            foreach (var audioSource in _pool)
            {
                if (audioSource.clip == audioClip)
                {
                    audioSource.volume = volume;
                    break;
                }
            }
        }

        private void PlayOneShot(in AudioClip audioClip)
        {
            Get(out var audioSource);
            audioSource.loop = false;
            audioSource.PlayOneShot(audioClip);
            _monoBehaviour.StartCoroutine(ObjectDisabler.DisableAudioSourceAfterFinishedPlaying(audioSource));
        }

        private void PlayLooped(in AudioClip audioClip)
        {
            Get(out var audioSource);
            audioSource.clip = audioClip;
            audioSource.loop = true;
            audioSource.Play();
            _monoBehaviour.StartCoroutine(ObjectDisabler.DisableAudioSourceAfterFinishedPlaying(audioSource));
        }
    }
}