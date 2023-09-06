using PlayerInterface;
using TrapInterface;
using UnityEngine;

public class JumpingPlatform : MonoBehaviour, IScaling, IPlatformJumping
{
    [SerializeField] private ScaleAniamtion _elasticityAnim;

    [SerializeField] private float _forceJump;
    private float _recoil;
    [SerializeField, Range(0.1f, 1f)] private float _unscaleForce;

    public float GetForce() => _recoil;

    private void OnCollisionEnter(Collision other)
    {
        ICanJump player = other.collider.gameObject.GetComponent<ICanJump>();

        if (player != null)
        {
            _recoil = other.impulse.magnitude / 2f;
            
            _elasticityAnim.AddForce(this);
            
            if (other.impulse.magnitude * _unscaleForce < _forceJump)
                _recoil = _forceJump;
            else
                _recoil = other.impulse.magnitude * _unscaleForce;
            
            player.SetForce(this);
        }
    }


}
