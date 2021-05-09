using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Mine;
    public GameObject Missile;
    public GameObject Coin;

    public float MineRepeatTime = 10f;
    public float MissileRepeatTime = 30f;
    public float CoinRepeatTime = 10f;
    public float MissileRocket = 10f;
    public float MissileRocketSpawnStartTime = 30f;
    public float spawnDistance = 200f;

    private void Start()
    {
        var hardity = (float)GameManager.Instance.DifficultyLevel;
        StartCoroutine(SpawnMineRepeat(1.0f, MineRepeatTime / hardity));
        StartCoroutine(SpawnMissileRepeat(MissileRepeatTime / hardity));
        StartCoroutine(SpawnCoinRepeat(CoinRepeatTime / hardity));
        StartCoroutine(SpawnMissileRocketRepeat(MissileRocket / hardity));
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private IEnumerator SpawnMineRepeat(float size, float repeatRate)
    {
        while (!GameManager.Instance.gameHasEnded)
        {
            SpawnMine(size);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private IEnumerator SpawnCoinRepeat(float repeatRate)
    {
        while (!GameManager.Instance.gameHasEnded)
        {
            SpawnCoin();
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void SpawnCoin()
    {
        var CoinInstance = Instantiate(Coin);
        CoinInstance.transform.position = GameManager.Instance.Player.PositionNear(spawnDistance);
    }

    private IEnumerator SpawnMissileRepeat(float repeatRate)
    {
        while (!GameManager.Instance.gameHasEnded)
        {
            int gameMinute = (int)GameManager.Instance.gameTime / 30 + 1;
            SpawnMissile(gameMinute * 10, gameMinute);
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void SpawnMissile(float speed, float turnSpeed)
    {
        var MissileInstance = Instantiate(Missile);
        MissileInstance.GetComponent<Missile>().rocketFlySpeed = speed;
        MissileInstance.GetComponent<Missile>().turnSpeed = turnSpeed;
        MissileInstance.transform.position = GameManager.Instance.Player.PositionNear(spawnDistance);
    }

    private IEnumerator SpawnMissileRocketRepeat(float repeatRate)
    {
        while (!GameManager.Instance.gameHasEnded)
        {
            Debug.Log("Game Time: " + GameManager.Instance.gameTime);
            if ((int)GameManager.Instance.gameTime > MissileRocketSpawnStartTime)
            {
                int gameMinute = (int)GameManager.Instance.gameTime / 30 + 1;
                SpawnMissileRocket(gameMinute * 10, gameMinute);
            }
            yield return new WaitForSeconds(repeatRate);
        }
    }

    private void SpawnMissileRocket(float speed, float turnSpeed)
    {
        var MissileInstance = Instantiate(Missile);
        MissileInstance.GetComponent<Missile>().rocketFlySpeed = speed;
        MissileInstance.GetComponent<Missile>().turnSpeed = turnSpeed;
        MissileInstance.transform.position = GameManager.Instance.Player.PositionNear(spawnDistance);
    }

    private void SpawnMine(float size)
    {
        var MineInstance = Instantiate(Mine);
        MineInstance.transform.position = GameManager.Instance.Player.PositionNear(spawnDistance);
    }
}