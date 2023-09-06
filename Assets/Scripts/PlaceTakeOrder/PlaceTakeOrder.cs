using UnityEngine;
using System;
using System.Collections.Generic;
using InterfaceTable;
using PlayerInterface;

public class PlaceTakeOrder : MonoBehaviour, IMyPos, IPlaceTakeOrder
{
    [SerializeField] private Renderer _renderer;

    [SerializeField] private Conveyor _conveyor;

    [SerializeField] private Order[] _orders;

    private Queue<Order> _poolOrders  = new Queue<Order>();

    [SerializeField] private Material _red;
    [SerializeField] private Material _default;

    private Action<IPlaceTakeOrder> _onTakeOrder;

    public bool FinishTask { get; private set; }

    public int GetCountOrder() => _orders.Length;

    private void Start()
    {
        _conveyor.SetPosition(this);

        for (int i = 0; i < _orders.Length; i++)
        {
            _orders[i].InitStart(_conveyor);

            _poolOrders.Enqueue(_orders[i]);
        }
    }

    public void StartKitchen()
    {       
        _renderer.material = _red;

        FinishTask = true;        
    }

    public void GetNewOrder(IPoolTable controleTable)
    {
        StartKitchen();
    }

    public void InitAction(IGiveTask poolTable) => _onTakeOrder += poolTable.GetTable;

    public Transform GetPosition() => transform;

    public bool NotBusy() => FinishTask;
    public bool ScrolOrder() => true;

    private void OnTriggerEnter(Collider other)
    {
        ITakeOrder player = other.gameObject.GetComponent<ITakeOrder>();

        if (player != null && FinishTask)
        {            
            Order order = _poolOrders.Dequeue();
            order.SetParent(player);
            order.SetPosition(player);

            player.SetOrder(order);

            _conveyor.ReloadPositionOrder(this);

            _renderer.material = _default;

            FinishTask = false;

            _onTakeOrder.Invoke(this);
        }
    }
}
