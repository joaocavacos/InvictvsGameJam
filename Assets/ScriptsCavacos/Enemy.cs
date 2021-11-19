using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float damage;
    public float speed;
    public float health;
    public float attackRange;

    public void TakeDamage(float amount){
        health -= amount;
    }

    public void Die(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }

}
