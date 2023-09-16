using SceneControleInterface;
using UIinterface;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Panel : MonoBehaviour, IPanel
{
    private bool _isActive;

    private Action<IPanel> _onPause;

    public void Init(IControleScene controleScene)
    {
        _onPause += controleScene.PauseGame;
        _onPause?.Invoke(this);
    }

    private void OnEnable()
    {
        ChangePause(true);
    }
    
    private void OnDisable()
    {
        ChangePause(false);
    }

    public void ChangeActivePanel(ISetActivePanel active) => gameObject.SetActive(active.GetActive());

    public bool GetPause() => _isActive;

    private void ChangePause(bool active)
    {
        _isActive = active;

        _onPause?.Invoke(this);
    }
}
