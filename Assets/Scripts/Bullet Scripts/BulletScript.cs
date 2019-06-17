using BattleTanks.Client;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 6f;
    [SerializeField] Rigidbody rb;

    private void Start()
    {
        //
        _ = new Client().RunAsync((message) => Debug.Log(message)).ContinueWith(completedTask =>
        {
            Debug.Log("Done running Client.");

            if (completedTask.IsFaulted)
                Debug.LogError(completedTask.Exception.Flatten().Message);
        });
        Debug.Log("Running Client.");
        rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Tank") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    
}

