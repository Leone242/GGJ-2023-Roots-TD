using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : MonoBehaviour
{
    private float hp = 1;
    [SerializeField]
    private float speed = 3;
    private float damage;
    private float damageTaken;
    private GameObject target;
    private float spawnDistance;
    private float targetDistance;
    private Vector3 tDirection;
    private Vector3 targetPosition;
    [HideInInspector]
    public Spawner spawner;
    private Rigidbody rb;
    private float timer = 0;
    private float timeAtack = 4;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("Pillbox") == true)
        {
            target = GameObject.FindWithTag("Pillbox");
        }   
        else
        {
            target = GameObject.FindWithTag("Door");
        }

        Quaternion rotation = Quaternion.LookRotation(targetPosition);
        rb.rotation = rotation;

        targetDistance = Vector3.Distance(transform.position, targetPosition);

        if (targetDistance > 2)
        {
            MoveToTarget(target);
        }
        else if (targetDistance <= 1)
        {
            damage = Random.Range(3, 5);
            timer += Time.deltaTime;
            if (timer > timeAtack)
            {
                Atack(damage);
                timer = 0;
            }
        }

        targetPosition = target.transform.position;
        tDirection = targetPosition - transform.position;
    }

    public void Atack(float damage)
    {
        if(target.tag == "Door")
        {
            target.GetComponent<Door>().TakeDamage(damage);
        }
        else if(target.tag == "Pillbox")
        {
            target.GetComponent<Pillbox>().TakeDamage(damage);
        }
    }


    public void MoveToTarget(GameObject target)
    {
        rb.MovePosition(transform.position + tDirection.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Rock")
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
