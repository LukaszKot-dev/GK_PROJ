using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text timeScoreText;

    public void Setup(string score)
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        timeScoreText.text = "Your time: " + score;
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
