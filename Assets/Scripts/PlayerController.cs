using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;     

public class PlayerController : MonoBehaviour
{
    public float force = 10;
    public GameObject projectile;
    private float nextActionTime = 0.0f;
    public float period = 0.1f;
    private Rigidbody _rigidbody;               
    // Start is called before the first frame update

    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 spawnPostion = transform.position;
        if (Input.GetKey("space") || Input.touchCount >= 1)
        {
            _rigidbody.AddForce(new Vector3(0, force, 0));
            if (Time.time > nextActionTime ) {
                nextActionTime += period;
                Instantiate(projectile, spawnPostion, Quaternion.identity);
            }
        }
    }
}
