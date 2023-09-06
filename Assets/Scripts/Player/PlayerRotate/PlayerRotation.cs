using UnityEngine;

public class PlayerRotation 
{
    private Transform _bodyPlayer;

    private InputPlayer _inputPlayer;

    private Vector3 _direct;

    private float _speed;
    private float _smooth;

    private float _x;
    private float _z;

    public PlayerRotation(Transform bodyPlayer, float speed, float smooth)
    {
        _inputPlayer = new InputPlayer();

        _bodyPlayer = bodyPlayer;
        
        _speed = speed;
        _smooth = smooth;
    }

    public void Rotate()
    {
        CheckDirectRotate();

        if (_x != 0 || _z != 0f)
            _bodyPlayer.rotation = Quaternion.Slerp(_bodyPlayer.rotation, Quaternion.LookRotation(_direct), _smooth * Time.deltaTime);
    }

    private void CheckDirectRotate()
    {
        if (_inputPlayer.GetKeyW() && _inputPlayer.GetKeyD())
        {
            _z = _speed;
            _x = _speed;
        }
        else if (_inputPlayer.GetKeyW() && _inputPlayer.GetKeyA())
        {
            _z = _speed;
            _x = -_speed;
        }
        else if (_inputPlayer.GetKeyS() && _inputPlayer.GetKeyD())
        {
            _z = -_speed;
            _x = _speed;
        }
        else if (_inputPlayer.GetKeyS() && _inputPlayer.GetKeyA())
        {
            _z = -_speed;
            _x = -_speed;
        }
        else if (_inputPlayer.GetKeyW())
        {
            _z = _speed;
            _x = 0f;
        }
        else if (_inputPlayer.GetKeyS())
        {
            _z = -_speed;
            _x = 0f;
        }
        else if (_inputPlayer.GetKeyD())
        {
            _x = _speed;
            _z = 0f;
        }
        else if (_inputPlayer.GetKeyA())
        {
            _x = -_speed;
            _z = 0f;
        }

        _direct = new Vector3(_x, 0f, _z);
    }
}
