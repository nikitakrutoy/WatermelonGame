﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;     
using ArduinoBluetoothAPI;

public class PlayerController : MonoBehaviour
{
    public int sensorThreshold = 70;
    
    
    [SerializeField] private float movementSpeed = 6f;
    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject roadManager;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private Material playerMat;
    [SerializeField] private GameObject particles;
    private Rigidbody rb;
    private SpawnManager spawner;
    private bool isGrounded = true;
    private bool isSqueezed = false;

    private BluetoothController _btController;
    
    private void Start()
    {
        _btController = gameObject.GetComponent<BluetoothController>();
        rb = gameObject.GetComponent<Rigidbody>();
        spawner = roadManager.GetComponent<SpawnManager>();
        particles.SetActive(false);
    }

    private void Update()
    {
        if (_btController.btHelper.isConnected())
        {
            transform.Translate(new Vector3(0, 0, 1) * movementSpeed * Time.deltaTime);
            sky.transform.position = new Vector3(sky.transform.position.x, sky.transform.position.y, transform.position.z);
        }
        
        if (_btController.btHelper.Available)
        {
            byte[] recv = _btController.btHelper.ReadBytes();
            // float ratio = (float)(recv[0] * 1) / 255;
            if (recv[0] * 1 > sensorThreshold)
                rb.AddForce(new Vector3(0, jumpHeight, 0));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSqueezed = true;
            particles.SetActive(true);

        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0));
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSqueezed = false;
            particles.SetActive(false);
        }

    }

    IEnumerator OnEnemyFade(float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            Color textureColor = playerMat.color;
            textureColor.a = Mathf.Sin(Time.time * 5.0f);
            playerMat.color = textureColor;
            yield return null;
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
                Vector3 oldPos = other.gameObject.transform.position;
                other.gameObject.transform.position = new Vector3(oldPos.x, -10, oldPos.z);
                break;
            case "Enemy":
                StartCoroutine(OnEnemyFade(1f));
                break;
            default:
                break;
        }

    
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ground" && isSqueezed == false)
        {
            if (!isGrounded)
            {
                isGrounded = true;
                GetComponent<Animator>().SetBool("isRun", true);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground" && isSqueezed == true)
        {
            if (isGrounded)
            {
                isGrounded = false;
                GetComponent<Animator>().SetBool("isRun", false);
            }
        }
    }
}
