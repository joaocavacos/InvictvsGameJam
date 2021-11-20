using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{

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
        enemy.bodyRenderer.color = new Color(enemy.bodyRenderer.color.r, enemy.bodyRenderer.color.g, enemy.bodyRenderer.color.b, 0.5f);
        yield return new WaitForSeconds(0.2f);
        enemy.bodyRenderer.color = new Color(enemy.bodyRenderer.color.r, enemy.bodyRenderer.color.g, enemy.bodyRenderer.color.b, 1f);
    }
}
