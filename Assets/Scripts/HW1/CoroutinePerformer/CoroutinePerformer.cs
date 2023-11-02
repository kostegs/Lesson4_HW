using System.Collections;
using UnityEngine;

namespace Lesson4.HW1
{
    public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
    {
        public Coroutine RunCoroutine(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void EndCoroutine(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }
    }
}
