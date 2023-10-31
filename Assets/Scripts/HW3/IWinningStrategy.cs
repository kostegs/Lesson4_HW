using System.Collections;

namespace Task4
{
    public interface IWinningStrategy
    {
        bool CheckWinning(IEnumerable countOfColors);
    }
}
