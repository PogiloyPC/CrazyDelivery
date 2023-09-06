using PlayerInterface;
using System.Collections;
using UnityEngine;

public class BurgerAttack : Trap
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Point _body;

    [SerializeField] private Point _player;

    [SerializeField] private Vector3 _rotateZXY;

    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotationY;
    [SerializeField] private float _timeSleepOfMoving;

    private bool _isSleeping;

    private void Update()
    {
        Quaternion rot = _body.GetRotation();
        rot *= Quaternion.Euler(_rotateZXY);
        _body.SetRotation(rot);
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * _speed;

        Vector3 direct = _player.GetPosition() - transform.position;
        Vector3 directRotate = new Vector3(direct.x, 0f, direct.z);

        _rb.rotation = Quaternion.Lerp(_rb.rotation, Quaternion.LookRotation(directRotate), _speedRotationY * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        IHealthPlayer player = other.collider.gameObject.GetComponent<PlayerHealth>();

        if (player != null && !_isSleeping)
        {
            _isSleeping = true;

            player.TakeDamage(this);

            StartCoroutine(StopMoving());
        }
    }

    private IEnumerator StopMoving()
    {
        Vector3 rotate = _rotateZXY;

        float speed = _speed;

        _rotateZXY = new Vector3();

        _speed -= _speed;

        yield return new WaitForSeconds(_timeSleepOfMoving);

        _speed = speed;

        _rotateZXY = rotate;

        _isSleeping = false;
    }
}
