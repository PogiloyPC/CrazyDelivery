using UIinterface;
using UnityEngine;

public class SettingButton : DinamicButton, ISetActivePanel
{    
    [SerializeField] private PanelSound _panelSound;

    private bool _isActive;

    private void Awake()
    {
        _panelSound.ChangeActivePanel(this);
    }   

    public void ChangeActivePanel()
    {
        _isActive = !_isActive;

        _panelSound.ChangeActivePanel(this);        
    }

    public bool GetActive() => _isActive;
}
