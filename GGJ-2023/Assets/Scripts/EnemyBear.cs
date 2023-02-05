using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBear : MonoBehaviour
{
    public GameObject Spawner;
    public float hp = 8;
    [SerializeField]
    private float speed = 3;
    private float damage;
    public GameObject target;
    private float targetDistance;
    private Vector3 tDirection;
    private Vector3 targetPosition;
    private Rigidbody rb;
    private float timer = 0;
    private float timeAtack = 4;
    private GameObject tree;
    private GameObject door;
    private GameObject pillbox;
    private GameObject tower;
    private GameObject soldier;
    [SerializeField]
    public AudioClip ac;
    [SerializeField]
    public AudioClip acHit;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();

        tree = GameObject.FindWithTag("Tree");
        door = GameObject.FindWithTag("Door");
        tower = GameObject.FindWithTag("Tower");
        pillbox = GameObject.FindWithTag("Pillbox");
        soldier = GameObject.FindWithTag("Soldier");
    }

    private void FixedUpdate()
    {
        
        target = FindTarget();
        

        targetPosition = target.transform.position;
        tDirection = targetPosition - transform.position;

        Quaternion rotation = Quaternion.LookRotation(tree.transform.position);
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

    }

    private GameObject FindTarget()
    {
        if (pillbox)
        {
            target = pillbox;
        }
        else if (!pillbox && tower)
        {
            target = tower;
        }
        else if (soldier)
        {
            target = soldier;
        }
        else
        {
            target = door;
        }
        return target;
    }

    public void Atack(float damage)
    {
        AudioController.AudioInstance.PlayOneShot(acHit);
        target = FindTarget();
        if (target == door)
        {
            target.GetComponent<Door>().TakeDamage(damage);
        }
        else if (target == pillbox)
        {
            target.GetComponent<Pillbox>().TakeDamage(damage);
        }
        else if (target == tower)
        {
            target.GetComponent<Tower>().TakeDamage(damage);
        } 
        else if (target == soldier)
        {
            target.GetComponent<Soldier>().TakeDamage(damage + 2);
        }
    }


    public void MoveToTarget(GameObject target)
    {
        rb.MovePosition(transform.position + 
            tDirection.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Rock")
        {
            float dmg = Random.Range(1, 3);
            TakeDamage(dmg);
        }
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            AudioController.AudioInstance.PlayOneShot(ac);
            Spawner.GetComponent<Spawner>().EnemyKilled();
            Destroy(gameObject, 1);

        }
    }
}

