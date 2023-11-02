using InterfaceEffects;
using PlayerInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayerMovable : IControllerDirectionMovable
{
    private Rigidbody _rb;

    private Point _positionBody;

    private InputPlayer _input;

    private IPlayerMovable _playerMovable;

    private Vector3 _directionMove;
    private Vector3 _directionRotate;

    private float _speed;
    private float _effectDurection;
    private float angleX;
    private float angleY;

    private bool _effectedApplied;

    public ControllerPlayerMovable(Rigidbody rb, Point positionBody, float speed)
    {
        _input = new InputPlayer();

        _rb = rb;

        _positionBody = positionBody;

        _speed = speed;

        _playerMovable = new DefaultMovable(_positionBody, _rb, _speed);
    }

    public void ControleMovmentUpdate()
    {
        if (_effectedApplied)
            DispelEffect();
    }

    public void ControleMovmentFixupdate()
    {
        float z = 0f;
        float x = 0f;

        if (_input.GetKeyW())
            z = _speed;
        else if (_input.GetKeyS())
            z = -_speed;
        if (_input.GetKeyD())
            x = _speed;
        else if (_input.GetKeyA())
            x = -_speed;

        _directionMove = new Vector3(x, _rb.velocity.y, z);

        if (x != 0 || z != 0)
            _directionRotate = _directionMove;        

        _playerMovable.Move(this);
    }

    public void SetMovable(IEffect effect)
    {
        if (_effectedApplied)
            return;

        switch (effect.GetTypeEffect())
        {
            case (TypeEffect.inversPoison):                
                _playerMovable = new InverseMovable(_positionBody, _rb, _speed);
                break;
            case (TypeEffect.glide):
                _playerMovable = new GlideMovable(_positionBody, _rb, _speed);
                break;
            case (TypeEffect.slowdown):
                _playerMovable = new SlowMovable(_positionBody, _rb, _speed);
                break;
            default:
                break;
        }

        _effectDurection = effect.GetEffectDuration();

        _effectedApplied = true;
    }

    private void DispelEffect()
    {
        _effectDurection -= Time.deltaTime;

        if (_effectDurection <= 0)
        {            
            _playerMovable = new DefaultMovable(_positionBody, _rb, _speed);

            _effectedApplied = false;
        }
    }

    public Vector3 GetDirectionMove() => _directionMove;
    public Vector3 GetDirectionRotate() => _directionRotate;
}
