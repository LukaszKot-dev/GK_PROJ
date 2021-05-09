using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    public PlayerController Player;
    public GameObject PlayerObject;
    public HealthBar HealthBar;
    public int points;
    public GameObject mainMenuObj;
    private float _currency = 0;
    public float Currency { get { return _currency; } set { _currency = value; Debug.Log("Coins: " + value); PlayerPrefs.SetFloat("Wallet", value); } }
    public MainMenu mainMenu;
    public GameOver GameOver;
    public bool gameHasEnded = false;
    public bool gameHasStarted = false;
    public float gameTime = 0.0f;

    private void Awake()
    {
        LoadData();
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        if (!Player) Player = FindObjectOfType<PlayerController>();

        if (Player)
            Player.healthUpdated += UpdateHealthBar;
    }

    private void LoadData()
    {
        Currency = PlayerPrefs.GetFloat("Wallet");
    }

    private void Start()
    {
        ShowMainMenu();
    }

    private void ShowMainMenu()
    {
        GameObject.Instantiate(mainMenuObj);
    }

    public void StartGame()
    {
        gameTime = 0;
        gameHasStarted = true;
    }

    private void UpdateHealthBar()
    {
        //  HealthBar.SetHealth(Player.CurrentHealth());
    }

    // Update is called once per frame
    private void Update()
    {
        if (gameHasStarted)
            gameTime += Time.deltaTime;
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