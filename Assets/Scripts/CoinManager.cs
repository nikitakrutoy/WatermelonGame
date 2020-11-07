using System.Collections.Generic;
using UnityEngine;

public class CoinManager : EventManager
{
    [SerializeField] private int coin_number_min = 3;
    [SerializeField] private int coin_number_max = 10;
    [SerializeField] private GameObject coin_prefab;
    private List<GameObject> spawnedCoins = new List<GameObject>();
    private List<int> coinSize = new List<int>();
    private float offset = 2f;
    [SerializeField] private float maxHeight = 5f;
    private int[] spawnChoices = new int[] {1, 2};
    private float minHeight = 1f;


    public override void Spawn(float x, float y)
    {
        float coinY = Random.Range(minHeight, maxHeight);
        int coinNum = Random.Range(coin_number_min, coin_number_max);
        
        switch (Random.Range(0, spawnChoices.Length))
        {
            case 0:
                SpawnInLine(x, y, coinY, coinNum);
                break;
            case 1:
                SpawnInCircle(x, y, coinY, coinNum);
                break;
            default:
                break;
        }

        coinSize.Add(coinNum);
    }

    private void SpawnInLine(float x, float y, float height, int number)
    {
        for (int i = 0; i < number; i++)
        {
            GameObject newCoin = Instantiate(coin_prefab,
                new Vector3(x,
                height,
                y  + i * offset),
                Quaternion.Euler(0f, 45f, 90f));
            spawnedCoins.Add(newCoin);
        }
    }

    private void SpawnInCircle(float x, float y, float height, int number)
    {
        float degStep = 180f / (number + 1);
        float radius = height - minHeight;

        float deg = degStep;
        for (int i = 0; i < number; i++)
        {
            float coinHeight = radius * Mathf.Sin(deg * Mathf.Deg2Rad);
            GameObject newCoin = Instantiate(coin_prefab,
                new Vector3(x,
                minHeight + coinHeight,
                y + i * offset),
                Quaternion.Euler(0f, 45f, 90f));
            spawnedCoins.Add(newCoin);
            deg += degStep;
        }
    }

    public override void Remove()
    {
        int coinSizeRemove = coinSize[0];
        coinSize.RemoveAt(0);

        for (int i = 0; i < coinSizeRemove; i++)
        {
            GameObject coin = spawnedCoins[0];
            spawnedCoins.RemoveAt(0);
            Destroy(coin);
        }
    }
}
