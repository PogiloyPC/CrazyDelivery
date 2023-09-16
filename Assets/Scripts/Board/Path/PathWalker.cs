using PathInterface;
using PlayerInterface;
using TrapInterface;
using UnityEngine;

public class PathWalker : MonoBehaviour, IPathWalker, IBoard
{
    [SerializeField] private Path _path;

    private IPlayer _player;

    [SerializeField] private TypeMovePath _typeMove;

    [SerializeField] private float _speed;
    private float _distance = 0.1f;

    private bool _havePlayer;

    private void OnDestroy()
    {
        SetParentPlayer(false);
    }

    private void Update()
    {
        if (_path)
        {
            if (_typeMove == TypeMovePath.lerp)
                transform.position = Vector3.Lerp(transform.position, _path.GetNextPoint(), Time.deltaTime * _speed);
            else
                transform.position = Vector3.MoveTowards(transform.position, _path.GetNextPoint(), Time.deltaTime * _speed);

            if (Vector3.Distance(transform.position, _path.GetNextPoint()) < _distance * _distance)
                _path.SetNextPoint(this);
        }
    }

    public bool GetSignal() => _havePlayer;

    private void SetParentPlayer(bool value, Transform transform = null)
    {
        _havePlayer = value;

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
        }
    }

    private void OnCollisionExit(Collision other)
    {
        IPlayer player = other.collider.gameObject.GetComponent<IPlayer>();

        if (player != null)
        {
            SetParentPlayer(false);

            _player = null;
        }
    }
}
