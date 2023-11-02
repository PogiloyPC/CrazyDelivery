using UIinterface;
using PlayerInterface;
using UnityEngine;
using ViewInterface;

namespace SceneControleInterface
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
    
    public interface IContainePlayer
    {
        public IPlayer GetPlayer();
    }

    public interface IContainerTimeLevel
    {
        public float CurrentTimeLevel();

        public float StartTimeLevel();
    }


    public interface IContainerStartPosition
    {
        public Vector3 GetStartPosition();
    }    
}
