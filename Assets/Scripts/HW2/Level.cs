using System;
using UnityEngine;

public class Level
{
    public event Action Defeat;

    public void Start()
    {
        // Логика старта игры
        Debug.Log("Start level");
    }

    public void Restart()
    {
        // Очистка уровня
        Start();
    }

    public void OnDefeat()
    {
        // Логика остановки игры
        Defeat?.Invoke();
    }    
}
