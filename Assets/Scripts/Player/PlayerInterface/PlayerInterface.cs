using SceneControleInterface;
using InterfaceDrug;
using TrapInterface;
using UnityEngine;

namespace PlayerInterface
{
    public interface IPlayer
    {
        public Transform GetTransform();

        public void SetMoving(IFingerBoard signal);

        public void SetMoving(IBoard signal);

        public float GetSpeedRotation();

        public bool CheckBusy();
    }

    public interface IPlayerMovable
    {
        void Move(IControllerDirectionMovable controllerMovable);
    }

    public interface IControllerDirectionMovable
    {
        Vector3 GetDirectionMove();
        Vector3 GetDirectionRotate();
    }    

    public interface IDeliveryOrder
    {
        public Order GetOrder();
    }    

    public interface ITakeOrder
    {
        public Vector3 GetPositionOrder();

        public Transform GetTransformOrder();

        public void SetOrder(Order order);
    }

    public interface ICanJump
    {
        public void SetForce(IPlatformJumping platform);
    }

    public interface IPlayerPoint
    {
        public Point GetPoint();
    }

    public interface IHealthPlayer
    {
        public void TakeDamage(IDamageDillerPlayer damage);

        public void RestoreHealth(IDrug drag);

        public bool IsDead();

        public int CurrentHealth();

        public int StartHealth();

        public void InitAction(IControleScene controleScene);
    }
}
