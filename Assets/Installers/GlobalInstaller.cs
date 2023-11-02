using Zenject;

namespace Lesson4
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputHandler();
        }

        public void BindInputHandler()
            => Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
    }
}
