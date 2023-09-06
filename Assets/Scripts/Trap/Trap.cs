using PlayerInterface;
using UnityEngine;

public class Trap : MonoBehaviour, IHitPlayer
{
    private int _damage = 1;

    public int GiveDamage() => _damage;    
}
