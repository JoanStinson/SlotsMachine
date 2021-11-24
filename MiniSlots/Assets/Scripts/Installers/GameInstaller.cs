using JGM.Game.Audio;
using JGM.Game.Events;
using JGM.Game.Patterns;
using JGM.Game.Rewards;
using JGM.Game.Rollers;
using UnityEngine;
using Zenject;

namespace JGM.Game.Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private AudioService _audioServiceInstance;
        [SerializeField] private GameEventTriggerService _triggerServiceInstance;
        [SerializeField] private Roller _rollerPrefab;
        [SerializeField] private RollerItem _rollerItemPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IAudioService>().FromInstance(_audioServiceInstance);
            Container.Bind<IEventTriggerService>().FromInstance(_triggerServiceInstance);
            Container.Bind<IGridToLineConverter>().To<GridToLineConverter>().AsSingle();
            Container.Bind<ILinePatternChecker>().To<LinePatternChecker>().AsSingle();
            Container.Bind<IPayTableRewardsRetriever>().To<PayTableRewardsRetriever>().AsSingle();
            Container.BindFactory<Roller, RollerFactory>().FromComponentInNewPrefab(_rollerPrefab);
            Container.BindFactory<RollerItem, RollerItemFactory>().FromComponentInNewPrefab(_rollerItemPrefab);
        }
    }
}