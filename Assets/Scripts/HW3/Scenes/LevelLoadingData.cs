namespace Lesson4.HW3
{
    public class LevelLoadingData
    {
        private WinningStrategy _winningStrategy;

        public LevelLoadingData(WinningStrategy winningStrategy)
        {
            _winningStrategy = winningStrategy;
        }

        public WinningStrategy WinningStrategy { get => _winningStrategy; }
    }
}
