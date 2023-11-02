using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private AnimationCurve _openCurve;

    private IEnumerator _openCloseDoor;

    private Vector3 _positionStart;
    private Vector3 _positionOpen;

    [SerializeField] private int _idDoor;

    [SerializeField] private float _speedDoor;

    private bool _isOpen;

    private void Start()
    {
        _positionStart = transform.position;
        _positionOpen = new Vector3(transform.position.x, transform.position.y + transform.localScale.y, transform.position.z);
    }

    public void GetSignalForOpenDoor(ITriggerForDoor trigger)
    {
        if (_idDoor == trigger.GetID())
        {
            if (_openCloseDoor != null)
                StopCoroutine(_openCloseDoor);

            _openCloseDoor = CloseOpenDoor();

            _isOpen = true;

            StartCoroutine(_openCloseDoor);
        }
    }

    public void GetSignalForCloseDoor(ITriggerForDoor trigger)
    {
        if (_idDoor == trigger.GetID())
        {
            if (_openCloseDoor != null)
                StopCoroutine(_openCloseDoor);

            _openCloseDoor = CloseOpenDoor();

            _isOpen = false;

            StartCoroutine(_openCloseDoor);
        }
    }

    private IEnumerator CloseOpenDoor()
    {
        Vector3 directionMove;
        if (_isOpen)
            directionMove = _positionOpen;
        else
            directionMove = _positionStart;

        while (true)
        {
            transform.position = Vector3.Lerp(transform.position, directionMove, _speedDoor * Time.deltaTime);

            if (Vector3.Distance(transform.position, directionMove) <= 0.1f * 0.1f)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
