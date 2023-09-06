using System.Collections;
using UnityEngine;

public class SendwichTrap : MonoBehaviour
{
    [SerializeField] private Point _startRotate;
    [SerializeField] private Point _finishRotate;
    [SerializeField] private Point _objectRotate;

    [SerializeField] private float _waitingTime;
    [SerializeField] private float _timeAttack;
    [SerializeField] private float _speedAttack;
    [SerializeField] private float _timeReloadAttack;

    void Start()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        float interpolant = 0f;

        yield return new WaitForSeconds(_waitingTime);
        yield return new WaitForSeconds(_timeAttack);

        _waitingTime = 0f;

        while (true)
        {
            interpolant += _speedAttack * Time.deltaTime;

            Quaternion rotation = Quaternion.Lerp(_objectRotate.GetRotation(), _finishRotate.GetRotation(), interpolant);
            _objectRotate.SetRotation(rotation); 

            if (interpolant >= 1f)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        StartCoroutine(ReloadAttack());
    }

    private IEnumerator ReloadAttack()
    {
        float interpolant = 0f;

        while (true)
        {
            interpolant += Time.deltaTime;

            Quaternion rotation = Quaternion.Slerp(_finishRotate.GetRotation(), _startRotate.GetRotation(), interpolant / _timeReloadAttack);
            _objectRotate.SetRotation(rotation);

            if (interpolant >= _timeReloadAttack)
                break;

            yield return new WaitForSeconds(Time.deltaTime);
        }

        StartCoroutine(Attack());
    }
}
