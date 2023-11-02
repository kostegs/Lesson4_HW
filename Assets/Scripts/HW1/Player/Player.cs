using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Lesson4.HW1
{
    public class Player : MonoBehaviour, IEnemyTarget
    {
        private int _maxHealth;
        private int _health;

        public Vector3 Position => transform.position;

        [Inject]
        public void Construct(PlayerStatsConfig config)
        {
            _health = _maxHealth = config.MaxHealth;
            Debug.Log($"У меня {_health} HP");
        }

        public void TakeDamage(int damage)
        {
            // Проверка урона
            Debug.Log($"Получил {damage} урона");
        }
    }
}
