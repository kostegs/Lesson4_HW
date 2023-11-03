using System;

namespace Lesson4.HW3
{
    public class Strategy_DestroyAllOneColor : IWinningStrategy
    {
        private IBallStorageMediator _ballStorage;

        public Strategy_DestroyAllOneColor(IBallStorageMediator ballStorage)
            => _ballStorage = ballStorage;

        public bool CheckWinning()
        {
            var ballColors = Enum.GetValues(typeof(BallColors));

            foreach (var colour in ballColors)
            {
                if (_ballStorage.GetCount((BallColors)colour) == 0)
                    return true;
            }

            return false;
        }
    }
}
