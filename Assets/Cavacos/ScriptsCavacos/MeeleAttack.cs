using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;

public class MeeleAttack : MonoBehaviour
{

    private float timeBetweenAttack;
    private Transform target;
    
    [SerializeField] private Enemy enemy;
    public Transform attackPos;
    public float startTimeBetweenAttack;
    public LayerMask playerMask;
    
    
    void Start()
    {
        target = Player.instance.transform;
    }

    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Vector2.Distance(transform.position, target.position) <= enemy.stopRange && target != null)
            {
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, enemy.stopRange, playerMask);
                Debug.Log($"{gameObject.name} can attack {playerToDamage.Length} players");
                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    //Attack player
                    Player.instance.healthSystem.TakeDamage(enemy.damage);
                    Debug.Log("Player attacked by " + this.gameObject.name);
                }
            }

            timeBetweenAttack = startTimeBetweenAttack;
        }
        else
        {
            timeBetweenAttack -= Time.deltaTime;
        }
        
        Debug.Log("Player HP: " + Player.instance.healthSystem.health);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, enemy.attackRange);
    }
}


