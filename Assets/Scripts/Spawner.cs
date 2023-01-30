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
    private float timer;
    private int maxEnemies;
    private int aliveEnemies;
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void KillEnemies()
    {
        aliveEnemies--;
    }
}
