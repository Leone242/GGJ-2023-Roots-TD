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
    private GameObject Door;
    public GameObject Pillbox;
    public GameObject Tower;
    [SerializeField]
    private float timeToSpawn;
    private float timer = 0;
    private float timer2 = 0;
    private int horde = 30;


    private void Awake()
    {
        Pillbox = GameObject.FindWithTag("Pillbox");
        Tower = GameObject.FindWithTag("Tower");
    }
    void Update()
    {
        timer += Time.deltaTime;    
        timer2 += Time.deltaTime;    
        
        if(timer > timeToSpawn *0.5)
        {
            EnemyWolf.GetComponent<EnemyWolf>().target = Door;
            SpawnNewEnemy(EnemyWolf);
            timer = 0;
        }
        if(timer2 > timeToSpawn)
        {
            EnemyBear.GetComponent<EnemyBear>().target = Pillbox;
            if (!Pillbox.gameObject.active)
            {
                EnemyBear.GetComponent<EnemyBear>().target = Tower;
            }
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
            RandomPosition();
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
