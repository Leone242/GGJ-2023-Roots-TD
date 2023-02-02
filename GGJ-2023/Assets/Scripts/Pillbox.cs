using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillbox : MonoBehaviour
{
    public float hp = 30;
    private bool destroyed = false;
    
    public void TakeDamage(float damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            destroyed = true;
            Destroy(gameObject);
        }
    }
}
