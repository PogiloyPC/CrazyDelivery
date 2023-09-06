using GameControleInterface;
using InterfaceButton;
using UnityEngine;

public class BackHomeButton : DinamicButton, ISetActivePanel
{
    [SerializeField] private PanelBackHome _panel;

    private bool _isActive;

    private void Awake()
    {        
        _panel.ChangeActivePanel(this);        
    }

    public void DisplayMenuHome()
    {
        _isActive = !_isActive;

        _panel.ChangeActivePanel(this);
    }

    public bool GetActive() => _isActive;
}
