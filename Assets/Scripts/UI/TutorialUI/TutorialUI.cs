using UnityEngine;

public abstract class TutorialUI : MonoBehaviour
{
    [SerializeField] private float _destroyTime;
    public float DestroyTime { get { return _destroyTime; } private set { } }    
}
