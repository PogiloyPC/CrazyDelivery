using PathInterface;
using UnityEngine;

namespace UnitInterface
{
    public interface IMovable
    {
        void Move();
    }

    public interface IBodyUnit
    {
        void MoveBody(Vector3 target, float speed);

        Vector3 GetCurrentPosition();
    }

    public class BodyUnit : IBodyUnit
    {
        private Point _pointBody;

        public BodyUnit(Point pointBody)
        {
            _pointBody = pointBody;
        }

        public Vector3 GetCurrentPosition() => _pointBody.GetPosition();

        public void MoveBody(Vector3 target, float speed)
        {
            Transform body = _pointBody.GetTransform();

            Vector3 nextMovePosition = Vector3.MoveTowards(body.position, target, speed * Time.deltaTime);

            _pointBody.SetPosition(nextMovePosition);
        }            
    }

    public abstract class MoveUnit : IMovable
    {
        protected IBodyUnit _body;

        public float Speed { get; private set; }

        public MoveUnit(IBodyUnit body, float speed)
        {
            _body = body;

            Speed = speed;
        }

        public abstract void Move();
    }

    public class PathMove : MoveUnit, IPathWalker
    {
        private IPath _path;
        private float _distanceForNextPoint = 0.1f;

        public PathMove(IBodyUnit body, float speed, IPath path) : base(body, speed)
        {
            _path = path;
        }

        public override void Move()
        {
            _body.MoveBody(_path.GetNextPoint(), Speed);

            if (Vector3.Distance(_body.GetCurrentPosition(), _path.GetNextPoint()) < _distanceForNextPoint * _distanceForNextPoint)
                _path.SetNextPoint(this);
        }
    }

    public class RandomPointMove : MoveUnit
    {
        public RandomPointMove(IBodyUnit body, float speed) : base(body, speed)
        {

        }

        public override void Move()
        {

        }
    }

    public class BuyerMove : MoveUnit
    {
        public BuyerMove(IBodyUnit body, float speed) : base(body, speed)
        {

        }

        public override void Move()
        {

        }
    }
}