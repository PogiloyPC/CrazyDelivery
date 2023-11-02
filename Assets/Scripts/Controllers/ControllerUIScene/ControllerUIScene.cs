using SceneControleInterface;
using UIinterface;
using UnityEngine;
using ViewInterface;

public class ControllerUIScene : MonoBehaviour
{
    [SerializeField] private ViewTimeLevel _viewTimeLevel;

    [SerializeField] private ViewHealthPlayer _viewHealthPlayer;

    [SerializeField] private PanelBackHome _panelBackHome;
    [SerializeField] private PanelWinGame _panelWinGame;
    [SerializeField] private PanelGameOver _panelGameOver;
    [SerializeField] private PanelSound _panelSound;

    private bool _isTakePanel_1;
    private bool _isTakePanel_2;

    public IViewHealthPlayer ViewHealthPlayer => _viewHealthPlayer;

    public void TakeTimeLevel(IContainerTimeLevel timeLevel) => _viewTimeLevel.DisplayTime(timeLevel);

    public void InitMenuPanel(IControleScene controleScene)
    {
        _panelBackHome.Init(controleScene);
        _panelWinGame.Init(controleScene);
        _panelGameOver.Init(controleScene);        
        _panelSound.Init(controleScene);
        _panelSound.InitValuem();
    }  

    public PanelGameOver GetPanelGameOver(ISetActivePanel setActive)
    {
        if (!_isTakePanel_2)
        {
            _isTakePanel_2 = setActive.GetActive();

            return _panelGameOver;
        }
        else
        {
            return null;
        }
    }
    
    public PanelWinGame GetPanelWinGame(ISetActivePanel setActive)
    {
        if (!_isTakePanel_1)
        {
            _isTakePanel_1 = setActive.GetActive();

            return _panelWinGame;
        }
        else
        {
            return null;
        }
    }

}
