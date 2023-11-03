using UnityEngine;
using Zenject;

namespace Lesson4.HW3
{
    public class Player : MonoBehaviour
    {        
        private Vector3 _target;
        private bool _isMoving;
        private float _speed;

        private TargetSearcher _targetSearcher;
        private PlayerConfig _playerConfig;

        [Inject]
        private void Construct(TargetSearcher targetSearcher, PlayerConfig playerConfig)
        {
            _targetSearcher = targetSearcher;
            _playerConfig = playerConfig;
            _speed = _playerConfig.Speed;
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
