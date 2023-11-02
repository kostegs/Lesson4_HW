using UnityEngine;
using Zenject;

namespace Lesson4.HW1
{
    public class Enemy : MonoBehaviour, IPause
    {
        private int _health;
        private float _speed;

        private IEnemyTarget _target;

        private bool _isPaused;

        [Inject]
        private void Counstruct(IEnemyTarget enemyTarget)
        {
            _target = enemyTarget;
        }

        private void Update()
        {
            if (_isPaused)
                return;

            Vector3 direction = (_target.Position - transform.position).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
        }

        public void Initialize(int health, float speed)
        {
            _health = health;
            _speed = speed;

            Debug.Log($"ХП: {_health}, скорость: {_speed}");
        }

        public void MoveTo(Vector3 position) => transform.position = position;

        public void SetPause(bool isPaused) => _isPaused = isPaused;
    }
}

