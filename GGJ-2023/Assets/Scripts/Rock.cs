using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 8;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider c)
    {
        if(c.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
