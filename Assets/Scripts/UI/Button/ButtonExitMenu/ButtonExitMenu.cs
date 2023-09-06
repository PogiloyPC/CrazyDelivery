using UnityEngine.SceneManagement;

public class ButtonExitMenu : StaticButton
{
    public void GoHome() => SceneManager.LoadScene("MainMenu");
}
