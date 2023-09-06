using System.Collections.Generic;
using System.Collections;
using InterfaceConveyor;
using InterfaceTable;
using UnityEngine;

public class Conveyor : MonoBehaviour, IConveyor
{
    private Queue<Vector3> _poolPosition = new Queue<Vector3>();

    [SerializeField] private float _distance;
    [SerializeField] private float _speedScrol;
    [SerializeField] private int _countOrder;    

    public void SetPosition(IPlaceTakeOrder kitchen)
    {
        for (int i = 0; i < kitchen.GetCountOrder(); i++)
        {
            Vector3 position = transform.position + (transform.forward * _distance * i);

            _poolPosition.Enqueue(position);
        }
    }

    public Vector3 GetPosition() => _poolPosition.Dequeue();

    private void OnDrawGizmos()
    {
        for (int i = 0; i < _countOrder; i++)
        {
            if (i % 2 == 0)
                Gizmos.color = Color.blue;
            if (i % 2 != 0)
                Gizmos.color = Color.red;

            Gizmos.DrawWireCube(transform.position + (transform.forward * _distance * i), new Vector3(1f, 0.5f, 1f));
        }
    }

    public void ReloadPositionOrder(IPlaceTakeOrder kitchen)
    {       
        StartCoroutine(ScrolOrder(kitchen.ScrolOrder()));
    }

    private IEnumerator ScrolOrder(bool action)
    {
        yield return new WaitUntil(() => action);

        Vector3 position = transform.localPosition - (transform.forward * _distance);

        float t = 0f;

        while (true)
        {
            t += _speedScrol * Time.deltaTime;

            transform.position = Vector3.Lerp(transform.localPosition, position, t);

            if (t >= 1f)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
