using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    private float offset = 60f;
    [SerializeField] private List<GameObject> road_list;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRoad()
    {
        GameObject moveRoad = road_list[0];
        road_list.Remove(moveRoad);

        moveRoad.GetComponent<CoinManager>().Remove();

        float newZ = road_list[road_list.Count - 1].transform.position.z + offset;
        moveRoad.transform.position = new Vector3(moveRoad.transform.position.x, moveRoad.transform.position.y, newZ);
        road_list.Add(moveRoad);
        moveRoad.GetComponent<CoinManager>().Spawn();
    }
}
