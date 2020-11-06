using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{    
    public float force = 10;
    private Rigidbody _rigidbody;

    private bool _oneTime = true;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_oneTime)
        {
            _rigidbody.AddForce(new Vector3(0, -force, 0));
            _oneTime = false;
        }

        if (transform.position.y < 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player") && !other.gameObject.CompareTag("Projectile"))
            Destroy(gameObject);
    }
}