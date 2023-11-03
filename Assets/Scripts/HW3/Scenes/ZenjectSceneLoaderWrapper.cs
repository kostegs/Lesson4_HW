using System;
using UnityEngine.SceneManagement;
using Zenject;

namespace Lesson4.HW3
{
    public class ZenjectSceneLoaderWrapper
    {
        private readonly ZenjectSceneLoader _zenjectSceneLoader;

        public ZenjectSceneLoaderWrapper(ZenjectSceneLoader zenjectSceneLoader)
        {
            _zenjectSceneLoader = zenjectSceneLoader;
        }

        public void Load(Action<DiContainer> action, int sceneID)
            => _zenjectSceneLoader.LoadScene(sceneID, LoadSceneMode.Single, action);
    }
}
