using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour, IEnemy
{
    private float hp = 10;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float damage = 2;
    private float damageTaken;
    private LayerMask fortress;
    private GameObject door;
    private GameObject pillbox;
    private float distance;
    private Vector2 direction;
    [HideInInspector]
    public Spawner spawner;

    private void Start()
    {
        door = GameObject.FindWithTag("Door");
        pillbox = GameObject.FindWithTag("Pillbox");

    }

    private void Update()
    {
        
    }

    public void TakeDamage()
    {
        hp -= damageTaken;
        if(hp <= 0)
        {
            this.enabled = false;
            Destroy(gameObject);
            spawner.KillEnemies();
        }
    }


    public void MoveToTarget()
    {
        throw new System.NotImplementedException();
    }

    public void Atack(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void FindNearestTarget()
    {
        throw new System.NotImplementedException();
    }
}
