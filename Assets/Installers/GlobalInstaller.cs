using Zenject;

namespace Lesson4
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputHandler();
            BindSceneLoaders();
        }

        public void BindInputHandler()
            => Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();

        public void BindSceneLoaders()
        {
            Container.BindInterfacesAndSelfTo<HW3.ZenjectSceneLoaderWrapper>().AsSingle();
            Container.BindInterfacesAndSelfTo<HW3.LevelLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<HW3.SceneLoadMediator>().AsSingle();
        }
    }
}
