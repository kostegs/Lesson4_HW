using System;
using System.Collections;

namespace Task4
{
    public class SphereEventArgs : EventArgs
    {
        public IEnumerable CountOfColors;

        public SphereEventArgs(IEnumerable countOfColors) => CountOfColors = countOfColors;
    }

    public class StrategyEventArgs : EventArgs
    {
        public EnumWinningStrategy WinningStrategy;

        public StrategyEventArgs(EnumWinningStrategy winningStrategy) => WinningStrategy = winningStrategy;
    }
}
