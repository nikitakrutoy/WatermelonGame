using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;     

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    private float jumpHeight = 10f;
    private Rigidbody rb;


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float yMovement = Input.GetAxis("Vertical") * movementSpeed;

        transform.Translate(new Vector3(0, 0, yMovement) * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }

    }
}
