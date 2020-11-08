using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] grass_prefabs;
    private List<GameObject> spawned_grasses = new List<GameObject>();
    private float Xright = 50f;
    private float Xleft = -50f;
    private float Zbegin = -30f;
    private float size = 30f;
    private int initCount = 15;

    void Start()
    {
        for (int i = 0; i < initCount; i++)
        {
            Spawn();
        }
    }

    public int GetInitCount()
    {
        return initCount;
    }

    // Update is called once per frame
    public void Spawn()
    {
        GameObject left = grass_prefabs[Random.Range(0, grass_prefabs.Length)];
        GameObject right = grass_prefabs[Random.Range(0, grass_prefabs.Length)];

        GameObject spawnedLeft = Instantiate(left, new Vector3(Xleft, 0, Zbegin), Quaternion.identity);
        GameObject spawnedRight = Instantiate(right, new Vector3(Xright, 0, Zbegin), right.transform.rotation * Quaternion.Euler(0f, 180f, 0f));

        spawned_grasses.Add(spawnedLeft);
        spawned_grasses.Add(spawnedRight);

        Zbegin += size;
    }

    public void DestroySpawnedPair()
    {
        if (spawned_grasses.Count >= 2)
        {
            GameObject removeLeft = spawned_grasses[0];
            GameObject removeRight = spawned_grasses[1];

            spawned_grasses.Remove(removeLeft);
            spawned_grasses.Remove(removeRight);

            Destroy(removeLeft);
            Destroy(removeRight);
        }
    }
}
