using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : MonoBehaviour, IEnemy
{
    private float hp = 15;
    [SerializeField]
    private float speed = 3;
    [SerializeField]
    private float damage = 2.5f;
    private float damageTaken;
    private GameObject target;
    private float spawnDistance;
    private float targetDistance;
    private Vector3 tDirection;
    private Vector3 targetPosition;
    [HideInInspector]
    public Spawner spawner;
    private Rigidbody rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Pillbox");
        targetPosition = target.transform.position;

    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        targetDistance = Vector3.Distance(transform.position, targetPosition);

        tDirection = targetPosition - transform.position;

        if (targetDistance > 2)
        {
            MoveToTarget();
        }
        else if(targetDistance <= 1)
        {
            Atack(damage);
        }

    }
    public void Atack(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void FindNearestTarget()
    {
        throw new System.NotImplementedException();
    }

    public void MoveToTarget()
    {
        rb.MovePosition(transform.position + tDirection.normalized * speed * Time.deltaTime);
    }

    public void TakeDamage()
    {
        hp -= damageTaken;
        if (hp <= 0)
        {
            this.enabled = false;
            Destroy(gameObject);
            //spawner.KillEnemies();
        }
    }

}
