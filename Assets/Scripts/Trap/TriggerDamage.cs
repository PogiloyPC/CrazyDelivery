using PlayerInterface;
using UnityEngine;

public class TriggerDamage : Trap
{
    private void OnTriggerEnter(Collider other)
    {
        IHealthPlayer player = other.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
            player.TakeDamage(this);
    }
}
