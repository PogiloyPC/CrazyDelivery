using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameControleInterface;
using InterfaceButton;
using ViewInterface;
using UnityEngine.Audio;
using PlayerInterface;

public class ControleScene : MonoBehaviour, IControleScene, ISetActivePanel, IContainerTimeLevel
{
    [SerializeField] private TableHandler _tableHandler;

    [SerializeField] private PlayerHealth _playerHealth;

    [SerializeField] private ControleUIScene _controleUIScene;

    [SerializeField] private AudioMixerSnapshot _pause;
    [SerializeField] private AudioMixerSnapshot _unpause;

    private Action<ISetActivePanel> _onGameOver;
    private Action<ISetActivePanel> _onWinGame;    

    [SerializeField] private float _startTimeLevel;
    private float _currentTimeLevel;

    private float _timePause = 0f;
    private float _timeUnpause = 1f;

    private void Start()
    {
        _controleUIScene.InitMenuPanel(this);
        
        _playerHealth.InitAction(this);

        _onGameOver += _controleUIScene.GetPanelGameOver(this).ChangeActivePanel;
        _onWinGame += _controleUIScene.GetPanelWinGame(this).ChangeActivePanel;

        _currentTimeLevel = _startTimeLevel;
    }

    public void Update()
    {
        _tableHandler.ReloadNavigator();

        if (_tableHandler.AllOrdersGiven())
            WinGame();
        else if (_currentTimeLevel <= 0f)
            GameOver();
        else
            _currentTimeLevel -= Time.deltaTime;

        _controleUIScene.TakeTimeLevel(this);
    }

    public bool GetActive() => true;

    public IViewHealthPlayer GetViewHealthPlayer() => _controleUIScene.ViewHealthPlayer;

    public void RestartLevel(IHealthPlayer player)
    {
        if (player.IsDead())
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void WinGame() => _onWinGame.Invoke(this);

    private void GameOver() => _onGameOver.Invoke(this);

    public void PauseGame(IPanel menu)
    {
        if (menu.GetPause())
        {
            _pause.TransitionTo(0.3f);

            Time.timeScale = _timePause;
        }
        else
        {
            _unpause.TransitionTo(0.3f);

            Time.timeScale = _timeUnpause;
        }
    }

    public float CurrentTimeLevel() => _currentTimeLevel;

    public float StartTimeLevel() => _startTimeLevel;
}
