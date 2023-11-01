using System;
using UnityEngine;
using Zenject;

public class InputHandler : ITickable
{
    public event Action KeyPauseOnPressed;
    public event Action KeyPauseOffPressed;

    public void Tick()
    {
        if (Input.GetKeyDown(KeyCode.F))
            KeyPauseOnPressed?.Invoke();

        if (Input.GetKeyDown(KeyCode.S))
            KeyPauseOffPressed?.Invoke();
    }
}
