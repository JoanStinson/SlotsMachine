using System.Collections.Generic;
using UnityEngine;

namespace JGM.Game.Audio
{
    public class SfxAudioPlayer : MonoBehaviour, ISfxAudioPlayer
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private List<AudioClip> _audioClips;

        private Dictionary<string, AudioClip> _audioLibrary;

        private void Awake()
        {
            _audioLibrary = new Dictionary<string, AudioClip>();
            for (int i = 0; i < _audioClips.Count; ++i)
            {
                _audioLibrary.Add(_audioClips[i].name, _audioClips[i]);
            }
        }

        public SfxAudioPlayer(ref AudioSource audioSource, ref List<AudioClip> audioClips)
        {
            _audioSource = audioSource;
            _audioLibrary = new Dictionary<string, AudioClip>();
            for (int i = 0; i < audioClips.Count; ++i)
            {
                _audioLibrary.Add(audioClips[i].name, audioClips[i]);
            }
        }

        public void PlayLooped(in string audioFilename)
        {
            if (!_audioLibrary.ContainsKey(audioFilename))
            {
                Debug.LogWarning("Trying to play a clip that doesn't exist!");
                return;
            }
            var clip = _audioLibrary[audioFilename];
            _audioSource.clip = clip;
            _audioSource.loop = true;
            _audioSource.Play();
        }

        public void PlayOneShot(in string audioFilename)
        {
            if (!_audioLibrary.ContainsKey(audioFilename))
            {
                Debug.LogWarning("Trying to play a clip that doesn't exist!");
                return;
            }
            var clip = _audioLibrary[audioFilename];
            _audioSource.loop = false;
            _audioSource.PlayOneShot(clip);
        }

        public void Stop()
        {
            _audioSource.Stop();
        }

        public bool IsPlaying()
        {
            return _audioSource.isPlaying;
        }
    }
}