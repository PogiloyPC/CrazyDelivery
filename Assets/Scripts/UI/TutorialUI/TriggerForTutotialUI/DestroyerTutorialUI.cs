using PlayerInterface;
using UnityEngine;

public class DestroyerTutorialUI : MonoBehaviour
{
    private IDestroyableTutorialUI _tutorialUI;

    public void InitTutorialUI(IDestroyableTutorialUI tutorialUI)
    {
        _tutorialUI = tutorialUI;
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();

        if (player != null)
        {
            _tutorialUI.DestroyUI();            

            Destroy(this);
        }
    }
}
