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
    public GameObject Panel;
    [SerializeField]
    private float timeToSpawn;
    private float timer = 0;
    private float timer2 = 0;
    private int horde = 30;
    private int endHorde = 0;


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
            EnemyWolf.GetComponent<EnemyWolf>().Spawner = gameObject;         
        }
        if(timer2 > timeToSpawn)
        {
            EnemyBear.GetComponent<EnemyBear>().target = Pillbox;
            EnemyBear.GetComponent<EnemyBear>().Spawner = gameObject;

            if (!Pillbox.gameObject.active)
            {
                EnemyBear.GetComponent<EnemyBear>().target = Tower;
            }
            SpawnNewEnemy(EnemyBear);
            timer2 = 0;
        }
    }

    private void SpawnNewEnemy(GameObject enemy)
    {
        if (endHorde <= horde)
        {
            Vector3 spawnPosition = RandomPosition();

            if (spawnPosition.z < 7)
            {
                RandomPosition();
            }
            else
            {
                Instantiate(enemy, spawnPosition, transform.rotation);
                endHorde++;
            }
        }
    }


    private Vector3 RandomPosition()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * 20;
        spawnPosition.y = 0;

        return spawnPosition;
    }

    public void EnemyKilled()
    {
        Panel.GetComponent<PanelController>().KillEnemy();
    }
}
