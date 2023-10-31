using Zenject;

public class SpawnerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
    }
}
