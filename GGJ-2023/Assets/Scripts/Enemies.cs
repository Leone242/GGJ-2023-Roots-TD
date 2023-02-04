using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float hp = 8;
    public GameObject Spawner;


    private void Start()
    {
        

    }

    private void Update()
    {
        Spawner = GameObject.FindWithTag("Spawner");
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Spawner.GetComponent<Spawner>().EnemyKilled();
            Destroy(gameObject);
            
        }
    }
}
