using UnityEngine;

public class ShopButton : DinamicButton
{
    [SerializeField] private ShopPanel _shopPanel;

    private bool _isActive;

    public void ChangeActivePanel()
    {
        _isActive = !_isActive;        

        _shopPanel.ChangeActive(_isActive);
    }
}
