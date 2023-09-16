using PathInterface;
using UnityEngine;

public abstract class PathMovingUnit : MovingUnit
{
    [SerializeField] private Path _path;

    protected IPath PathReturn => _path;
}
