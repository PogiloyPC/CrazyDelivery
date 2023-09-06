using System.Collections.Generic;
using UnityEngine;
using System;
using InterfaceTable;

public class PoolTable<T> : IPoolTable, IGiveTask where T : ITable
{
    private Queue<T> _tables = new Queue<T>();

    private Transform _lastPosTable;

    private Action<IPoolTable> _onFinishTask;

    public int CountTables => _tables.Count;

    public void Start(IPlaceTakeOrder kitchen)
    {
        _onFinishTask += kitchen.GetNewOrder;
    }

    public void AddTable(T t)
    {
        _tables.Enqueue(t);
    }

    public void GetTable(IPlaceTakeOrder kitchen)
    {
        if (_tables.Count > 0)
        {
            _lastPosTable = _tables.Peek().GetPosition();

            _tables.Dequeue().TakeTask(this);
        }
    }

    public bool IsGiveTask() => true;

    public void SetCompletedOrder(ITable table)
    {
        if (table.IsCompletedTask())
            _onFinishTask.Invoke(this);
    }

    public Transform GetPosition() =>  _lastPosTable;
}
