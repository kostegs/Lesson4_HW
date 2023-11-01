using System.Collections;
using UnityEngine;

public interface ICoroutinePerformer
{
    Coroutine RunCoroutine(IEnumerator coroutine);
    void EndCoroutine(Coroutine coroutine);
}
