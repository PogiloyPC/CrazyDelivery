using UnityEngine;

namespace PathInterface
{
    public enum PathType
    {
        line,
        loping
    }

    public enum TypeMovePath
    {
        lerp,
        line
    }

    public interface IPath
    {
        void SetNextPoint(IPathWalker pathWalker);

        Vector3 GetNextPoint();
    }

    public interface IPathWalker
    {

    }
}
