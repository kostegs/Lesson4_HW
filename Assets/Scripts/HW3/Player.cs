using ModestTree;
using System;
using UnityEngine;
using Zenject;

namespace Lesson4.HW3
{
    public class Player : MonoBehaviour
    {
        [SerializeField] Camera _currentCamera;
        [SerializeField] float _speed;

        public event Action OnWin;

        private Vector3 _target;
        private bool _isMoving;
        private IWinningStrategy _winningStrategy;
        private TargetSearcher _targetSearcher;

        [Inject]
        private void Construct(TargetSearcher targetSearcher)
        {
            _targetSearcher = targetSearcher;
        }

        private void OnEnable() => _targetSearcher.TargetDefined += OnTargetDefined;

        private void OnDisable() => _targetSearcher.TargetDefined -= OnTargetDefined;

        private void Update()
        {
            if (_target == null)
                return;

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

        public void OnTargetDefined(Vector3 target)
        {
            _target = new Vector3(target.x, transform.position.y, target.z);
            _isMoving = true;
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
