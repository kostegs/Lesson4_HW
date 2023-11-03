namespace Lesson4.HW3
{
    public class Strategy_DestroyAll : IWinningStrategy
    {
        private IBallStorageMediator _ballStorage;

        public Strategy_DestroyAll(IBallStorageMediator ballStorage)
            => _ballStorage = ballStorage;
        
        public bool CheckWinning()
            => _ballStorage.GetCount() == 0;            
    }
}
