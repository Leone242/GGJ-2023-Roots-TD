using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    [SerializeField]
    private GameObject Rock;
    [SerializeField]
    private GameObject ObjThrower;
    private float timer = 0;
    private float frequency = 2;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > frequency)
        {
            ThrowRock();
            timer = 0;
        }
    }

    private void ThrowRock()
    {
        Instantiate(Rock, transform.position, transform.rotation);
    }

}
