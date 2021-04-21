using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController Player;
    public GameObject PlayerObject;
    public HealthBar HealthBar;
    public GameObject mainMenuObj;
    public MainMenu mainMenu;

    //Waluta do gry
    public float currentMoneyQuantity;

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
        HealthBar.SetHealth(Player.CurrentHealth());
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void GameOver()
    {
    }
}