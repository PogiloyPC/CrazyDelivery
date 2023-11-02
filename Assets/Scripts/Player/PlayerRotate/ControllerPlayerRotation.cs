using PlayerInterface;
using UnityEngine;

public class ControllerPlayerRotation
{
    private Transform _bodyPlayer;

    IControllerDirectionMovable _controllerDirection;

    private float _smooth;

    public ControllerPlayerRotation(Transform bodyPlayer, IControllerDirectionMovable controllerDirection, float smooth)
    {
        _bodyPlayer = bodyPlayer;

        _controllerDirection = controllerDirection;

        _smooth = smooth;
    }

    public void Rotate()
    {
        _bodyPlayer.rotation = Quaternion.Slerp(_bodyPlayer.rotation, Quaternion.LookRotation(_controllerDirection.GetDirectionRotate()),
            _smooth * Time.deltaTime);
    }
}
