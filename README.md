# MiniSlots
A basic slots machine game done in 5 days using Dependency Injection (Zenject), an Events System and wrote some Unit Tests. Pretty clean code architecture too.

<p align="center">
  <img width="936" height="584" src="https://github.com/JoanStinson/MiniSlots/blob/main/preview.gif">
 </p>

## Dependency Injection (Zenject)
```csharp
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
```
```csharp
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
```

## Events System
```csharp
namespace JGM.Game.Events
{
    [CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event")]
    public class GameEvent : ScriptableObject
    {
        private HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

        public void Register(GameEventListener listener) => _listeners.Add(listener);

        public void Deregister(GameEventListener listener) => _listeners.Remove(listener);

        public void Trigger(in IGameEventData eventData = null)
        {
            Debug.Log($"'<color=green>{name}</color>' game event was triggered!");
            foreach (var listener in _listeners)
            {
                listener?.TriggerEvent(eventData);
            }
        }
    }
}
```
```csharp
namespace JGM.Game.Events
{
    [Serializable]
    public class GameEventListener : MonoBehaviour
    {
        [SerializeField] private GameEvent _gameEvent;
        [SerializeField] private UnityCustomGameDataEvent _onTriggerEvent;

        public GameEventListener(GameEvent unityGameEvent, UnityCustomGameDataEvent unityCustomGameDataEvent)
        {
            _gameEvent = unityGameEvent;
            _onTriggerEvent = unityCustomGameDataEvent;
        }

        public void Awake() => _gameEvent?.Register(this);

        public void OnDestroy() => _gameEvent?.Deregister(this);

        public virtual void TriggerEvent(in IGameEventData eventData) => _onTriggerEvent?.Invoke(eventData);
    }
}
```
```csharp
namespace JGM.Game.Events
{
    public class GameEventTriggerService : MonoBehaviour, IEventTriggerService
    {
        [Inject]
        private GameEventLibrary _gameEventAssets;

        private Dictionary<string, GameEvent> _eventsLibrary;

        private void Awake()
        {
            _eventsLibrary = new Dictionary<string, GameEvent>();
            for (int i = 0; i < _gameEventAssets.Assets.Length; ++i)
            {
                _eventsLibrary.Add(_gameEventAssets.Assets[i].name, _gameEventAssets.Assets[i]);
            }
        }

        public void Trigger(in string eventName, IEventData eventData = null)
        {
            if (!_eventsLibrary.ContainsKey(eventName))
            {
                Debug.LogWarning("Trying to trigger an event that doesn't exist!");
                return;
            }
            var gameEvent = _eventsLibrary[eventName];
            gameEvent.Trigger(eventData as IGameEventData);
        }
    }
}
```

## Unit Tests
<p align="center">
  <img width="864" height="695" src="https://github.com/JoanStinson/MiniSlots/blob/main/unit%20tests.PNG">
 </p>
