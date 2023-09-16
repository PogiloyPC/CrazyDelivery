using UnitInterface;
using UnityEngine;

public abstract class MovingUnit : Unit
{
    [SerializeField] private Point _pointBody;

    protected IBodyUnit _bodyUnit;

    protected IMovable _movable;

    [SerializeField] private float _speed;
    public float Speed { get { return _speed; } private set { } }

    private void Start()
    {
        _bodyUnit = new BodyUnit(_pointBody);

        InitMovable();
    }

    protected abstract void InitMovable();
}
