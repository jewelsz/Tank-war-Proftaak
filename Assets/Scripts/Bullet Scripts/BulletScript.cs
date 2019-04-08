using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 6f;
    [SerializeField] Rigidbody rb;

    //public Transform originalObject;
    //public Transform reflectedObject;

    private void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Opponent") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
}

