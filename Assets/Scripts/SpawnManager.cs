using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private RoadSpawner spawner;

    void Start()
    {
        spawner = GetComponent<RoadSpawner>();
    }

    // Update is called once per frame

    public void Spawn()
    {
        spawner.MoveRoad();
    }
}
