using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson4.HW3
{
    public class BallStorage : IDisposable
    {
        public event Action<Ball> BallPoped;        

        private List<Ball> _balls = new List<Ball>();

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
            ball.IsPoped += OnBallPoped;            
        }            

        public void OnBallPoped(Ball ball)
        {
            _balls.Remove(ball);
            BallPoped?.Invoke(ball);
        }            

        public int GetCount(BallColors colour)
            => _balls.Where(ball => ball.Colour == colour).Count();        

        public int GetCount() => _balls.Count;

        public void Dispose()
        {
            foreach (Ball ball in _balls)            
                ball.IsPoped -= OnBallPoped;            
        }
            
    }
}
