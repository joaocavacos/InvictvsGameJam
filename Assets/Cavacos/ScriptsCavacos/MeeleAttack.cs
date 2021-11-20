using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttack : MonoBehaviour
{

    private float timeBetweenAttack;
    private Transform target;
    
    [SerializeField] private Enemy enemy;
    private HealthSystem _healthSystem;
    public Transform attackPos;
    public float startTimeBetweenAttack;
    public LayerMask playerMask;
    
    
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Vector2.Distance(transform.position, target.position) <= enemy.stopRange)
            {
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, enemy.stopRange, playerMask);

                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    //Attack player
                    _healthSystem.TakeDamage(enemy.damage);
                    Debug.Log("Player attacked by " + this.gameObject.name);
                }
            }

            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
        
        Debug.Log("Player HP: " + _healthSystem.health);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, enemy.attackRange);
    }
}


