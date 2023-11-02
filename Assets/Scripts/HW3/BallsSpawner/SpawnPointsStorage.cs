using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsStorage : MonoBehaviour
{
    [SerializeField] private List<Transform> _redBallSpawnPoints;
    [SerializeField] private List<Transform> _blueBallSpawnPoints;

    public List<Transform> RedBallSpawnPoints => new List<Transform>(_redBallSpawnPoints);
    public List<Transform> BlueBallSpawnPoints => new List<Transform>(_blueBallSpawnPoints);
}
