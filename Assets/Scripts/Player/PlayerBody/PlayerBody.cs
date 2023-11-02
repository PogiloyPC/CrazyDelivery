using InterfaceEffects;
using PlayerInterface;
using UnityEngine;

public class PlayerBody : MonoBehaviour, IPlayerPoint
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Player _player;
    [SerializeField] private Point _point;

    public IHealthPlayer GetPlayerHealth() => _playerHealth;
    public IPlayer GetPlayer() => _player;
    public Point GetPoint() => _point;

    private void OnTriggerEnter(Collider other)
    {
        IEffect effect = other.gameObject.GetComponent<IEffect>();

        if (effect != null)
        {
           
            _player.TakeEffect(effect);        
        }
    }
}

