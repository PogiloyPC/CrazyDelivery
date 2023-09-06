using InterfaceButton;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class DinamicButton : ButtonMenu
{
    [SerializeField] private Transform _startPos;    

    [SerializeField] private Image _image;

    [SerializeField] private float _speed;

    private Vector3 _finishPos;

    private void Start()
    {
        _finishPos = transform.position;

        transform.position = _startPos.position;

        _image.enabled = false;

        StartButton();
    }

    protected virtual void StartButton()
    {

    }

    public void TakeSignal(ISliderButton slider)
    {
        if (slider.GetSignal())
        {
            StartCoroutine(ActiveButton());            
        }
        else
        {
            DeactiveButton();
            StopCoroutine(ActiveButton());
        }
    }

    private IEnumerator ActiveButton()
    {
        _image.enabled = true;
        
        transform.position = _startPos.position;

        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, _finishPos, _speed * Time.deltaTime);
            
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void DeactiveButton()
    {
        _image.enabled = false;
    }    
}
