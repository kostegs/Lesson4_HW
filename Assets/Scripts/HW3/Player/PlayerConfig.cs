using UnityEngine;

namespace Lesson4.HW3
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "PopTheBall/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _speed;
        [SerializeField] private Player _playerPrefab;

        public float Speed => _speed;
        public Player PlayerPrefab => _playerPrefab;
    }
}
