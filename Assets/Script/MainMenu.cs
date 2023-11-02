using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (Time.timeScale != 1) Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Debug.Log("Quit!!!");
        Application.Quit();
    }
}
