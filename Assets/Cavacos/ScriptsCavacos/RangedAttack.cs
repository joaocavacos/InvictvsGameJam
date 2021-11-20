using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    [SerializeField] Enemy enemy;



    private void Update()
    {
        if (Vector2.Distance(transform.position,Player.instance.transform.position)>=enemy.attackRange)
        {
            //Just walk
        }
        else if (Vector2.Distance(transform.position, Player.instance.transform.position) < enemy.attackRange 
            && Vector2.Distance(transform.position, Player.instance.transform.position) > enemy.stopRange)
        {
            //Charge
        }
        else
        {
            //Attack
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
