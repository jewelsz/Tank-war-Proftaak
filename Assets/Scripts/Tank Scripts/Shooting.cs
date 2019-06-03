using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    Transform bulletSpawn;

    GameObject bullet;

    float nextFire;
    float fireRate = 0.3f;

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Fire();
        }
    }

    private void Fire()
    {

        bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

    }

    public void setBulletSpawn(Transform playerBulletSpawn)
    {
        bulletSpawn = playerBulletSpawn;
    }

    public void setBulletPrefab(GameObject bullet)
    {
        bulletPrefab = bullet;
    }
}
