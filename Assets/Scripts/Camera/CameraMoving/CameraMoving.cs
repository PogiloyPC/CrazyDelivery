using PlayerInterface;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    private Point _player;

    [SerializeField] private Vector3 _offset;

    [SerializeField] private float _damping;

    public void InitPoint(IPlayerPoint player)
    {
        _player = player.GetPoint();
    }

    private void LateUpdate()
    {
        Vector3 directionX = Vector3.Lerp(transform.position, 
            new Vector3(_player.GetPosition().x + _offset.x, _player.GetPosition().y + _offset.y, _player.GetPosition().z + _offset.z),
            _damping * Time.deltaTime);        

        transform.position = new Vector3(directionX.x, directionX.y, directionX.z);
    }
}
