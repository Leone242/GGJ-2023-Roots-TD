using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWolf : MonoBehaviour
{
    private float hp = 1;
    [SerializeField]
    private float speed = 5;
    [SerializeField]
    private float damage = 2;
    private GameObject target;
    private float targetDistance;
    private Vector3 tDirection;
    private Vector3 targetPosition;
    [HideInInspector]
    public Spawner spawner;
    private Rigidbody rb;
    private Door door;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Door");
        targetPosition = target.transform.position;

    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(targetPosition);
        rb.rotation = rotation;

        targetDistance = Vector3.Distance(transform.position, targetPosition);

        tDirection = targetPosition - transform.position;

        if(targetDistance > 2)
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
        door.TakeDamage(damage);
    }


    public void MoveToTarget()
    {
        rb.MovePosition(transform.position + tDirection.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Rock")
        {
            float dmg = Random.Range(2, 4);
            TakeDamage(dmg);
        }
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            this.enabled = false;
            Destroy(gameObject);
            //spawner.KillEnemies();
        }
    }
}
