using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;

public class MeeleAttack : EnemyAttack
{

    [SerializeField] Enemy enemy;
    private float currentCooldown;
    private float currentAtkCooldown;
    [SerializeField] float AttackCooldown;
    private float ChargeDuration = 0.5f;
    [SerializeField] float attackRadius;
    [SerializeField] LayerMask playerMask;
    [SerializeField] private Transform attackPos;
    private bool charging = false;

    private void Awake()
    {
        currentCooldown = ChargeDuration;
        currentAtkCooldown = AttackCooldown;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.instance.transform.position) < enemy.chargeRange && !charging && currentAtkCooldown < 0)
        {
            //Charge
            enemy.animator.SetTrigger("ChangeToCharge");
            charging = true;
        }

        if (currentCooldown > 0 && charging)
        {
            currentCooldown -= Time.deltaTime;
        }
        else if (currentAtkCooldown > 0)
        {
            currentAtkCooldown -= Time.deltaTime;
        }

        if (currentCooldown <= 0)
        {
            enemy.animator.SetTrigger("ChangeToAttack");

            Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRadius, playerMask);
            //Debug.Log($"{gameObject.name} can attack {playerToDamage.Length} players");
            for (int i = 0; i < playerToDamage.Length; i++)
            {
                //Attack player
                playerToDamage[i].GetComponent<PlayerHealth>().TakeDamage(enemy.damage);
            }

            charging = false;
            currentCooldown = ChargeDuration;
            currentAtkCooldown = AttackCooldown;
        }


    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPos.position, attackRadius);
    }
    /*

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
            //CAN ATTACK
            if (Vector2.Distance(transform.position, target.position) <= enemy.stopRange && target != null)
            {
                //IN RANGE - ATTACKS
                Collider2D[] playerToDamage = Physics2D.OverlapCircleAll(attackPos.position, enemy.stopRange, playerMask);
                //Debug.Log($"{gameObject.name} can attack {playerToDamage.Length} players");
                for (int i = 0; i < playerToDamage.Length; i++)
                {
                    //Attack player
                    Player.instance.healthSystem.TakeDamage(enemy.damage);
                }
                timeBetweenAttack = startTimeBetweenAttack;
            }

            
        }
        else
        {
            //COOLDOWN
            timeBetweenAttack -= Time.deltaTime;
            if (1f >= timeBetweenAttack)
            {
                StartCoroutine(GoingToAttack());
            }
        }
        
    }
    private IEnumerator GoingToAttack()
    {
        //enemy.bodyRenderer.color = new Color(enemy.bodyRenderer.color.r, enemy.bodyRenderer.color.g, enemy.bodyRenderer.color.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        //enemy.bodyRenderer.color = new Color(enemy.bodyRenderer.color.r, enemy.bodyRenderer.color.g, enemy.bodyRenderer.color.b, 1f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, enemy.chargeRange);
    }
    */
}


