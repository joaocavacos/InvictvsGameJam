using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{

    public float damage;
    public float speed;
    public float stopRange;
    public float chargeRange;
    private AIPath _aiPath;
    private AIDestinationSetter _aiDestinationSetter;
    public EnemyState state;
    public UnityEvent<EnemyState> OnChangeState = new UnityEvent<EnemyState>();
    public bool isDead;
    public Animator animator;
    public Rigidbody2D rb;

    [SerializeField] private float rotationSpeed=10f;
    Vector2 dir;
    float angle;
    private void Update()
    {
        if (!isDead)
        {
            dir = (Player.instance.transform.position - transform.position).normalized;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _aiPath = GetComponent<AIPath>();
        _aiDestinationSetter = GetComponent<AIDestinationSetter>();
        _aiDestinationSetter.target = Player.instance.transform;
        _aiPath.maxSpeed = speed;
        _aiPath.slowdownDistance = stopRange;
        _aiPath.endReachedDistance = stopRange;
        isDead = false;
    }

    public void ChangeState(EnemyState s)
    {
        state = s;
        OnChangeState?.Invoke(s);
    }
    public void Kill()
    {
        isDead = true;
        _aiPath.enabled = false;
        GetComponent<EnemyAttack>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        animator.SetTrigger("ChangeToDead");
    }

}
public enum EnemyState
{
    IDLE,
    READY,
    ATTACK,
    DEAD
}