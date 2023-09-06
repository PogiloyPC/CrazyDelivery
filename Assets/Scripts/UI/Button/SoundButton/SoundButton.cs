using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundButton : DinamicButton
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    [SerializeField] private Sprite _onValue;
    [SerializeField] private Sprite _offValue;

    [SerializeField] private Image _imageButton;

    private bool _isActive;

    protected override void StartButton()
    {
        int i = PlayerPrefs.GetInt("MasterEnabled");
        
        if (i == 1)
            _isActive = true;
        else if (i == 0)
            _isActive = false;
        
        ChangeVoluemGame();      
    }

    public void ChangeVoluemGame()
    {
        _isActive = !_isActive;

        if (_isActive)                    
            _audioMixer.audioMixer.SetFloat("MasterVoluem", 0f);        
        else                   
            _audioMixer.audioMixer.SetFloat("MasterVoluem", -80f);        

        ChangeImageButton();

        PlayerPrefs.SetInt("MasterEnabled", _isActive ? 0 : 1);
    }

    private void ChangeImageButton()
    {
        if (_isActive)
            _imageButton.sprite = _onValue;
        else
            _imageButton.sprite = _offValue;
    }    
}
