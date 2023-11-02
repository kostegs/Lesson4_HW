using System.Collections.Generic;
using UnityEngine;

namespace Lesson4.HW1
{
    public class SpawnPoints : MonoBehaviour
    {
        [SerializeField] private List<Transform> _points;

        public List<Transform> Points => new List<Transform>(_points);
    }
}