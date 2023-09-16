using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UIinterface;
using System;
using SceneControleInterface;

public class PanelSound : Panel
{
    [SerializeField] private AudioMixerGroup _audioMixer;

    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectSlider;
    [SerializeField] private Slider _UISlider;    

    public void InitValuem()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("MusicVoluem");
        _effectSlider.value = PlayerPrefs.GetFloat("EffectVoluem");
        _UISlider.value = PlayerPrefs.GetFloat("UIVoluem");        
    }

    public void ChangeMusicValuem(float value)
    {
        _audioMixer.audioMixer.SetFloat("MusicVoluem", Mathf.Lerp(-80f, 20f, value));

        PlayerPrefs.SetFloat("MusicVoluem", value);
    }

    public void ChangeEffectValuem(float value)
    {
        _audioMixer.audioMixer.SetFloat("EffectVoluem", Mathf.Lerp(-80f, 20f, value));

        PlayerPrefs.SetFloat("EffectVoluem", value);
    }

    public void ChangeUIValuem(float value)
    {
        _audioMixer.audioMixer.SetFloat("UIVoluem", Mathf.Lerp(-80f, 20f, value));

        PlayerPrefs.SetFloat("UIVoluem", value);
    }
}
