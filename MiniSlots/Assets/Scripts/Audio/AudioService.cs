using JGM.Game.Libraries;
using JGM.Game.Pool;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace JGM.Game.Audio
{
    public class AudioService : MonoBehaviour, IAudioService
    {
        [SerializeField]
        [Range(1, 20)]
        private int _maxSimultaneousAudioSources = 10;

        [Inject]
        private AudioLibrary _audioAssets;

        private AudioSourcePool _audioSourcePool;
        private Dictionary<string, AudioClip> _audioLibrary;

        private void Awake()
        {
            _audioSourcePool = new AudioSourcePool(_maxSimultaneousAudioSources, transform, this);
            _audioLibrary = new Dictionary<string, AudioClip>();
            for (int i = 0; i < _audioAssets.Assets.Length; ++i)
            {
                _audioLibrary.Add(_audioAssets.Assets[i].name, _audioAssets.Assets[i]);
            }
        }

        public void Play(in string audioFileName, bool loop = false)
        {
            if (!_audioLibrary.ContainsKey(audioFileName))
            {
                Debug.LogWarning("Trying to play a clip that doesn't exist!");
                return;
            }
            var audioClip = _audioLibrary[audioFileName];
            _audioSourcePool.Play(audioClip, loop);
        }

        public void Stop(in string audioFileName)
        {
            if (!_audioLibrary.ContainsKey(audioFileName))
            {
                Debug.LogWarning("Trying to play a clip that doesn't exist!");
                return;
            }
            var audioClip = _audioLibrary[audioFileName];
            _audioSourcePool.Stop(audioClip);
        }

        public bool IsPlaying(in string audioFileName)
        {
            if (!_audioLibrary.ContainsKey(audioFileName))
            {
                Debug.LogWarning("Trying to play a clip that doesn't exist!");
                return false;
            }
            var audioClip = _audioLibrary[audioFileName];
            return _audioSourcePool.IsPlaying(audioClip);
        }

        public void SetVolume(in string audioFileName, in float volume)
        {
            if (!_audioLibrary.ContainsKey(audioFileName))
            {
                Debug.LogWarning("Trying to play a clip that doesn't exist!");
                return;
            }
            var audioClip = _audioLibrary[audioFileName];
            _audioSourcePool.SetVolume(audioClip, volume);
        }
    }
}