using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonMenu : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private AudioClip _audioPickButton;
    [SerializeField] private AudioClip _audioClick;

    public void OnPointerEnter(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioPickButton);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_audioClick);
    }
}
