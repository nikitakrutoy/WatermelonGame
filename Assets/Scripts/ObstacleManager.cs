using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : EventManager
{
    [SerializeField] private GameObject obstacle;
    private List<GameObject> spawned_obstacles = new List<GameObject>();
    private float height = 1f;
    public override void Remove()
    {
        if (spawned_obstacles.Count >= 1)
        {
            GameObject removeObj = spawned_obstacles[0];

            spawned_obstacles.Remove(removeObj);

            Destroy(removeObj);
        }
    }

    public override void Spawn(float x, float y)
    {
        GameObject spawnedEnemy = Instantiate(obstacle, new Vector3(x, height, y), Quaternion.Euler(0, 0, 90f));
        spawned_obstacles.Add(spawnedEnemy);
    }

}
