using System;
using System.Collections;
using System.Collections.Generic;

namespace Lesson4.HW3
{
    public class BallStorage
    {
        public IEnumerable CountOfColors => _countOfColors;
        public event EventHandler<SphereEventArgs> CountOfColorsChanged;

        private Dictionary<BallColors, int> _countOfColors;

        public void Initialize(IEnumerable ballList)
        {
            _countOfColors = new Dictionary<BallColors, int>();

            foreach (Ball ball in ballList)
            {
                AddColorCount(ball.Color, 1);
                ball.SetBallStorage(this);
            }                
        }

        public void AddColorCount(BallColors color, int count)
        {
            if (_countOfColors.ContainsKey(color))
                _countOfColors[color] += count;
            else
                _countOfColors.Add(color, count);

            CountOfColorsChanged?.Invoke(this, new SphereEventArgs(_countOfColors));
        }

        public void SubtractColorCount(BallColors color, int count)
        {
            if (_countOfColors == null)
                _countOfColors = new Dictionary<BallColors, int>();

            if (_countOfColors.ContainsKey(color))
                _countOfColors[color] -= count;

            CountOfColorsChanged?.Invoke(this, new SphereEventArgs(_countOfColors));
        }

    }
}
