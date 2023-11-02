using System.Collections;
using System.Collections.Generic;

namespace Lesson4.HW3
{
    public class Strategy_DestroyAll : IWinningStrategy
    {
        public bool CheckWinning(IEnumerable countOfColors)
        {
            foreach (var color in countOfColors as Dictionary<BallColors, int>)
                if (color.Value != 0)
                    return false;

            return true;
        }
    }
}
