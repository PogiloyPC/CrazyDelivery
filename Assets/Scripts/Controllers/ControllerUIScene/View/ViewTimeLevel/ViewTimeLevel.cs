using SceneControleInterface;
using UnityEngine;
using UnityEngine.UI;

public class ViewTimeLevel : MonoBehaviour
{
    [SerializeField] private Text _scoreTime;

    [SerializeField] private float _greenTime;

    private Color _green = Color.green;
    private Color _yellow = Color.yellow;
    private Color _red = Color.red;

    public void DisplayTime(IContainerTimeLevel timeLevel)
    {
        if (timeLevel.CurrentTimeLevel() >= _greenTime)
            _scoreTime.color = Color.Lerp(_yellow, _green, 
                (timeLevel.CurrentTimeLevel() - _greenTime) / (timeLevel.StartTimeLevel() - _greenTime));
        else
            _scoreTime.color = Color.Lerp(_red, _yellow, timeLevel.CurrentTimeLevel() / _greenTime);

        float currentTime = Mathf.Clamp(timeLevel.CurrentTimeLevel(), 0f, timeLevel.StartTimeLevel());

        _scoreTime.text = currentTime.ToString("0.000");
    }

}
