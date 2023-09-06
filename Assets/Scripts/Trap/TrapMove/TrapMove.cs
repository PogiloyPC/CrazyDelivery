using PlayerInterface;
using UnityEngine;

public class TrapMove : Trap
{
    [SerializeField] private Point _pos;

    [SerializeField] private float _distance;
    [SerializeField] private float _speed;

    [SerializeField] private bool _movingX;
    [SerializeField] private bool _movingY;
    [SerializeField] private bool _movingZ;
    private bool _rightMove;

    private void Update()
    {
        float speedX = 0f;
        float speedY = 0f;
        float speedZ = 0f;

        if (_movingX)
            speedX = _speed;
        else if (_movingY)
            speedY = _speed;
        else if (_movingZ)
            speedZ = _speed;

        Moving(speedX, speedY, speedZ);
    }

    private void Moving(float speedX, float speedY, float speedZ)
    {
        Vector3 rightPoint = new Vector3(_pos.GetPosition().x + _distance, _pos.GetPosition().y + _distance, _pos.GetPosition().z + _distance);
        Vector3 leftPoint = new Vector3(_pos.GetPosition().x - _distance, _pos.GetPosition().y - _distance, _pos.GetPosition().z - _distance);

        if (_rightMove)
        {
            transform.position = new Vector3(transform.position.x + speedX * Time.deltaTime, transform.position.y + speedY * Time.deltaTime,
                transform.position.z + speedZ * Time.deltaTime);

            if (transform.position.x >= rightPoint.x || transform.position.y >= rightPoint.y || transform.position.z >= rightPoint.z)
                _rightMove = false;
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speedX * Time.deltaTime, transform.position.y - speedY * Time.deltaTime,
                transform.position.z - speedZ * Time.deltaTime);

            if (transform.position.x <= leftPoint.x || transform.position.y <= leftPoint.y || transform.position.z <= leftPoint.z)
                _rightMove = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        IHealthPlayer player = other.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
            player.TakeDamage(this);
    }
}
