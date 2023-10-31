using System;
using UnityEngine;

namespace Task4
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Camera _currentCamera;
        [SerializeField] float _speed;

        public event Action OnWin;

        private Vector3 _target;
        private bool _isMoving;
        private IWinningStrategy _winningStrategy;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Ray ray = _currentCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit))
                    _target = new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z);

                _isMoving = true;
            }

            if (_isMoving && (transform.position - _target).sqrMagnitude <= 0.1)            
                _isMoving = false;
            
            if (_isMoving)
            {
                Vector3 direction = _target - transform.position;
                transform.Translate(direction.normalized * _speed * Time.deltaTime);
            }
        }

        public void OnStrategyChoosen(object sender, StrategyEventArgs eventArgs)
        {
            var winningStrategy = eventArgs.WinningStrategy;

            switch (winningStrategy)
            {
                case EnumWinningStrategy.DestroyAllColors:
                    _winningStrategy = new Strategy_DestroyAll();
                    break;
                case EnumWinningStrategy.DestroyAllElementsOfOneColor:
                    _winningStrategy = new Strategy_DestroyAllOneColor();
                    break;
            }
        }

        public void CheckWinning(object sender, SphereEventArgs eventArgs)
        {
            if (_winningStrategy != null)
            {
                bool isWin = _winningStrategy.CheckWinning(eventArgs.CountOfColors);

                if (isWin)
                {
                    OnWin?.Invoke();
                    gameObject.SetActive(false);                    
                }
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Vector3.zero, _target);
        }
#endif
    }
}
