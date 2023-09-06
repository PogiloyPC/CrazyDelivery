using InterfaceTable;
using UnityEngine;
using System;
using PlayerInterface;

public class PlaceToOrder : MonoBehaviour, IPlaceToOrder, ITakeOrder
{
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Material _materialDefault;
    [SerializeField] private Material _materialTask;

    [SerializeField] private Point _positionForOrder;

    private Order _order;

    private Action<IPlaceToOrder> _onTakeOrder;

    private bool _havePlayer;
    private bool _orderIsAccepted;

    public void ChangeColor(ITable table)
    {
        _onTakeOrder += table.GetOrder;

        _orderIsAccepted = table.TaskSent();

        _renderer.material = _materialTask;
    }

    public bool CheckPlayer() => _havePlayer;

    public Transform GetTransform() => transform;

    public Transform GetTransformOrder() => _positionForOrder.GetTransform();

    public Vector3 GetPositionOrder() => _positionForOrder.GetPosition();

    public void SetOrder(Order order)
    {
        _order = order;
        _order.SetParent(this);
        _order.SetPosition(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        IDeliveryOrder player = other.gameObject.GetComponent<IDeliveryOrder>();

        if (player != null && _orderIsAccepted)
        {
            SetOrder(player.GetOrder());
            
            _renderer.material = _materialDefault;

            _havePlayer = true;
            _orderIsAccepted = false;

            _onTakeOrder.Invoke(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();

        if (player != null && _orderIsAccepted)
            _havePlayer = false;
    }
}
