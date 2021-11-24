using JGM.Game.Audio;
using UnityEngine;
using Zenject;

namespace JGM.Game
{
    public class GameManager : MonoBehaviour
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