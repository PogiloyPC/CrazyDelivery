using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using GameControleInterface;
using InterfaceDrug;
using PlayerInterface;

public class PlayerHealth : MonoBehaviour, IHealthPlayer
{
    private Action<IHealthPlayer> _onDead;
    private Action<IHealthPlayer> _onChangeHealth;

    [SerializeField] private Image _healthBar;

    [SerializeField] private Renderer _renderer;

    [SerializeField] private Material _defoult;
    [SerializeField] private Material _damage;

    [SerializeField] private int _timeImmortality;
    [SerializeField, Range(0, 3)] private int _startHealth;
    private int _currentHealth;

    private bool _isDead;
    private bool _isImmortality; 

    private void OnEnable()
    {
        _isImmortality = false;

        _renderer.material = _defoult;
    }

    public void InitAction(IControleScene controleScene)
    {
        _onDead += controleScene.RestartLevel;
        _onChangeHealth += controleScene.GetViewHealthPlayer().DisplayHealth;

        _currentHealth = _startHealth;
    }

    public void TakeDamage(IHitPlayer damage)
    {
        int health = _currentHealth;

        if (!_isImmortality)
        {
            _currentHealth -= damage.GiveDamage();

            if (_currentHealth < health)
            {
                StartCoroutine(OnImmortality());

                _onChangeHealth.Invoke(this);
            }

            if (_currentHealth <= 0f)
            {
                _isDead = true;

                _onDead.Invoke(this);
            }
        }
    }

    public void RestoreHealth(IDrug drug)
    {
        if (_currentHealth < _startHealth)
        {
            _currentHealth += drug.GetHealth();

            _onChangeHealth.Invoke(this);
        }
    }

    public bool IsDead() => _isDead;

    public int CurrentHealth() => _currentHealth;

    public int StartHealth() => _startHealth;    

    private IEnumerator OnImmortality()
    {
        _isImmortality = true;

        for (int i = 0; i < _timeImmortality; i++)
        {
            _renderer.material = _damage;
            yield return new WaitForSeconds(0.3f);
            _renderer.material = _defoult;
            yield return new WaitForSeconds(0.3f);
        }

        _isImmortality = false;
    }
}