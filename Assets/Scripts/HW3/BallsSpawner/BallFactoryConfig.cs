using UnityEngine;

namespace Lesson4.HW3
{
    [CreateAssetMenu(fileName = "FactoryConfig", menuName = "PopTheBall/FactoryConfig")]
    public class BallFactoryConfig : ScriptableObject
    {
        [SerializeField] private Ball _redBallPrefab;
        [SerializeField] private Ball _blueBallPrefab;

        public Ball RedBallPrefab => _redBallPrefab;
        public Ball BlueBallPrefab => _blueBallPrefab;
    }
}
