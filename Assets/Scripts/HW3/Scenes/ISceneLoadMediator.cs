namespace Lesson4.HW3
{
    public interface ISceneLoadMediator
    {
        void GoToGamePlay(LevelLoadingData levelLoadingData);

        void GoToWinLevel();
    }
}
