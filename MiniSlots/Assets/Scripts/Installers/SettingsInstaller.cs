using JGM.Game.Libraries;
using UnityEngine;
using Zenject;

namespace JGM.Game.Installers
{
    [CreateAssetMenu(fileName = "New Settings Installer", menuName = "Installers/Settings Installer")]
    public class SettingsInstaller : ScriptableObjectInstaller<SettingsInstaller>
    {
        [SerializeField] private AudioLibrary _audioLibraryInstance;
        [SerializeField] private GameEventLibrary _gameEventLibraryInstance;
        [SerializeField] private PayTable _payTableInstance;
        [SerializeField] private RollerSequencesLibrary _rollerSequencesLibraryInstance;
        [SerializeField] private SpriteLibrary _spriteLibraryInstance;

        public override void InstallBindings()
        {
            Container.Bind<AudioLibrary>().FromInstance(_audioLibraryInstance);
            Container.Bind<GameEventLibrary>().FromInstance(_gameEventLibraryInstance);
            Container.Bind<PayTable>().FromInstance(_payTableInstance);
            Container.Bind<RollerSequencesLibrary>().FromInstance(_rollerSequencesLibraryInstance);
            Container.Bind<SpriteLibrary>().FromInstance(_spriteLibraryInstance);
        }
    }
}