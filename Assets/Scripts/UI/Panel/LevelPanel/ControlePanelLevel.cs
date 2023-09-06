using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using InterfaceButton;

public class ControlePanelLevel : MonoBehaviour, IControleLevelPanel
{
    [SerializeField] private List<PanelLevel> _poolLevels;

    [SerializeField] private Point _menuLevels;
    [SerializeField] private Point _panelLevels;
    [SerializeField] private Point _sliderLevels;

    [SerializeField] private float _scaleLerp;
    [SerializeField] private float _speedSwap;
    private float _countPanels => _poolLevels.Count - 1;

    public void GetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    private void OnEnable()
    {
        ChakePanel();

        StartCoroutine(SwapPanel());
    }

    private void OnDisable() => StopCoroutine(SwapPanel());

    private IEnumerator SwapPanel()
    {
        while (true)
        {
            Vector3 position = Vector3.Lerp(_panelLevels.GetPosition(), _menuLevels.GetPosition(), _scaleLerp / _countPanels);

            Vector3 lerp = Vector3.Lerp(_sliderLevels.GetPosition(), position, _speedSwap * Time.deltaTime);
            
            _sliderLevels.SetPosition(lerp);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void Swap(float value)
    {
        _scaleLerp = Mathf.Clamp(_scaleLerp + value, 0f, _countPanels);

        ChakePanel();
    }

    private void ChakePanel()
    {
        for (int i = 0; i < _poolLevels.Count; i++)
        {
            if (i == _scaleLerp)
                _poolLevels[i].ActivatePanel(this);
            else
                _poolLevels[i].DeactivatePanel(this);
        }
    }

}
