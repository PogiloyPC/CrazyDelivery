using PlayerInterface;
using TrapInterface;
using UnityEngine;

public abstract class Trap : MonoBehaviour, IDamageDillerPlayer, ITrap
{
    protected IPlayer _player;

    private int _damage = 1;

    public int GiveDamage() => _damage;

    public void InitTarget(IPlayer player) => _player = player;
}
