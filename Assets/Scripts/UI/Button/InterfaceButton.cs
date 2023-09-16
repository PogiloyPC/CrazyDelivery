

using PlayerInterface;

namespace UIinterface
{
    public interface ISliderButton
    {
        public bool GetSignal();
    }

    public interface IPanel
    {
        public bool GetPause();
    }
    
    public interface IControleLevelPanel
    {
        
    }

    public interface IPlayerCard
    {
        public PlayerBody GetPlayerBody();
    }

    public interface ISetActivePanel
    {
        public bool GetActive();
    }
}
