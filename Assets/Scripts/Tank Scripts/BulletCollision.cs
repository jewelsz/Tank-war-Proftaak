using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    int count = 0;

    [SerializeField] private SpawnPoint spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") && !this.CompareTag("Tank"))
        {
            Debug.Log("TANK HIT: " + count);
            count++;
            spawnPoint.Respawn();
        }
    }

}

