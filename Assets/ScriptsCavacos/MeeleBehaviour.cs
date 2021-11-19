using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleBehaviour : MonoBehaviour
{
    private Enemy enemy;
    public GameObject target;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.LookAt(target.transform);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);
        
        if (Vector3.Distance(transform.position, target.transform.position) > enemy.attackRange) //if distance between player and enemy is greater than enemy attack range keep going for the player
        {
            transform.Translate(new Vector3(enemy.speed * Time.deltaTime, 0, 0));
        }
    }
}
