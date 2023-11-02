using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lesson4.HW1
{
    public class EnemySpawner : IPause
    {
        private float _spawnCooldown;
        private List<Transform> _spawnPoints;

        private EnemyFactory _enemyFactory;
        private PauseHandler _pauseHandler;

        private Coroutine _spawn;
        private ICoroutinePerformer _coroutinePerformer;

        private bool _isPaused;

        public EnemySpawner(EnemyFactory enemyFactory, PauseHandler pauseHandler, ICoroutinePerformer coroutinePerformer, EnemySpawnerConfig spawnerConfig, SpawnPoints spawnPoints)
        {
            _enemyFactory = enemyFactory;
            _pauseHandler = pauseHandler;
            _pauseHandler.Add(this);
            _coroutinePerformer = coroutinePerformer;
            _spawnCooldown = spawnerConfig.SpawnCooldown;
            _spawnPoints = spawnPoints.Points;

            StartWork();
        }

        public void StartWork()
        {
            StopWork();

            _spawn = _coroutinePerformer.RunCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                _coroutinePerformer.EndCoroutine(_spawn);
        }

        private IEnumerator Spawn()
        {
            float time = 0;

            while (true)
            {
                while (time < _spawnCooldown)
                {
                    if (_isPaused == false)
                        time += Time.deltaTime;

                    yield return null;
                }

                Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length)); // получаем рэндомный тип врага
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                _pauseHandler.Add(enemy);
                time = 0;
            }
        }

        public void SetPause(bool isPaused) => _isPaused = isPaused;
    }
}