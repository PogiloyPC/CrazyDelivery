using System;
using UnityEngine;

public class ControllerDoors : MonoBehaviour
{
    [SerializeField] private Door[] _doors;

    [SerializeField] private TriggerForDoor[] _trigger;

    private Action<ITriggerForDoor> _onOpenDoor;
    private Action<ITriggerForDoor> _onCloseDoor;

    private void OnEnable()
    {
        _onOpenDoor += RedirectSignalOpen;
        _onCloseDoor += RedirectSignalClose;
    }

    private void OnDisable()
    {
        _onOpenDoor -= RedirectSignalOpen;
        _onCloseDoor -= RedirectSignalClose;
    }

    private void Start()
    {
        foreach (TriggerForDoor trigger in _trigger)
            trigger.InitTrigger(_onOpenDoor, _onCloseDoor);
    }

    public void RedirectSignalOpen(ITriggerForDoor trigger)
    {
        foreach (Door door in _doors)
            door.GetSignalForOpenDoor(trigger);
    }

    public void RedirectSignalClose(ITriggerForDoor trigger)
    {
        foreach (Door door in _doors)
            door.GetSignalForCloseDoor(trigger);
    }
}
