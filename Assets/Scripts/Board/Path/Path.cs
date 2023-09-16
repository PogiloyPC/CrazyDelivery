using PathInterface;
using UnityEngine;

public class Path : MonoBehaviour, IPath
{
    [SerializeField] private Point[] _points;

    [SerializeField] private PathType _pathType;

    private int _numberPoint;

    private bool _backMove;

    public Vector3 GetNextPoint() => _points[_numberPoint].GetPosition();

    public void SetNextPoint(IPathWalker pathWalker)
    {
        if (_pathType == PathType.line)
        {
            if (!_backMove)
            {
                _numberPoint++;

                if (_numberPoint >= _points.Length - 1)
                    _backMove = true;
            }
            else
            {
                _numberPoint--;

                if (_numberPoint <= 0f)
                    _backMove = false;
            }
        }
        else
        {
            _numberPoint++;

            if (_numberPoint >= _points.Length)
                _numberPoint -= _numberPoint;
        }
    }    


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;

        if (_pathType == PathType.loping)
            Gizmos.DrawLine(_points[0].GetPosition(), _points[_points.Length - 1].GetPosition());

        for (int i = 0; i < _points.Length; i++)
        {            
            Gizmos.DrawLine(_points[i].GetPosition(), _points[i + 1].GetPosition());
        }
    }
}
