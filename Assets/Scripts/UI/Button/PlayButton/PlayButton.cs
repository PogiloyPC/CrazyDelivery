using UnityEngine;

public class PlayButton : StaticButton
{
    private bool _isActive = true;

    [SerializeField] private ControlePanelLevel _controlePanel;

    public void SetActive()
    {        
        _controlePanel.GetActive(_isActive);
    }
}
