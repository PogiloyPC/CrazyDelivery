using PlayerInterface;
using UnityEngine;

public class CollisionDamage : Trap
{
    private void OnCollisionEnter(Collision other)
    {
        IHealthPlayer player = other.collider.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
            player.TakeDamage(this);
    }
}
