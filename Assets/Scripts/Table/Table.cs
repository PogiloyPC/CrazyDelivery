using UnityEngine;
using InterfaceTable;
using System;

public class Table : MonoBehaviour, ITable
{
    [SerializeField] private PlaceToOrder _placeToOrder;    

    private Action<ITable> _onReturnCompetedTask;

    public void TakeTask(IPoolTable controleTable)
    {
        if (controleTable.IsGiveTask())
        {
            _placeToOrder.ChangeColor(this);           

            _onReturnCompetedTask += controleTable.SetCompletedOrder;
        }
    }

    public void GetOrder(IPlaceToOrder placeToOrder)
    {
        if (placeToOrder.CheckPlayer())
            _onReturnCompetedTask.Invoke(this);
    }

    public Color GetColor() => Color.green;

    public bool IsCompletedTask() => true;

    public bool TaskSent() => true;

    public Transform GetPosition() => _placeToOrder.GetTransform();
}
