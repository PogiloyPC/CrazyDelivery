using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceEffects 
{
    public interface IEffect
    {
        TypeEffect GetTypeEffect();

        public float GetEffectDuration();
    }

    public enum TypeEffect
    {
        glide, 
        inversPoison,
        slowdown
    }

}
