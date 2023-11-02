using PlayerInterface;
using System;
using UnityEngine;

public class TriggerForDoor : MonoBehaviour, ITriggerForDoor
{
    [SerializeField] private int _idTrigger;

    private Action<ITriggerForDoor> _onOpenDoor;
    private Action<ITriggerForDoor> _onCloseDoor;

    public void InitTrigger(Action<ITriggerForDoor> onOpenDoor, Action<ITriggerForDoor> onCloseDoor)
    {
        _onOpenDoor = onOpenDoor;
        _onCloseDoor = onCloseDoor;
    }

    public int GetID() => _idTrigger;

    private void OnTriggerEnter(Collider other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();

        if (player != null)
            _onOpenDoor.Invoke(this);
    }
    
    private void OnTriggerExit(Collider other)
    {
        IPlayer player = other.gameObject.GetComponent<IPlayer>();

        if (player != null)
            _onCloseDoor.Invoke(this);
    }
}
