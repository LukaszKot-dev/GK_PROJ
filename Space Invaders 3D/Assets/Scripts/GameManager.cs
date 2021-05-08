using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public GameObject PlayerObject;
    public HealthBar HealthBar;
    public int points;
    public GameObject mainMenuObj;
    public MainMenu mainMenu;
    public GameOver GameOver;
    public bool gameHasEnded = false;

    private void Awake()
    {
        //if (!Player) Player = FindObjectOfType<PlayerController>();
        //Player.healthUpdated += UpdateHealthBar;
    }

    private void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        GameObject.Instantiate(mainMenuObj);
    }

    private void UpdateHealthBar()
    {
      //  HealthBar.SetHealth(Player.CurrentHealth());
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void GameEnded(string currentTime)
    { 
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over");
            GameOver.Setup(currentTime);
        }
        
    }
}