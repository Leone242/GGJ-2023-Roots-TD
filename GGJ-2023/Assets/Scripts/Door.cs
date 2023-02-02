using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private float hp = 50;
    private bool destroyed = false;
    public float damage;
    [SerializeField]
    public GameObject Panel;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Panel.GetComponent<PanelController>().EndGame();

            destroyed = true;
            Destroy(gameObject);
        }
    }
}
