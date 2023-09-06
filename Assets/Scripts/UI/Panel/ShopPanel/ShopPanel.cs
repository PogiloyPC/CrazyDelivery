using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : MonoBehaviour, ISetActive
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void ChangeActive(bool active)
    {
        Debug.Log(active);
        gameObject.SetActive(active);
    }
}
