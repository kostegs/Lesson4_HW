using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMediator : MonoBehaviour
{
    [SerializeField] private DefeatPanel _defeatPanel;

    private Level _level;

    private void OnDisable() => _level.Defeat -= OnLevelDefeat;

    public void Initialize(Level level)
    {
        _level = level;
        _level.Defeat += OnLevelDefeat;
    }

    public void RestartLevel()
    {
        _defeatPanel.Hide();
        _level.Restart();
    }

    private void OnLevelDefeat() => _defeatPanel.Show();

}
