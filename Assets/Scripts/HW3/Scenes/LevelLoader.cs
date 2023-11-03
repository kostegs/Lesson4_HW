namespace Lesson4.HW3
{
    public class LevelLoader : ILevelLoader, ISimpleSceneLoader
    {
        private ZenjectSceneLoaderWrapper _sceneLoader;

        public LevelLoader(ZenjectSceneLoaderWrapper sceneLoader)
            => _sceneLoader = sceneLoader;

        public void Load(SceneID sceneId, LevelLoadingData levelLoadingData)
        {
            _sceneLoader.Load(container =>
            {
                container.BindInstance(levelLoadingData).WhenInjectedInto<GamePlaySceneInstaller>();
            }, (int)sceneId);
        }

        public void Load(SceneID SceneId)
            => _sceneLoader.Load(null, (int)SceneId);        
    }
}
