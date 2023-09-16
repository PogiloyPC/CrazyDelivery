using PlayerInterface;
using System.Collections;
using UnityEngine;

public class Mine : Trap
{
    [SerializeField] private AudioClip _signalSound;
    [SerializeField] private AudioSource _source;

    [SerializeField] private Renderer _lamp;

    [SerializeField] private Material _red;
    [SerializeField] private Material _green;

    private IHealthPlayer _playerHealth;

    private IEnumerator _explosion;

    [SerializeField] private float _radiusCircle;
    [SerializeField] private float _speedLerpColor;
    [SerializeField] private float _forceExplosion;
    [SerializeField] private float _timeExplosion;

    [SerializeField] private bool _deactivation;

    private void OnTriggerEnter(Collider other)
    {
        IHealthPlayer player = other.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            _playerHealth = player;

            _explosion = ControleTimeMine();

            StartCoroutine(_explosion);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        IHealthPlayer player = other.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            _playerHealth = null;

            _lamp.material = _green;
            if (_deactivation)
                StopCoroutine(_explosion);
        }
    }

    private IEnumerator ControleTimeMine()
    {
        float timeExplosion = _timeExplosion;
        float speedLerpColor = _speedLerpColor;
        float t = 0f;

        bool ty = false;

        while (true)
        {
            timeExplosion -= Time.deltaTime;

            if (!ty)
            {
                t += speedLerpColor * Time.deltaTime;

                if (t >= 1f)
                {
                    speedLerpColor += 1.5f;

                    _source.PlayOneShot(_signalSound);

                    ty = true;
                }
            }
            else
            {
                t -= speedLerpColor * Time.deltaTime;

                if (t <= 0f)
                {
                    ty = false;
                }
            }

            _lamp.material.color = Color.Lerp(_green.color, _red.color, t);

            if (timeExplosion <= 0f)
            {
                Explosion();

                break;
            }

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public void Explouse()
    {
        Explosion();
    }

    private void Explosion()
    {
        Collider[] colliderAll = Physics.OverlapSphere(transform.position, _radiusCircle);

        for (int i = 0; i < colliderAll.Length; i++)
        {
            Rigidbody body = colliderAll[i].gameObject.GetComponent<Rigidbody>();

            if (body)
                body.AddExplosionForce(_forceExplosion, transform.position, _radiusCircle);
        }

        if (_playerHealth != null)
            _playerHealth.TakeDamage(this);

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radiusCircle);
    }
}
