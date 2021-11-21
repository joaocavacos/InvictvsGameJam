using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] Enemy enemy;
    [SerializeField] private float minimumDamage;
    public override void Die()
    {
        //base.Die();
        enemy.Kill();
        
    }
    public override void TakeDamage(float damage)
    {
        if (damage>=minimumDamage)
        {
            base.TakeDamage(damage);
        }
        
    }
}
