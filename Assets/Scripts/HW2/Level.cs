using Lesson4;
using System;
using UnityEngine;

namespace Level4.HW2
{
    public class Level : IDisposable
    {
        public event Action Defeat;

        private InputHandler _inputHandler;

        public Level(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
            _inputHandler.KeyDefeatPressed += OnDefeat;
            Start();
        }

        public void Dispose() => _inputHandler.KeyDefeatPressed -= OnDefeat;

        public void Start()
        {
            // ������ ������ ����
            Debug.Log("Start level");
        }

        public void Restart()
        {
            // ������� ������
            Start();
        }

        public void OnDefeat()
        {
            // ������ ��������� ����
            Defeat?.Invoke();
        }
    }
}
