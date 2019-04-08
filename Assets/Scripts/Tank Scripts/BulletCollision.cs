using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    [SerializeField] private SpawnPoint spawnPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet") && !this.CompareTag("Player"))
        {
            spawnPoint.Respawn();
        }
    }

}

