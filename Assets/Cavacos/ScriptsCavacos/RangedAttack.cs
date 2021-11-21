using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyAttack
{
    [SerializeField] Enemy enemy;
    private float currentCooldown;
    [SerializeField] float ChargeCooldown;
    public GameObject arrowObj;
    private bool charging = false;
    private float currentAtkCooldown;
    [SerializeField] float AttackCooldown;

    public AudioSource soundSource;
    public AudioClip arrowSendSound;

    private void Awake()
    {
        currentCooldown = ChargeCooldown;
        currentAtkCooldown = AttackCooldown;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, Player.instance.transform.position) < enemy.chargeRange && currentAtkCooldown <= 0 && !charging)
        {
            //Charge
            enemy.animator.SetTrigger("ChangeToCharge");
            charging = true;
        }
        else
        {
            if (currentCooldown <= 0 && charging)
            {
                // enemy.animator.SetTrigger("ChangeToAttack");
                soundSource.PlayOneShot(arrowSendSound);
                var arrow = Instantiate(arrowObj, transform.position, transform.rotation).GetComponent<Arrow>();
                arrow.Setup((Player.instance.transform.position - transform.position).normalized, enemy);
                currentCooldown = ChargeCooldown;
                currentAtkCooldown = AttackCooldown;
                charging = false;
            }

            //Attack
        }
        if (currentCooldown <= 0.8f && charging)
            enemy.animator.SetTrigger("ChangeToAttack");
        if (currentCooldown > 0 && charging)
        {
            currentCooldown -= Time.deltaTime;
        }
        else if (currentAtkCooldown > 0)
        {
            currentAtkCooldown -= Time.deltaTime;
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
