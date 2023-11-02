using PlayerInterface;
using UnityEngine;

public abstract class PlayerMovable : IPlayerMovable
{
    protected Rigidbody _rb;

    protected Point _transform;   

    public float _speed { get; private set; }

    public PlayerMovable(Point transform, Rigidbody rb, float speed)
    {
        _transform = transform;

        _rb = rb;

        _speed = speed;
    }

    public abstract void Move(IControllerDirectionMovable controllerMovable);
}

public class DefaultMovable : PlayerMovable
{
    public DefaultMovable(Point transform, Rigidbody rb, float speed) : base(transform, rb, speed)
    {

    }

    public override void Move(IControllerDirectionMovable controllerMovable)
    {        
        Vector3 direction = controllerMovable.GetDirectionMove();
        Vector3 directWorld = _transform.GetTransform().TransformVector(direction);

        _rb.velocity = directWorld;
    }
}

public class InverseMovable : PlayerMovable
{
    public InverseMovable(Point transform, Rigidbody rb, float speed) : base(transform, rb, speed)
    {

    }

    public override void Move(IControllerDirectionMovable controllerMovable)
    {       
        Vector3 direction = controllerMovable.GetDirectionMove();
        Vector3 directWorld = _transform.GetTransform().TransformVector(direction);

        _rb.velocity = directWorld * -1;
    }
}

public class SlowMovable : PlayerMovable
{
    public SlowMovable(Point transform, Rigidbody rb, float speed) : base(transform, rb, speed)
    {

    }

    public override void Move(IControllerDirectionMovable controllerMovable)
    {       
        Vector3 direction = controllerMovable.GetDirectionMove();
        Vector3 directWorld = _transform.GetTransform().TransformVector(direction);

        _rb.velocity = directWorld / 3;
    }
}

public class GlideMovable : PlayerMovable
{

    public GlideMovable(Point transform, Rigidbody rb, float speed) : base(transform, rb, speed)
    {

    }

    public override void Move(IControllerDirectionMovable controllerMovable)
    {       
    }
}
