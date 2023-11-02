using UnityEngine;
using PlayerInterface;
using TrapInterface;
using InterfaceEffects;

public class Player : MonoBehaviour, IPlayer, ICanJump, ITakeOrder, IDeliveryOrder
{
    [SerializeField] private Rigidbody _rb;

    [SerializeField] private Point _positionHandle;
    [SerializeField] private Point _positionBody;

    private Order _order;

    private ControllerPlayerRotation _controllerRotate;
    private ControllerPlayerMovable _controllerMovable;

    [SerializeField] private Vector3 _direct;

    [SerializeField] private float _speed;
    [SerializeField] private float _smooth;

    private bool _isStope;
    private bool _busy;

    private void Start()
    {
        _controllerMovable = new ControllerPlayerMovable(_rb, _positionBody, _speed);
        _controllerRotate = new ControllerPlayerRotation(transform, _controllerMovable, _smooth);
    }

    private void Update()
    {
        _controllerMovable.ControleMovmentUpdate();
        _controllerRotate.Rotate();
    }

    private void FixedUpdate()
    {
        if (!_isStope)
            _controllerMovable.ControleMovmentFixupdate();
    }

    public Vector3 GetPositionOrder() => _positionHandle.GetPosition();

    public Transform GetTransform() => _positionBody.GetTransform();

    public Transform GetTransformOrder() => _positionHandle.GetTransform();

    public float GetSpeedRotation() => _smooth;

    public bool CheckBusy() => _busy;

    public void SetForce(IPlatformJumping platform) => _rb.AddForce(Vector3.up * platform.GetForce(), ForceMode.Impulse);

    public void SetMoving(IFingerBoard fingerboard)
    {
        _isStope = fingerboard.GetSignal();
        _busy = fingerboard.GetSignal();

        SetInterpolate(fingerboard.GetSignal());
    }

    public void SetMoving(IBoard board)
    {
        _busy = board.GetSignal();

        SetInterpolate(board.GetSignal());
    }

    private void SetInterpolate(bool value)
    {
        if (value)
            _rb.interpolation = RigidbodyInterpolation.None;
        else
            _rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    public void SetOrder(Order order) => _order = order;

    public Order GetOrder() => _order;

    public void TakeEffect(IEffect effect)
    {        
        _controllerMovable.SetMovable(effect);
    }
}
