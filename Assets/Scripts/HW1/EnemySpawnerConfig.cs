using UnityEngine;

[CreateAssetMenu(fileName = "EnemySpawnerConfig", menuName = "Configs/EnemySpawner")]
public class EnemySpawnerConfig : ScriptableObject
{
    [SerializeField] private float _spawnCooldown;    

    public float SpawnCooldown => _spawnCooldown;
}
