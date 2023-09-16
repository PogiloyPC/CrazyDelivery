using SceneControleInterface;
using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private Trap[] _traps;
    
    public void InitTrap(IContainePlayer containerPlayer)
    {
        for (int i = 0; i < _traps.Length; i++)
            _traps[i].InitTarget(containerPlayer.GetPlayer());
    }
}
