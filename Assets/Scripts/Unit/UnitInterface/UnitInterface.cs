using PathInterface;
using UnityEngine;
using UnityEngine.AI;

namespace UnitInterface
{
    public interface IMovableUnit
    {
        void Move();
    }

    public abstract class MovableUnit : IMovableUnit
    {
        protected Point _currentPositionUnit;

        protected NavMeshAgent _agent;

        public float DistanceForNextPoint { get; private set; } = 0.05f;

        public MovableUnit(Point currentPositionUnit, NavMeshAgent agent)
        {
            _currentPositionUnit = currentPositionUnit;

            _agent = agent;
        }

        public abstract void Move();
    }

    public class PathMovable : MovableUnit, IPathWalker
    {
        private IPath _path;

        public PathMovable(Point currentPositionUnit, NavMeshAgent agent, IPath path) : base(currentPositionUnit, agent)
        {
            _path = path;
        }

        public override void Move()
        {
            if (!_agent.hasPath)
                ReloadDirectionMove();
        }

        private void ReloadDirectionMove()
        {
            _path.SetNextPoint(this);

            _agent.SetDestination(_path.GetNextPoint());
        }
    }

    public class RandomMovable : MovableUnit
    {
        private Vector3 _directionMove;

        private float _maxDistanceWalk = 15f;

        public RandomMovable(Point currentPositionUnit, NavMeshAgent agent) : base(currentPositionUnit, agent)
        {
            ReloadDirectionMove();
        }

        public override void Move()
        {
            Debug.DrawLine(_currentPositionUnit.GetPosition(), _directionMove);

            if (!_agent.hasPath)
                ReloadDirectionMove();
        }

        private void ReloadDirectionMove()
        {
            NavMeshPath navPath = _agent.path;

            Vector3 direction = new Vector3();

            float x = 0f;
            float z = 0f;

            bool routeConfirmed = false;

            while (!routeConfirmed)
            {
                x = Random.Range(_currentPositionUnit.GetPosition().x - _maxDistanceWalk,
                _currentPositionUnit.GetPosition().x + _maxDistanceWalk);
                z = Random.Range(_currentPositionUnit.GetPosition().z - _maxDistanceWalk,
                    _currentPositionUnit.GetPosition().z + _maxDistanceWalk);

                direction = new Vector3(x, _currentPositionUnit.GetPosition().y, z);

                if (_agent.CalculatePath(direction, navPath))
                {
                    _directionMove = direction;

                    _agent.SetDestination(_directionMove);

                    routeConfirmed = true;
                }
            }


        }
    }

    public class TargetMovable : MovableUnit
    {
        public TargetMovable(Point currentPositionUnit, NavMeshAgent agent, Vector3 TargetMove) : base(currentPositionUnit, agent)
        {

        }

        public override void Move()
        {
            throw new System.NotImplementedException();
        }
    }
}