using UnityEngine;
using Zenject;

namespace JGM.Game.Audio
{
    public class BackgroundMusic : MonoBehaviour
    {
        [Inject]
        private IAudioService _audioService;

        private void Start()
        {
            _audioService.Play("Casino Crime Funk", true);
            _audioService.SetVolume("Casino Crime Funk", 0.3f);
        }
    }
}