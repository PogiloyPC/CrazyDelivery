using UnityEngine;

public class SystemMainMenu : MonoBehaviour
{
    [SerializeField] private PanelSound _panelSound;

    private void Start()
    {
        _panelSound.InitValuem();
    }
}
