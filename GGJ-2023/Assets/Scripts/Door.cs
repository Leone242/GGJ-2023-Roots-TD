using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float hp;
    [SerializeField]
    public GameObject Panel;


    public void Start()
    {
        hp = 50;
    }
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            Panel.GetComponent<PanelController>().EndGame();
            gameObject.SetActive(false);    
        }
    }
}
