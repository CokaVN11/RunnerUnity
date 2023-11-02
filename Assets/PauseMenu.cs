using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Object MainMenuScene;
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }
    public void PauseGame()
    {
        if (Time.timeScale != 0) Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        if (Time.timeScale != 1) Time.timeScale = 1;
    }
}
