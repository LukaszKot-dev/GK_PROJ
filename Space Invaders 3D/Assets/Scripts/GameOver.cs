using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text timeScoreText;
    public Text bestTimeText;

    public void Setup(string score)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        timeScoreText.text = "Your time: " + score;
        bestTimeText.text = "Best time: " + GameManager.Instance.BestTime;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}