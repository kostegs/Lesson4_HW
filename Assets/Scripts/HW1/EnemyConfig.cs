using System;
using UnityEngine;

namespace Lesson4.HW1
{
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "EnemyConfigs/Config")]
    public class EnemyConfig : ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField, Range(1, 10)] private int _health;
        [SerializeField, Range(1, 10)] private float _speed;

        public Enemy Prefab => _prefab;
        public int Health => _health;
        public float Speed => _speed;
    }
}