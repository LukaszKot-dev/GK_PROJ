using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Mine;
    public GameObject Missile;
    public GameObject Coin;

    public float spawnDistance = 200f;

    private void Start()
    {
        StartCoroutine(SpawnMineRepeat(1.0f, 10));
        StartCoroutine(SpawnMissileRepeat(30));
        StartCoroutine(SpawnCoinRepeat(10));
        StartCoroutine(SpawnMissileRocketRepeat(30));
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
            if ((int)GameManager.Instance.gameTime > 60)
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