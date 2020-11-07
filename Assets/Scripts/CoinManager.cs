using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private GameObject coinSpawnPoint;
    [SerializeField] private int coin_number;
    [SerializeField] private GameObject coin_prefab;
    private List<GameObject> spawnedCoins = new List<GameObject>();
    private float offset = 2f;

    private void Start()
    {
        Spawn();
    }

    public void Spawn()
    {
        for (int i = 0; i < coin_number; i++)
        {
            GameObject newCoin = Instantiate(coin_prefab, 
                new Vector3(coinSpawnPoint.transform.position.x, 
                coinSpawnPoint.transform.position.y, 
                coinSpawnPoint.transform.position.z + i * offset), 
                Quaternion.identity);
            spawnedCoins.Add(newCoin);
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
