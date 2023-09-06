using System.Collections;
using UnityEngine;
using System;
using TrapInterface;
using PlayerInterface;

public class Shells : Trap, ISetActive, IShell<Shells>
{
    private Action<Shells> _onReturn;

    [SerializeField] private Rigidbody _rb;

    [SerializeField] private float _timeDisable;

    private void OnEnable()
    {
        StartCoroutine(OnDisableObject());
    }

    private void OnDisable()
    {
        _onReturn?.Invoke(this);
    }

    public void SetPosition(Point injector) => transform.position = injector.GetPosition();

    public void ReloadVelocity(IEnjector enjector) => _rb.velocity = enjector.GetVelocityShells();

    public void SetForce(IEnjector enjector) => _rb.AddForce(enjector.GetForce(), ForceMode.Impulse);

    public void ChangeActive(bool active) => gameObject.SetActive(active);

    public void SetPoolObject(IPoolObject<Shells> poolObject) => _onReturn += poolObject.ReturnObject;    

    private IEnumerator OnDisableObject()
    {
        yield return new WaitForSeconds(_timeDisable);

        gameObject.SetActive(false);
    }

    public void OnCollisionEnter(Collision other)
    {
        IHealthPlayer player = other.collider.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(this);

            ChangeActive(false);
        }
    }

}
