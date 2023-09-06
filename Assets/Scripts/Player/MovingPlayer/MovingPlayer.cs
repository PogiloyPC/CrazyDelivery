using UnityEngine;

public class MovingPlayer
{
    private Transform _transform;

    private InputPlayer _inputPlayer;

    private Rigidbody _rb;

    private float _speed;

    public MovingPlayer(Transform transform, Rigidbody rb, float speed)
    {
        _inputPlayer = new InputPlayer();

        _transform = transform;

        _rb = rb;

        _speed = speed;
    }

    public void Moving()
    {
        float z = 0f;
        float x = 0f;

        if (_inputPlayer.GetKeyW())
            z = _speed;
        else if (_inputPlayer.GetKeyS())
            z = -_speed;

        if (_inputPlayer.GetKeyD())
            x = _speed;
        else if (_inputPlayer.GetKeyA())
            x = -_speed;

        Vector3 direct = new Vector3(x, 0f, z);
        Vector3 directWorld = _transform.TransformVector(direct);

        _rb.velocity = new Vector3(directWorld.x, _rb.velocity.y, directWorld.z);
    }
}
