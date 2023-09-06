using OrderInterface;
using PlayerInterface;
using UnityEngine;
using InterfaceConveyor;

public class Order : MonoBehaviour, IOrder
{
    public void SetPosition(ITakeOrder obj) => transform.position = obj.GetPositionOrder();

    public void SetParent(ITakeOrder obj) => transform.parent = obj.GetTransformOrder();

    public void InitStart(IConveyor conveyor)
    {
        Vector3 position = conveyor.GetPosition();

        transform.position = new Vector3(position.x, transform.position.y, position.z);
    }
}
