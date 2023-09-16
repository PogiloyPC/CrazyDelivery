using UIinterface;
using UnityEngine;

public class PanelSliderValuem : MonoBehaviour
{
    public void ChangeActive(ISetActivePanel active) => gameObject.SetActive(active.GetActive());
}
