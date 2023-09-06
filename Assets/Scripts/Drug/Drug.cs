using InterfaceDrug;
using PlayerInterface;
using System.Collections;
using UnityEngine;

public class Drug : MonoBehaviour, IDrug
{
    [SerializeField] private Vector3 _rotateZXY;

    private int _healthUp = 1;

    void Start()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while (true)
        {
            transform.rotation *= Quaternion.Euler(_rotateZXY);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    public int GetHealth() => _healthUp;

    private void OnCollisionEnter(Collision other)
    {
        IHealthPlayer player = other.collider.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.RestoreHealth(this);

            Destroy(gameObject);
        }
    }
}
