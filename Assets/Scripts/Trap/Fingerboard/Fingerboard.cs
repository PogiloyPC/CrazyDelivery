using PlayerInterface;
using System.Collections;
using System.Collections.Generic;
using TrapInterface;
using UnityEngine;

public class Fingerboard : MonoBehaviour, IFingerBoard
{
    [SerializeField] private Point _colliderBody;

    [SerializeField] private Rigidbody _rb;

    private InputPlayer _input;

    private IPlayer _player;

    private Vector3 _direction;

    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeDestroy;
    private float _x;
    private float _z;

    private bool _isMoving;

    private void Start()
    {
        _input = new InputPlayer();

        _direction = new Vector3(0f, 0f, 1f);
    }

    private void Update()
    {
        if (_isMoving)
        {
            Quaternion rot = Quaternion.Lerp(_colliderBody.GetRotation(), Quaternion.LookRotation(_direction),
                _player.GetSpeedRotation() * Time.deltaTime);

            _colliderBody.SetRotation(rot); 
        }
    }

    private void FixedUpdate()
    {
        if (_input.GetKeyW() && _input.GetKeyD())
        {
            _z = _speed;
            _x = _speed;
        }
        else if (_input.GetKeyW() && _input.GetKeyA())
        {
            _z = _speed;
            _x = -_speed;
        }
        else if (_input.GetKeyS() && _input.GetKeyD())
        {
            _z = -_speed;
            _x = _speed;
        }
        else if (_input.GetKeyS() && _input.GetKeyA())
        {
            _z = -_speed;
            _x = -_speed;
        }
        else if (_input.GetKeyW())
        {
            _z = _speed;
            _x = 0f;
        }
        else if (_input.GetKeyS())
        {
            _x = 0f;
            _z = -_speed;
        }
        else if (_input.GetKeyD())
        {
            _x = _speed;
            _z = 0f;
        }
        else if (_input.GetKeyA())
        {
            _x = -_speed;
            _z = 0f;
        }

        _direction = new Vector3(_x, 0f, _z);

        if (_isMoving)
        {
            _rb.velocity = _direction;

            _player.GetTransform().position = transform.position;
        }
    }

    private void OnDestroy()
    {
        SetParentPlayer(false);
    }

    public bool GetSignal() => _isMoving;

    private void SetParentPlayer(bool value, Transform transform = null)
    {
        _isMoving = value;

        _player.GetTransform().parent = transform;
        _player.SetMoving(this);
    }

    private void OnCollisionEnter(Collision other)
    {
        IPlayer player = other.collider.gameObject.GetComponent<IPlayer>();

        if (player != null && !player.CheckBusy())
        {
            _player = player;

            SetParentPlayer(true, transform);

            Destroy(gameObject, _timeDestroy);
        }
    }    
}
