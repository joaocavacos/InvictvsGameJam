using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public float health;

    void Update()
    {
        if (health <= 0) Die();
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
        Debug.Log(this.gameObject.name + " Died");
    }
}