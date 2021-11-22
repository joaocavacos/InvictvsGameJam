using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float health;
    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        //Debug.Log($"Health {health}");
        if (health <= 0.001f) Die(damage);
    }

    public virtual void Die(float damage)
    {
        Destroy(gameObject);
        Debug.Log(this.gameObject.name + " Died");
    }
}
