using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    public float arrowSpeed;
    public float disappearTime;
    public float distance;
    public LayerMask isPlayer;

    private float currentTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Setup(Vector2 dir, Enemy e)
    {
        enemy = e;
        moveDirection = dir.normalized * arrowSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        currentTime = 0f;
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, moveDirection.normalized, distance, isPlayer);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player") && hitInfo.collider != null)
            {
                Player.instance.healthSystem.TakeDamage(enemy.damage);
                DestroyArrow();
            }
        }
        currentTime += Time.deltaTime;
        if (currentTime>=disappearTime)
        {
            //Fazer Pool Depois
            DestroyArrow();
        }
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
