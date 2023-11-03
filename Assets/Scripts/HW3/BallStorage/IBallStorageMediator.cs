using System;

namespace Lesson4.HW3
{
    public interface IBallStorageMediator
    {
        public event Action<Ball> BallPoped;        

        void OnBallSpawned(Ball ball);

        void OnBallPoped(Ball ball);

        int GetCount(BallColors color);

        int GetCount();
    }
}
