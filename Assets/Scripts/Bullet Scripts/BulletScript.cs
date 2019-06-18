using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 6f;
    [SerializeField] Rigidbody rb;

    //public bool delayed { get; set; }

    private void Start()
    {
        rb.velocity = transform.forward * bulletSpeed;
        StartCoroutine(WaitForCollision(1f));
    }

    IEnumerator WaitForCollision(float time)
    {
        yield return new WaitForSeconds(time);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }
   
}

