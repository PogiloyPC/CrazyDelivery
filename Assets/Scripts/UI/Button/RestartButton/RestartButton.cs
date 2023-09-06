using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : DinamicButton
{
    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
