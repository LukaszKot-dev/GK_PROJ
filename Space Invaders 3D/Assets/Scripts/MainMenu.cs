using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //   TimerController.instance.BeginTimer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameManager.Instance.StartGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}