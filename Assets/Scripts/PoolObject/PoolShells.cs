using System.Collections.Generic;
using UnityEngine;

public class PoolShells<T> : IPoolObject<T> where T : MonoBehaviour, ISetActive, IShell<T>
{
    private Queue<T> _pool = new Queue<T>();

    private Point _point;

    public PoolShells(int countObject, T t, Point point)
    {
        _point = point;

        for (int i = 0; i < countObject; i++)
        {
            T obj = GameObject.Instantiate(t);

            obj.SetPoolObject(this);
            obj.ChangeActive(false);

            _pool.Enqueue(obj);
        }        
    }

    public T GetT()
    {
        T t = _pool.Dequeue();
        t.ChangeActive(true);
        t.SetPosition(_point);

        return t;
    }

    public void ReturnObject(T t) => _pool.Enqueue(t);
}

public interface ISetActive
{
    public void ChangeActive(bool active);
}

public interface IShell<T>
{
    public void SetPosition(Point point);

    public void SetPoolObject(IPoolObject<T> poolObject);
}

public interface IPoolObject<T>
{
    public void ReturnObject(T t);
}