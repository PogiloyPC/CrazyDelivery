using System.Collections;
using System.Collections.Generic;
using TrapInterface;
using UnityEngine;

public class ScaleAniamtion : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Transform _bodyObject;
    [SerializeField] private Transform _worldTransformObject;

    [SerializeField] private Vector3 _scaleUp;
    [SerializeField] private Vector3 _scaleDown;
    private Vector3 _scaleStart;

    [SerializeField] private float _scaleKoefficient;
    [SerializeField] private float _rotationKoefficient;

    private void Start()
    {
        _scaleStart = _bodyObject.localScale;
    }

    private void FixedUpdate()
    {
        Vector3 relativePosition = transform.InverseTransformPoint(_worldTransformObject.position);

        float interpolant = relativePosition.y * _scaleKoefficient;

        Vector3 scale = Lerp(_scaleDown, _scaleStart, _scaleUp, interpolant);

        _bodyObject.localEulerAngles = new Vector3(relativePosition.z, 0f, -relativePosition.x) * _rotationKoefficient;
        _bodyObject.localScale = scale;
    }

    private Vector3 Lerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        if (t < 0f)
            return Vector3.LerpUnclamped(a, b, t + 1f);
        else
            return Vector3.LerpUnclamped(b, c, t);
    }

    public void AddForce(IScaling scaling) => 
        _rb.AddForce(new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f)) * scaling.GetForce(), ForceMode.Impulse);
}
