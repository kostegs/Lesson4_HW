using System.Collections;
using UnityEngine;

namespace Lesson4.HW1
{
    public interface ICoroutinePerformer
    {
        Coroutine RunCoroutine(IEnumerator coroutine);
        void EndCoroutine(Coroutine coroutine);
    }
}
