using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;     

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private GameObject ceilSky;
    private float jumpHeight = 10f;
    private float skyHeight;
    private Rigidbody rb;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        skyHeight = ceilSky.transform.position.y;
    }

    private void Update()
    {
        float yMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(0, 0, yMovement) * Time.deltaTime);
        ceilSky.transform.position = new Vector3(transform.position.x, skyHeight, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

    }
}
