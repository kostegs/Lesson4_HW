using UnityEngine;

namespace Lesson4.HW1
{
    [CreateAssetMenu(fileName = "PlayerStatsConfig", menuName = "Player/PlayerStatsConfig")]
    public class PlayerStatsConfig : ScriptableObject
    {
        [SerializeField, Range(0, 50)] private int _maxHealth;

        public int MaxHealth => _maxHealth;
    }
}