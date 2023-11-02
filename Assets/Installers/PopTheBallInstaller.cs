using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lesson4.HW3
{
    public class PopTheBallInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
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
            Container.Bind<Player>().FromInstance(_player).AsSingle();
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
    }
}
