using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRoutine : MonoBehaviour, IControllerRoutine
{
    private IEnumerator _coroutine;

    public void StartCoroutine(IHaveCoroutine coroutine)
    {
        if (_coroutine == null)
        {
            _coroutine = coroutine.GetCoroutine();
        }
    }

    public void DeleteCoroutine()
    {
        _coroutine = null;
    }
}
