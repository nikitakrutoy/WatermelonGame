using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : EventManager
{
    [SerializeField] private GameObject[] enemies;
    private List<GameObject> spawned_enemies = new List<GameObject>();
    private float height = 1f;
    public override void Remove()
    {
        if (spawned_enemies.Count >= 1)
        {
            GameObject removeObj = spawned_enemies[0];

            spawned_enemies.Remove(removeObj);

            Destroy(removeObj);
        }
    }

    public override void Spawn(float x, float y)
    {
        GameObject enemy = enemies[Random.Range(0, enemies.Length)];
        GameObject spawnedEnemy = Instantiate(enemy, new Vector3(x, height, y), Quaternion.identity);
        spawned_enemies.Add(spawnedEnemy);
    }

}
