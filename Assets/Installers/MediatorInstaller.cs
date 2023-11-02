using UnityEngine;
using Zenject;

namespace Level4.HW2
{
    public class MediatorInstaller : MonoInstaller
    {
        [SerializeField] private DefeatPanel _defeatPanel;

        public override void InstallBindings()
        {
            InstallDefeatPanel();
            InstallLevel();
            InstallMediator();
        }

        public void InstallDefeatPanel()
        {
            Container.Bind<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();
        }

        public void InstallLevel()
        {
            Container.BindInterfacesAndSelfTo<Level>().AsSingle().NonLazy();
        }

        public void InstallMediator()
        {
            Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle().NonLazy();
        }
    }
}
