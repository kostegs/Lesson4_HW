using UnityEngine;
using Zenject;

namespace Lesson4.HW3
{
    public class PopTheBallInstaller : MonoInstaller
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Camera _camera;
        [SerializeField] private BallFactoryConfig _ballsFactoryConfig;
        [SerializeField] private SpawnPointsStorage _spawnPointsStorage;

        public override void InstallBindings()
        {
            InstallCamera();
            InstallTargetSearcher();
            InstallPlayer();
            InstallFactory();
            InstallSpawner();
            InstallBallStorage();
            InstallVictoryCondition();
            InstallGamePlayLevel();
        }

        private void InstallCamera()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        }

        private void InstallTargetSearcher()
        {
            Container.BindInterfacesAndSelfTo<TargetSearcher>().AsSingle().NonLazy();
        }

        private void InstallPlayer()
        {
            Container.Bind<PlayerConfig>().FromInstance(_playerConfig).AsSingle();
            Container.InstantiatePrefabForComponent<Player>(_playerConfig.PlayerPrefab, _playerSpawnPoint.position, Quaternion.identity, null);
        }

        private void InstallFactory()
        {
            Container.Bind<BallFactoryConfig>().FromInstance(_ballsFactoryConfig).WhenInjectedInto<BallFactory>();            
            Container.Bind<BallFactory>().AsSingle();            
        }

        public void InstallSpawner()
        {
            Container.Bind<SpawnPointsStorage>().FromInstance(_spawnPointsStorage).WhenInjectedInto<BallsSpawner>();
            Container.Bind<BallsSpawner>().AsSingle().NonLazy();
        }

        public void InstallBallStorage()
        {
            Container.BindInterfacesAndSelfTo<BallStorage>().AsSingle().WhenInjectedInto<BallStorageMediator>();
            Container.BindInterfacesAndSelfTo<BallStorageMediator>().AsSingle().NonLazy();            
        }

        public void InstallVictoryCondition()
        {
            Container.BindInterfacesAndSelfTo<VictoryCondition>().AsSingle().NonLazy();    
        }

        public void InstallGamePlayLevel()
        {
            Container.BindInterfacesAndSelfTo<GamePlayLevel>().AsSingle().NonLazy();
        }
    }
}
