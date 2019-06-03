using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;

    private void Start()
    {
        
    }

    public void Spawn()
    {
        transform.position = spawnPoint.transform.position;
    }

    //Respawn na 3 seconde
    public void Respawn(GameObject tank)
    {
        tank.gameObject.SetActive(false);
        StartCoroutine(WaitForRespawn(tank));
    }

    IEnumerator WaitForRespawn(GameObject tank)
    {
        yield return new WaitForSeconds(3);
        tank.gameObject.SetActive(true);
        tank.gameObject.transform.position = spawnPoint.transform.position;
    }
}
