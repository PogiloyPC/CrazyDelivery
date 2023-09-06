using PlayerInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proppeler : Trap
{
    [SerializeField] private Vector3 _rotateZXY;

    [SerializeField] private float _speedRotation;
    [SerializeField] private float _timeChangeDirection;
    private float _directFigurs;

    [SerializeField] private bool _constantRotation;
    [SerializeField] private bool _rotateRight = true;

    private void Start()
    {
        if (_constantRotation)
        {
            StartCoroutine(Rotate());
        }
        else
        {
            StartCoroutine(RotateSlow());
            StartCoroutine(SetPositionForRotation());
        }

        if (_rotateRight)
            _directFigurs = 1f;
        else
            _directFigurs = -1f;
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.rotation *= Quaternion.Euler(_rotateZXY * _directFigurs);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator RotateSlow()
    {
        while (true)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_rotateZXY), _speedRotation * Time.deltaTime);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private IEnumerator SetPositionForRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeChangeDirection);
            _rotateZXY = new Vector3(1f * _directFigurs, 0f, 0f);
            yield return new WaitForSeconds(_timeChangeDirection);
            _rotateZXY = new Vector3(0f, 0f, -1f);
            yield return new WaitForSeconds(_timeChangeDirection);
            _rotateZXY = new Vector3(-1f * _directFigurs, 0f, 0f);
            yield return new WaitForSeconds(_timeChangeDirection);
            _rotateZXY = new Vector3(0f, 0f, 1f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        IHealthPlayer player = other.collider.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
            player.TakeDamage(this);
    }
}
