using System.Collections.Generic;
using UnityEngine;

public class TableHandler : MonoBehaviour
{
    [SerializeField] private List<Table> _tables;

    private PoolTable<Table> _poolTables = new PoolTable<Table>();

    [SerializeField] private ArrowJPS _navigator;

    [SerializeField] private PlaceTakeOrder _kitchen;

    [SerializeField] private bool _randomSetTable = true;

    private void Start()
    {
        int numberTable = 0;

        for (int i = 0; i < _kitchen.GetCountOrder(); i++)
        {
            numberTable = Random.Range(0, _tables.Count);

            if (_randomSetTable)
            {
                _poolTables.AddTable(_tables[numberTable]);
                _tables.RemoveAt(numberTable);
            }
            else
            {
                _poolTables.AddTable(_tables[i]);                
            }            
        }

        _poolTables.Start(_kitchen);

        _kitchen.StartKitchen();
        _kitchen.InitAction(_poolTables);
    }

    public void ReloadNavigator()
    {
        if (_kitchen.NotBusy())
            _navigator.LookRotation(_kitchen);
        else
            _navigator.LookRotation(_poolTables);
    }

    public bool AllOrdersGiven() => _kitchen.FinishTask && _poolTables.CountTables <= 0;
}
