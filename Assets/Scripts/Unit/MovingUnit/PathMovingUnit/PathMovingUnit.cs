using UnityEngine;

public class PathMovingUnit : MovingUnit
{
    [SerializeField] private Path _path;

    private void Start()
    {
        InitMovable(_path);
    }
}
