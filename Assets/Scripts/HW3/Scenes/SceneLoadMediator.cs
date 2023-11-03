namespace Lesson4.HW3
{
    public class SceneLoadMediator : ISceneLoadMediator
    {
        private ILevelLoader _levelLoader;
        private ISimpleSceneLoader _simpleSceneLoader;

        public SceneLoadMediator(ILevelLoader levelLoader, ISimpleSceneLoader simpleSceneLoader)
        {
            _levelLoader = levelLoader;
            _simpleSceneLoader = simpleSceneLoader;
        }            

        public void GoToGamePlay(LevelLoadingData levelLoadingData)
            => _levelLoader.Load(SceneID.GamePlay, levelLoadingData);

        public void GoToWinLevel()
            => _simpleSceneLoader.Load(SceneID.Win);        
    }
}
