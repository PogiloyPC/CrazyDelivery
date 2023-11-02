using PlayerInterface;
using UnityEngine;

public class SwitchTutorialUI : MonoBehaviour
{
    private IEnableTutorialUI _tutorialUI;

    public void InitTutorialUI(IEnableTutorialUI tutorialUI)
    {
        _tutorialUI = tutorialUI;
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();

        if (player != null)
        {
            _tutorialUI.EnableUI();

            Destroy(this);
        }
    }
}
