using Zenject;

public class ServiceInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPauseHandler();
    }

    private void BindPauseHandler()
        => Container.BindInterfacesAndSelfTo<PauseHandler>().AsSingle();    
}
