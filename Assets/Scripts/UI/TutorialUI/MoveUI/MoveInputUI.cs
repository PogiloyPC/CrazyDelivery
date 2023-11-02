using System.Collections;
using UnityEngine;

public class MoveInputUI : TutorialUI
{    
    private InputPlayer _input;

    private void Start()
    {
        _input = new InputPlayer();

        StartCoroutine(DestroyUI());
    }

    private IEnumerator DestroyUI()
    {
        yield return new WaitUntil(() => _input.GetKeyW() || _input.GetKeyS() || _input.GetKeyD() || _input.GetKeyA());

        Destroy(gameObject, DestroyTime);
    }
}
