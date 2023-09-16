using PlayerInterface;
using UnityEngine;

namespace TrapInterface
{
    public interface IFingerBoard
    {
        bool GetSignal();
    }
    
    public interface IBoard
    {
        bool GetSignal();
    }

    public interface IScaling
    {
        float GetForce();
    }

    public interface IPlatformJumping
    {
        float GetForce();
    }

    public interface IEnjector
    {
        Vector3 GetVelocityShells();

        Vector3 GetForce();
    }

    public interface IDamageDillerPlayer
    {
        int GiveDamage();
    }

    public interface ITrap
    {
        void InitTarget(IPlayer player);
    }
}
