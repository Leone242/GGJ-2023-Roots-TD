using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoldier : MonoBehaviour
{
    public void Spawn(GameObject soldier)
    {
        Vector3 pos = Random.insideUnitSphere * 2;
        pos += transform.position;
        pos.y = 0;

        Instantiate(soldier, pos, Quaternion.identity);
    }
}
