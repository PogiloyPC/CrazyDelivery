using InterfaceTable;
using UnityEngine;

public class ArrowJPS : MonoBehaviour
{            
    public void LookRotation(IMyPos target)
    {
        Vector3 direction = target.GetPosition().position - transform.position;        
        Vector3 directRotation = new Vector3(direction.x, 0f, direction.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directRotation), 5f);
    }
}
