using UnityEngine;

namespace InterfaceTable
{
    public interface IPlaceToOrder
    {
        public bool CheckPlayer();       
    }

    public interface ITable : IMyPos
    {
        public void TakeTask(IPoolTable controleTable);

        public Color GetColor();

        public void GetOrder(IPlaceToOrder placeToOrder);

        public bool IsCompletedTask();

        public bool TaskSent();

    }

    public interface IMyPos
    {
        public Transform GetPosition();
    }

    public interface IPoolTable : IMyPos
    {
        public bool IsGiveTask();

        public void SetCompletedOrder(ITable table);
    }

    public interface IGiveTask
    {
        public void GetTable(IPlaceTakeOrder kitchen);
    }

    public interface IPlaceTakeOrder : IMyPos
    { 
        public void GetNewOrder(IPoolTable contrleTable);

        public int GetCountOrder();

        public bool ScrolOrder();
    }
}
