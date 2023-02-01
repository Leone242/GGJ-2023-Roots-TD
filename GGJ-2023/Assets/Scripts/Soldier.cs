using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private float hp = 12;
    [SerializeField]
    private float damage = 2;
    private Rigidbody rb;
    private GameObject enemy;
    private Vector3 enemyPosition;
    [SerializeField]
    private GameObject Rock;
    private float timer = 0;
    private int frequency = 2;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }


    private void FixedUpdate()
    {
        if(GameObject.FindGameObjectWithTag("Enemy") == true)
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            enemyPosition = enemy.transform.position;
            Quaternion rotation = Quaternion.LookRotation(enemyPosition);
            rb.rotation = rotation;
        }
    }
}
