//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private float hp = 12;
    private float damage;
    private float speed = 2;
    private Rigidbody rb;
    public GameObject enemy;
    public GameObject enemySpawner;
    private Vector3 enemyPosition;
    private Vector3 enemyDirection;
    private float enemyDistance;
    [SerializeField]
    private GameObject Rock;
    private float timer = 0;
    private int frequency = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        enemySpawner = GameObject.FindWithTag("Spawner");
        if(GameObject.FindGameObjectWithTag("Enemy") == true)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemyPosition = enemy.transform.position;
            enemyDistance = Vector3.Distance(transform.position, enemyPosition);
            Quaternion rotation = Quaternion.LookRotation(enemyPosition);
            rb.rotation = rotation;
            enemyDirection = enemyPosition - transform.position;
        }

        if (enemyDistance > 1 && enemy != null)
        {
            MoveToEnemy();            
        }
        else if(enemyDistance <= 1 && enemy != null)
        {
            damage = Random.Range(3, 5);
            timer += Time.deltaTime;
            if (timer > frequency)
            {
                Atack(damage);
                timer = 0;
            }
        }
        else
        {
            transform.position = transform.position;
        }
    }

    public void Atack(float damage)
    {
        if(enemy.name == "EnemyWolf")
        {
            enemy.GetComponent<EnemyWolf>().TakeDamage(damage);

        }
        else if(enemy.name == "EnemyBear")
        {
            enemy.GetComponent<EnemyBear>().TakeDamage(damage); 
        }

    }

    private void MoveToEnemy()
    {
        rb.MovePosition(transform.position +
            enemyDirection.normalized * speed * Time.deltaTime);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
