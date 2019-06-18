using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    int count = 0;
    [SerializeField] SpawnPoint spawnPoint;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision triggered");
        //bool test = collision.GetComponent<BulletScript>().delayed;
        //Debug.Log(test);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            spawnPoint.Respawn(this.gameObject);
        }
    }
    

}

