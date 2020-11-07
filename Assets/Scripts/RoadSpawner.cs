using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float offset = 60f;
    private float spawnOffset = 60f / 4;
    [SerializeField] private List<GameObject> road_list;
    [SerializeField] private int coinSpawnCounter = 2;
    [SerializeField] private GameObject grassSpawner;

    [SerializeField] private GameObject coinSpawner;
    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject emptySpawner;
    [SerializeField] private GameObject obstacleSpawner;

    private List<EventManager> spawnedEvents = new List<EventManager>();
    private CoinManager coinManager;
    private EnemyManager enemyManager;
    private EmptyManager emptyManager;
    private ObstacleManager obstacleManager;

    private void Start()
    {
        coinManager = coinSpawner.GetComponent<CoinManager>();
        enemyManager = enemySpawner.GetComponent<EnemyManager>();
        emptyManager = emptySpawner.GetComponent<EmptyManager>();
        obstacleManager = obstacleSpawner.GetComponent<ObstacleManager>();

        spawnedEvents.Add(emptyManager);
        spawnedEvents.Add(emptyManager);
        spawnedEvents.Add(emptyManager);
        spawnedEvents.Add(emptyManager);

        for (int i = 2; i < road_list.Count; i++)
        {
            GameObject platform = road_list[i];
            spawnEvent(platform.transform.position.x, platform.transform.position.z - spawnOffset);
            spawnEvent(platform.transform.position.x, platform.transform.position.z + spawnOffset);
        }

    }

    public void MoveRoad()
    {
        GameObject moveRoad = road_list[0];
        road_list.Remove(moveRoad);
        grassSpawner.GetComponent<GrassSpawner>().DestroySpawnedPair();

        removeEvent();
        removeEvent();

        float newZ = road_list[road_list.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(moveRoad.transform.position.x, moveRoad.transform.position.y, newZ);
        road_list.Add(moveRoad);

        spawnEvent(moveRoad.transform.position.x, moveRoad.transform.position.z - spawnOffset);
        spawnEvent(moveRoad.transform.position.x, moveRoad.transform.position.z + spawnOffset);

        grassSpawner.GetComponent<GrassSpawner>().Spawn();
        grassSpawner.GetComponent<GrassSpawner>().Spawn();
    }

    void spawnEvent(float x, float y)
    {
        int eventChoice = Random.Range(0, 4);
        
        switch (eventChoice)
        {
            case 0: {
                    coinManager.Spawn(x, y);
                    spawnedEvents.Add(coinManager);
                    break;
                }
            case 1:
                {
                    enemyManager.Spawn(x, y);
                    spawnedEvents.Add(enemyManager);
                    break;
                }
            case 2:
                {
                    obstacleManager.Spawn(x, y);
                    spawnedEvents.Add(obstacleManager);
                    break;
                }
            case 3:
                {
                    spawnedEvents.Add(emptyManager);
                    break;
                }
        }
    }
    
    void removeEvent()
    {
        if (spawnedEvents.Count >= 1)
        {
            EventManager ev = spawnedEvents[0];
            spawnedEvents.Remove(ev);
            ev.Remove();
        }
    }
}
