using UnityEngine;

namespace TrapInterface
{
    public interface IFingerBoard
    {
        public bool GetSignal();
    }
    
    public interface IBoard
    {
        public bool GetSignal();
    }

    public interface IScaling
    {
        public float GetForce();
    }

    public interface IPlatformJumping
    {
        public float GetForce();
    }

    public interface IEnjector
    {
        public Vector3 GetVelocityShells();

        public Vector3 GetForce();
    }
}
