using System.Collections;

internal interface IControllerRoutine
{
    void StartCoroutine(IHaveCoroutine coroutine);    

    void DeleteCoroutine();    
}

public interface IHaveCoroutine
{
    IEnumerator GetCoroutine();
}