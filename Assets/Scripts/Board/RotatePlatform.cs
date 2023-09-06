using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour
{
    [SerializeField] private Point _platformPoint;

    private Vector3 _upPoint;
    private Vector3 _downPoint;

    [SerializeField] private float _speedRotation;
    [SerializeField] private float _speed;
    [SerializeField] private float _distanceUpMoving;

    private bool _upMoving;

    private void Start()
    {
        _upPoint = new Vector3(0f, transform.position.y + _distanceUpMoving, 0f);
        _downPoint = new Vector3(0f, transform.position.y, 0f);

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            Vector3 direction;

            if (_upMoving)
                direction = new Vector3(0f, _speedRotation * Time.deltaTime, 0f);
            else
                direction = new Vector3(0f, -_speedRotation * Time.deltaTime, 0f);

            transform.rotation *= Quaternion.Euler(direction);

            Moving();

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    private void Moving()
    {        
        float speed = _speed;

        if (_upMoving)
        {
            
            if (_platformPoint.GetPosition().y >= _upPoint.y)
                _upMoving = false;
        }
        else
        {
            speed = -speed;

            if (_platformPoint.GetPosition().y <= _downPoint.y)
                _upMoving = true;
        }

        Vector3 position = new Vector3(_platformPoint.GetPosition().x, 
            _platformPoint.GetPosition().y + speed * Time.deltaTime, _platformPoint.GetPosition().z);

        _platformPoint.SetPosition(position);
    }
}
