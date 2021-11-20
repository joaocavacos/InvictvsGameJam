using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private HealthSystem _healthSystem;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    public float arrowSpeed;
    public float disappearTime;
    public float distance;
    public LayerMask isPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
        rb = GetComponent<Rigidbody2D>();
        moveDirection = (player.position - transform.position).normalized * arrowSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Invoke("DestroyArrow", disappearTime);
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, isPlayer);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                Debug.Log("Player hit");
                _healthSystem.TakeDamage(enemy.damage);
                DestroyArrow();
            }
        }
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
