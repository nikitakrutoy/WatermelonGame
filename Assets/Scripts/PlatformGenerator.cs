using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{

    public Transform generationPoint;
    public GameObject platform;
    public float distance;
    private float platformWidth;
    // Start is called before the first frame update
    void Start()
    {
        platformWidth = platform.GetComponent<BoxCollider>().size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(
                position.x + platformWidth + distance, position.y, position.z);

            Instantiate(platform, transform.position, transform.rotation);
        }
    }
}
