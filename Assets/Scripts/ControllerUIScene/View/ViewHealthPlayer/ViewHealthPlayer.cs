using PlayerInterface;
using UnityEngine;
using UnityEngine.UI;
using ViewInterface;

public class ViewHealthPlayer : MonoBehaviour, IViewHealthPlayer
{
    [SerializeField] private Image _healthBar;

    public void DisplayHealth(IHealthPlayer healthPlayer)
    {
        float startHealth = healthPlayer.StartHealth();
        float currentHealth = healthPlayer.CurrentHealth();

        _healthBar.fillAmount = currentHealth / startHealth;        
    }
}
