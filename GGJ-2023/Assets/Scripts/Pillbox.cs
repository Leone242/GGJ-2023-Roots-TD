using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillbox : MonoBehaviour
{
    public float hp = 30;
    [SerializeField]
    public GameObject Panel;
    [SerializeField]
    public GameObject MoleSoldier;
    private Rigidbody rb;
    private int maxSoldier = 3;
    private int n = 0;
    [SerializeField]
    public GameObject SpawnPoint;
    private float timer;
    private float t = 4;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (gameObject.active && n < maxSoldier)
        {
                SpawnMole(MoleSoldier);
        }
    }

    private void SpawnMole(GameObject soldier)
    {
        
        if(timer > t)
        {

            SpawnPoint.GetComponent<SpawnSoldier>().Spawn(soldier);
            timer = 0;
            n++;
        }
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
