using System.Collections;

namespace Lesson4.HW3
{
    public interface IWinningStrategy
    {
        bool CheckWinning(IEnumerable countOfColors);
    }
}
