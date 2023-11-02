using System;
using UnityEngine;
using Zenject;

namespace Lesson4
{
    public class InputHandler : ITickable
    {
        public event Action KeyPauseOnPressed;
        public event Action KeyPauseOffPressed;
        public event Action KeyDefeatPressed;
        public event Action<Vector3> MouseLeftButtonPressed;

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.F))
                KeyPauseOnPressed?.Invoke();

            if (Input.GetKeyDown(KeyCode.S))
                KeyPauseOffPressed?.Invoke();

            if (Input.GetKeyDown(KeyCode.Space))
                KeyDefeatPressed?.Invoke();

            if (Input.GetKeyDown(KeyCode.Mouse0))
                MouseLeftButtonPressed?.Invoke(Input.mousePosition);

        }
    }
}
