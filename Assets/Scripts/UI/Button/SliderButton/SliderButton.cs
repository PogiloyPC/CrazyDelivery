using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InterfaceButton;

public class SliderButton : StaticButton, ISliderButton
{
    [SerializeField] private List<DinamicButton> _button;

    [SerializeField] private Sprite _onSlider;
    [SerializeField] private Sprite _offSlider;

    [SerializeField] private Image _imageButton;

    private bool _isActive;

    public bool GetSignal() => _isActive;

    public void ActivatedButton()
    {
        _isActive = !_isActive;        

        foreach (DinamicButton button in _button)
            button.TakeSignal(this);        

        ChangeImage();
    }

    private void ChangeImage()
    {
        if (_isActive)
            _imageButton.sprite = _onSlider;
        else
            _imageButton.sprite = _offSlider;
    }
}
