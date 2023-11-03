using System;

namespace Lesson4.HW3
{
    public class GamePlayLevel : IDisposable
    {
        private ISceneLoadMediator _sceneLoadMediator;
        private IVictoryCondition _victoryCondition;

        public GamePlayLevel(ISceneLoadMediator sceneLoadMediator, IVictoryCondition victoryCondition)
        {
            _sceneLoadMediator = sceneLoadMediator;
            _victoryCondition = victoryCondition;
            _victoryCondition.IsConditionExecuted += OnVictoryConditionExecuted;
        }

        public void Dispose() 
            => _victoryCondition.IsConditionExecuted -= OnVictoryConditionExecuted;
        
        private void OnVictoryConditionExecuted()
            => _sceneLoadMediator.GoToWinLevel();        
    }
}
