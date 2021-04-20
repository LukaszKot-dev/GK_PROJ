using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerController Player;

    public HealthBar HealthBar;

    private void Awake()
    {
        if (!Player) Player = FindObjectOfType<PlayerController>();
        Player.healthUpdated += UpdateHealthBar;
    }

    private void Start()
    {
    }

    private void UpdateHealthBar()
    {
        HealthBar.SetHealth(Player.CurrentHealth());
    }

    // Update is called once per frame
    private void Update()
    {
    }
}