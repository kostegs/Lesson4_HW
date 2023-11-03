using System;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson4.HW3
{
    public class BallsSpawner
    {
        public event Action<Ball> BallSpawned;

        private SpawnPointsStorage _spawnPointsStorage;
        private BallFactory _factory;

        public BallsSpawner(SpawnPointsStorage spawnPointsStorage, BallFactory factory)
        {
            _spawnPointsStorage = spawnPointsStorage;
            _factory = factory;            
        }

        public void SpawnBalls()
        {
            List<Transform> redBallsSpawnPoints = _spawnPointsStorage.RedBallSpawnPoints;
            List<Transform> blueBallsSpawnPoints = _spawnPointsStorage.BlueBallSpawnPoints;

            SpawnColouredBalls(BallColors.Blue, blueBallsSpawnPoints);
            SpawnColouredBalls(BallColors.Red, redBallsSpawnPoints);
        }

        private void SpawnColouredBalls(BallColors colour, List<Transform> spawnPoints)
        {
            foreach (var spawnPoint in spawnPoints)
            {
                Ball ball = _factory.GetBall(colour);
                ball.transform.position = spawnPoint.position;
                ball.transform.rotation = Quaternion.identity;
                ball.Initialize(colour);
                BallSpawned?.Invoke(ball);
            }            
        }
    }
}
