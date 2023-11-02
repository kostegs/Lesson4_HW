using UnityEngine;

namespace Lesson4.HW1
{
    public interface IEnemyTarget : IDamageable
    {
        Vector3 Position { get; }
    }
}
