using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float damage;
    public float speed;
    public float health;
    public float attackRange;
    private AIPath _aiPath;
    private AIDestinationSetter _aiDestinationSetter;

    private void Awake()
    {
        _aiPath = GetComponent<AIPath>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _aiDestinationSetter.target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _aiPath.maxSpeed = speed;
        _aiPath.slowdownDistance = attackRange;
        _aiPath.endReachedDistance = attackRange;
    }

    public void TakeDamage(float amount){
        health -= amount;
    }

    public void Die(){
        if(health <= 0){
            Destroy(this.gameObject);
        }
    }

}
