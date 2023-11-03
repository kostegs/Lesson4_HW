using UnityEngine;
using Zenject;

namespace Lesson4.HW3
{
    public class BootStrapper : MonoBehaviour
    {
        private BallsSpawner _ballsSpawner;

        [Inject]
        private void Construct(BallsSpawner ballsSpawner)
            => _ballsSpawner = ballsSpawner;

        private void Awake()
        {
            _ballsSpawner.SpawnBalls();
        }
    }
}
