using System;
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
    private bool isGrounded = true;
    private bool isSqueezed = false;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        spawner = roadManager.GetComponent<SpawnManager>();
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * movementSpeed * Time.deltaTime);
        sky.transform.position = new Vector3(sky.transform.position.x, sky.transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSqueezed = true;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0));
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isSqueezed = false;
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
