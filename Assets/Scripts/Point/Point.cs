using UnityEngine;

public class Point : MonoBehaviour
{
    public Transform GetTransform() => transform;
    public Vector3 GetPosition() => transform.position;
    public Quaternion GetRotation() => transform.rotation;
    public Vector3 GetScale() => transform.localScale;
    public void SetPosition(Vector3 position) => transform.position = position;
    public void SetRotation(Quaternion rotation) => transform.rotation = rotation;
    public Vector3 SetScale(Vector3 scale) => transform.localScale = scale;
}
