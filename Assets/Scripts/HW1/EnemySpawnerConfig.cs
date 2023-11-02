using UnityEngine;

namespace Lesson4.HW1
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawner")]
    public class EnemySpawnerConfig : ScriptableObject
    {
        [SerializeField] private float _spawnCooldown;

        public float SpawnCooldown => _spawnCooldown;
    }
}