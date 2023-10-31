using System.Collections;
using System.Collections.Generic;

namespace Task4
{
    public class Strategy_DestroyAll : IWinningStrategy
    {
        public bool CheckWinning(IEnumerable countOfColors)
        {
            foreach (var color in countOfColors as Dictionary<SphereColors, int>)
                if (color.Value != 0)
                    return false;

            return true;
        }
    }
}
