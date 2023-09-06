using InterfaceButton;
using PlayerInterface;
using UnityEngine;
using ViewInterface;

namespace GameControleInterface
{
    public interface IControleScene : IContainerViewHealthPlayer
    {
        public void RestartLevel(IHealthPlayer player);

        public void PauseGame(IPanel menu);
    }

    public interface IContainerViewHealthPlayer
    {
        public IViewHealthPlayer GetViewHealthPlayer();
    }

    public interface IContainerTimeLevel
    {
        public float CurrentTimeLevel();

        public float StartTimeLevel();
    }
}
