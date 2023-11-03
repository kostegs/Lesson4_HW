using Zenject;

namespace Lesson4.HW3
{
    public class GamePlaySceneInstaller : MonoInstaller
    {
        private LevelLoadingData _levelLoadingData;

        [Inject]
        private void Construct(LevelLoadingData levelLoadingData)
            =>  _levelLoadingData = levelLoadingData;

        public override void InstallBindings()
        {
            Container.Bind<LevelLoadingData>().FromInstance(_levelLoadingData);
        }        
    }
}
