using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private SpawnPoint spawnpoint;

    void Start()
    {
        spawnpoint.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
