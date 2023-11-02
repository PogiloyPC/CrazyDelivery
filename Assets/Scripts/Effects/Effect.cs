using InterfaceEffects;
using UnityEngine;

public class Effect : MonoBehaviour, IEffect
{
    [SerializeField] private TypeEffect _typeEffect;

    [SerializeField] private float _durationEffect;

    public TypeEffect GetTypeEffect() => _typeEffect;

    public float GetEffectDuration() => _durationEffect;
}
