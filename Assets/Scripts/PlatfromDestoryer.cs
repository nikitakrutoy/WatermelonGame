using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromDestoryer : MonoBehaviour
{
    public float margin = 0;
    public Transform platfromDestroyerPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (platfromDestroyerPoint.position.x - transform.position.x > margin) Destroy(gameObject);
    }
}
