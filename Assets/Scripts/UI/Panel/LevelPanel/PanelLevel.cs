using UIinterface;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelLevel : MonoBehaviour
{
    [SerializeField] private Image _renderer;

    private IEnumerator _pickPanel;
    private IEnumerator _unpickPanel;

    private Vector3 _scale;
    private Vector3 _transformScale = new Vector3(1f, 1f, 1f);

    [SerializeField] private float _speed;

    private void Start()
    {
        _scale = transform.localScale;

    }

    public void ActivatePanel(IControleLevelPanel controleLevel)
    {
        _pickPanel = PickPanel();

        StartCoroutine(_pickPanel);
        if (_unpickPanel != null)
            StopCoroutine(_unpickPanel);
    }

    public void DeactivatePanel(IControleLevelPanel controleLevel)
    {
        _unpickPanel = CancelPickPanel();

        StartCoroutine(_unpickPanel);
        if (_pickPanel != null)
            StopCoroutine(_pickPanel);
    }

    private IEnumerator PickPanel()
    {
        float t = 0f;

        while (true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _transformScale, t);

            _renderer.color = Color.Lerp(_renderer.color, Color.white, t);

            t += _speed * Time.deltaTime;

            if (t >= 1)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator CancelPickPanel()
    {
        float t = 0f;

        while (true)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _scale, t);

            _renderer.color = Color.Lerp(_renderer.color, Color.gray, t);

            t += _speed * Time.deltaTime;

            if (t >= 1)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
