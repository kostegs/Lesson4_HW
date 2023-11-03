using System;

namespace Lesson4.HW3
{
    public class VictoryCondition : IVictoryCondition, IDisposable
    {
        public event Action IsConditionExecuted;

        public VictoryCondition(LevelLoadingData levelLoadingData, IBallStorageMediator ballStorageMediator)
        {
            _winningStrategy = levelLoadingData.WinningStrategy;

            switch (_winningStrategy)
            {
                case WinningStrategy.DestroyAllColors:
                    _victoryConditionChecker = new Strategy_DestroyAll(ballStorageMediator);
                    break;
                case WinningStrategy.DestroyAllElementsOfOneColor:
                    _victoryConditionChecker = new Strategy_DestroyAllOneColor(ballStorageMediator);
                    break;
                default:
                    throw new ArgumentException(nameof(_winningStrategy));
            }

            _ballStorageMediator = ballStorageMediator;
            _ballStorageMediator.BallPoped += OnBallPoped;
        }

        private WinningStrategy _winningStrategy;
        private IWinningStrategy _victoryConditionChecker;
        private IBallStorageMediator _ballStorageMediator;
        
        public void Dispose() => _ballStorageMediator.BallPoped -= OnBallPoped;
        
        private void OnBallPoped(Ball ball)
        {
            if (_victoryConditionChecker.CheckWinning())
                IsConditionExecuted?.Invoke();
        }
            
    }
}