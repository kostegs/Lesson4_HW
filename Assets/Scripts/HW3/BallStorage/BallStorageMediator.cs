using System;

namespace Lesson4.HW3
{
    public class BallStorageMediator : IBallStorageMediator, IDisposable
    {
        public event Action<Ball> BallPoped;        
        
        private BallsSpawner _ballsSpawner;
        private BallStorage _ballStorage;

        public BallStorageMediator(BallsSpawner ballsSpawner, BallStorage ballStorage)
        {
            _ballsSpawner = ballsSpawner;
            _ballsSpawner.BallSpawned += OnBallSpawned;
            _ballStorage = ballStorage;
            _ballStorage.BallPoped += OnBallPoped;            
        }

        public void Dispose()
        {
            _ballsSpawner.BallSpawned -= OnBallSpawned;
            _ballStorage.BallPoped -= OnBallPoped;            
        }

        public void OnBallSpawned(Ball ball)
            => _ballStorage.AddBall(ball);      
        
        public void OnBallPoped(Ball ball)
            => BallPoped?.Invoke(ball);
       
        public int GetCount(BallColors color) => _ballStorage.GetCount(color);
        
        public int GetCount() => _ballStorage.GetCount();        
    }
}
