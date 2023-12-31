using Zenject;
using Lesson4.HW1;

namespace Lesson4
{
    public class ServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPauseHandler();
        }

        private void BindPauseHandler()
            => Container.BindInterfacesAndSelfTo<PauseHandler>().AsSingle();
    }
}
