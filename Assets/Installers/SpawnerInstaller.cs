using Lesson4.HW1;
using System;
using UnityEngine;
using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    [SerializeField] private CoroutinePerformer _coroutinePerformer;
    [SerializeField] private EnemySpawnerConfig _enemySpawnerConfig;
    [SerializeField] private SpawnPoints _spawnPoints;

    public override void InstallBindings()
    {
        InstallFactory();        
        InstallCoroutinePerformer();
        InstallSpawnerConfig();
        InstallSpawnPoints();
        InstallSpawner();
    }

    public void InstallFactory() 
        => Container.Bind<EnemyFactory>().AsSingle();    

    public void InstallCoroutinePerformer() 
        => Container.Bind<ICoroutinePerformer>().FromInstance(_coroutinePerformer).AsSingle();

    public void InstallSpawnerConfig() 
        => Container.Bind<EnemySpawnerConfig>().FromInstance(_enemySpawnerConfig).AsSingle();

    public void InstallSpawnPoints() 
        => Container.Bind<SpawnPoints>().FromInstance(_spawnPoints).AsSingle();

    public void InstallSpawner() 
        => Container.Bind<EnemySpawner>().AsSingle().NonLazy();

    
}
