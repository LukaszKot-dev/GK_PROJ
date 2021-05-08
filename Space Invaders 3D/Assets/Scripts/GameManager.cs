using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public GameObject PlayerObject;
    public HealthBar HealthBar;
    public GameObject mainMenuObj;
    public MainMenu mainMenu;
    public bool gameHasEnded = false;

    private void Awake()
    {
        //if (!Player) Player = FindObjectOfType<PlayerController>();
        //Player.healthUpdated += UpdateHealthBar;
    }

    private void Start()
    {
        ShowMainMenu();
   //     TimerController.instance.BeginTimer();
    }

    private void ShowMainMenu()
    {
        GameObject.Instantiate(mainMenuObj);
    }

    private void UpdateHealthBar()
    {
        HealthBar.SetHealth(Player.CurrentHealth());
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void GameOver()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game over");
            //Game Over Menu
        }
        
    }
}