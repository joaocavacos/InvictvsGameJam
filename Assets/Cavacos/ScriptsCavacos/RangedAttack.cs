using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyAttack
{
    [SerializeField] Enemy enemy;
    private float currentCooldown;
    [SerializeField] float attackCooldown;
    public GameObject arrowObj;


    private void Update()
    {

        if (Vector2.Distance(transform.position, Player.instance.transform.position) < enemy.chargeRange)
        {
            //Charge
            enemy.animator.SetTrigger("ChangeToCharge");
        }
        else
        {
            if (currentCooldown <= 0)
            {
                enemy.animator.SetTrigger("ChangeToAttack");
                var arrow = Instantiate(arrowObj, transform.position, transform.rotation).GetComponent<Arrow>();
                arrow.Setup((Player.instance.transform.position - transform.position).normalized, enemy);
                currentCooldown = attackCooldown;
            }
            else
            {

            }

            //Attack
        }
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.deltaTime;
        }
    }
    /*
    private float timeBetweenAttack;
    private Transform target;

    [SerializeField] private Enemy enemy;
    public float startTimeBetweenAttack;
    public GameObject arrowObj;

    void Start()
    {
        target = Player.instance.transform;
    }

    void Update()
    {
        if (timeBetweenAttack <= 0)
        {
            if (Vector2.Distance(transform.position, target.position) <= enemy.stopRange)
            {
                var arrow = Instantiate(arrowObj, transform.position, transform.rotation).GetComponent<Arrow>();
                arrow.Setup((Player.instance.transform.position - transform.position).normalized, enemy);
                timeBetweenAttack = startTimeBetweenAttack;
            }
        }
        else
        {
            
            timeBetweenAttack -= Time.deltaTime;
            if (1f >= timeBetweenAttack)
            {
                StartCoroutine(GoingToAttack());
            }
        }
    }
    private IEnumerator GoingToAttack()
    {
        
        yield return new WaitForSeconds(0.2f);
        
    }
    */

}
