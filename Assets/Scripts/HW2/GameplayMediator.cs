using System;

namespace Level4.HW2
{
    public class GameplayMediator : IDisposable
    {
        private DefeatPanel _defeatPanel;
        private Level _level;

        public GameplayMediator(DefeatPanel defeatPanel, Level level)
        {
            _defeatPanel = defeatPanel;
            _defeatPanel.RestartButtonPressed += OnRestartButtonPressed;

            _level = level;
            _level.Defeat += OnLevelDefeat;
        }

        public void Dispose()
        {
            _level.Defeat -= OnLevelDefeat;
            _defeatPanel.RestartButtonPressed -= OnRestartButtonPressed;
        }

        public void RestartLevel()
        {
            _defeatPanel.Hide();
            _level.Restart();
        }

        private void OnLevelDefeat() => _defeatPanel.Show();

        private void OnRestartButtonPressed() => RestartLevel();
    }
}
