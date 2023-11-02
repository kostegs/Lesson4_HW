using System;
using UnityEngine;
using UnityEngine.UI;

namespace Level4.HW2
{
    public class DefeatPanel : MonoBehaviour
    {
        [SerializeField] private Button _restart;

        public event Action RestartButtonPressed;

        private void OnEnable() => _restart.onClick.AddListener(OnRestartClick);

        private void OnDisable() => _restart.onClick.RemoveListener(OnRestartClick);

        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);

        private void OnRestartClick() => RestartButtonPressed?.Invoke();
    }
}
