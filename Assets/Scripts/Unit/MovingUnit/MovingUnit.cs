using PathInterface;
using UnitInterface;
using UnityEngine;
using UnityEngine.AI;

public abstract class MovingUnit : Unit
{
    [SerializeField] private Point _pointBody;
    [SerializeField] private NavMeshAgent _agent;

    protected IMovableUnit _movable;    

    protected void InitMovable(IPath path = null)
    {
        if (path != null)
            _movable = new PathMovable(_pointBody, _agent, path);
        else
            _movable = new RandomMovable(_pointBody, _agent);
    }

    private void Update()
    {
        _movable.Move();
    }
}
