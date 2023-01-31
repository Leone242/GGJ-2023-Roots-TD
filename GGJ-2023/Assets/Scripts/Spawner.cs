//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemyWolf;   
    [SerializeField]
    private GameObject EnemyBear;
    [SerializeField]
    private float timeToSpawn;
    private float timer = 0;
    private float timer2 = 0;
    private int horde = 30;


    void Update()
    {
        timer += Time.deltaTime;    
        timer2 += Time.deltaTime;    
        
        if(timer > timeToSpawn *0.5)
        {
            SpawnNewEnemy(EnemyWolf);
            timer = 0;
        }
        if(timer2 > timeToSpawn)
        {
            SpawnNewEnemy(EnemyBear);
            timer2 = 0;
        }

        if(Time.timeSinceLevelLoad > horde) 
        {
            this.enabled = false;
        }
    }

    private void SpawnNewEnemy(GameObject enemy)
    {
        Vector3 spawnPosition = RandomPosition();

        if(spawnPosition.z < 7) 
        { 
            spawnPosition = RandomPosition();
        }  
        else 
        { 
            Instantiate(enemy, spawnPosition, transform.rotation);
        }
    }


    private Vector3 RandomPosition()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * 50;
        spawnPosition.y = 0;

        return spawnPosition;
    }
}
