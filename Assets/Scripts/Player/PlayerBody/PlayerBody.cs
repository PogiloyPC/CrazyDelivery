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
}

