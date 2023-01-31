using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
    void TakeDamage();
    void MoveToTarget();
    void Atack(float damage);
    void FindNearestTarget();
}
