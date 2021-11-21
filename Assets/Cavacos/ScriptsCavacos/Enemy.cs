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
    private void Awake()
    {
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
    }

}
public enum EnemyState
{
    IDLE,
    READY,
    ATTACK,
    DEAD
}