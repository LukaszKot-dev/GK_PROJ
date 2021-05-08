using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Mine;
    public GameObject Missile;

    private void Start()
    {
        StartCoroutine(SpawnMineRepeat(1.0f, 1));
        StartCoroutine(SpawnMissileRepeat(10));
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
        MissileInstance.transform.position = GameManager.Instance.Player.PositionNear(500f);
    }

    private void SpawnMine(float size)
    {
        var MineInstance = Instantiate(Mine);
        MineInstance.transform.position = GameManager.Instance.Player.PositionNear(500f);
    }
}