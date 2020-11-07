using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;     

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private GameObject sky;
    [SerializeField] private SpawnManager spawner;
    [SerializeField] private float jumpHeight = 5f;
    private Rigidbody rb;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {


        transform.Translate(new Vector3(0, 0, 1) * movementSpeed * Time.deltaTime);
        sky.transform.position = new Vector3(sky.transform.position.x, sky.transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "SpawnTrigger":
                spawner.Spawn();
                break;
            case "Coin":
                other.gameObject.GetComponent<Renderer>().enabled = false;
                break;
            default:
                break;
        }

    
        
    }
}
