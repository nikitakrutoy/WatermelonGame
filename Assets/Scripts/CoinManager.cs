using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private GameObject coinSpawnPoint;
    [SerializeField] private int coin_number_min = 3;
    [SerializeField] private int coin_number_max = 10;
    [SerializeField] private GameObject coin_prefab;
    private List<GameObject> spawnedCoins = new List<GameObject>();
    private float offset = 2f;
    [SerializeField] private float maxHeight = 5f;
    private int[] spawnChoices = new int[] {1, 2};
    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        float coinY = Random.Range(coinSpawnPoint.transform.position.y, maxHeight);
        int coinNum = Random.Range(coin_number_min, coin_number_max);

        switch (Random.Range(0, spawnChoices.Length))
        {
            case 0:
                SpawnInLine(coinY, coinNum);
                break;
            case 1:
                SpawnInCircle(coinY, coinNum);
                break;
            default:
                break;
        }
    }

    private void SpawnInLine(float height, int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject newCoin = Instantiate(coin_prefab,
                new Vector3(coinSpawnPoint.transform.position.x,
                height,
                coinSpawnPoint.transform.position.z + i * offset),
                Quaternion.identity);
            spawnedCoins.Add(newCoin);
        }
    }

    private void SpawnInCircle(float height, int number)
    {
        float degStep = 180f / (number + 1);
        float radius = height - coinSpawnPoint.transform.position.y;

        float deg = degStep;
        for (int i = 0; i < number; i++)
        {
            float coinHeight = radius * Mathf.Sin(deg * Mathf.Deg2Rad);
            GameObject newCoin = Instantiate(coin_prefab,
                new Vector3(coinSpawnPoint.transform.position.x,
                coinSpawnPoint.transform.position.y + coinHeight,
                coinSpawnPoint.transform.position.z + i * offset),
                Quaternion.identity);
            spawnedCoins.Add(newCoin);
            deg += degStep;
        }
    }

    public void Remove()
    {
        foreach (GameObject coin in spawnedCoins)
        {
            Destroy(coin);
        }
    }
}
