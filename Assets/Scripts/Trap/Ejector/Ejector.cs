using System.Collections;
using TrapInterface;
using UnityEngine;

public class Ejector : MonoBehaviour, IEnjector
{
    [SerializeField] private Point _posShot;

    [SerializeField] private Shells _shell;

    private PoolShells<Shells> _poolObjects;
    
    [SerializeField] private float _timeShot;
    [SerializeField] private float _force;

    [SerializeField] private int _countObject;

    public Vector3 GetVelocityShells() => new Vector3(0f, 0f, 0f);
    public Vector3 GetForce() => transform.forward * _force;

    private void Start()
    {
        _poolObjects = new PoolShells<Shells>(_countObject, _shell, _posShot);

        StartCoroutine(Shot());
    }

    private IEnumerator Shot()
    {
        while (true)
        {
            Shells shell = _poolObjects.GetT();
                                   
            shell.ReloadVelocity(this);
            shell.SetForce(this);

            yield return new WaitForSeconds(_timeShot);
        }
    }

}
