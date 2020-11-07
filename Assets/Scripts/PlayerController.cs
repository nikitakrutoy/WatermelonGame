﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;     

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject roadManager;
    [SerializeField] private float jumpHeight = 10f;
    private Rigidbody rb;
    private SpawnManager spawner;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        spawner = roadManager.GetComponent<SpawnManager>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * movementSpeed * Time.deltaTime);
        sky.transform.position = new Vector3(sky.transform.position.x, sky.transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0));
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
