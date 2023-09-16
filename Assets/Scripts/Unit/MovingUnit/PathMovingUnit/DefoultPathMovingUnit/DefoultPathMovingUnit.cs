using UnitInterface;

public class DefoultPathMovingUnit : PathMovingUnit
{
    protected override void InitMovable() => _movable = new PathMove(_bodyUnit, Speed, PathReturn);    
    
    private void Update()
    {
        _movable.Move();
    }
}
