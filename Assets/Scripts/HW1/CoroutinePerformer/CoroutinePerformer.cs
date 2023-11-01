using System.Collections;
using UnityEngine;

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
