using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;

    public void Spawn()
    {
        player.transform.position = spawnPoint.transform.position;
    }

    //Respawn na 3 seconde
    public void Respawn()
    {
        Debug.Log("Respawn Triggered");
        player.SetActive(false);
        StartCoroutine(WaitForRespawn());
    }

    public void setSpawnPoint(Transform spawn)
    {
        //Spawnpoint dat de speler toegewezen krijgt aan het begin van het spel
        //Voor multiplayer. Dus random spawnpoint?
    }


    IEnumerator WaitForRespawn()
    {
        yield return new WaitForSeconds(3);
        player.SetActive(true);
        player.transform.position = spawnPoint.transform.position;
    }
}
