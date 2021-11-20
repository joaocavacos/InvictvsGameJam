using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    private PlayerHealth playerHealth;
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
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
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
            if (hitInfo.collider.CompareTag("Player") && hitInfo.collider != null)
            {
                Debug.Log("Player hit");
                playerHealth.TakeDamage(enemy.damage);
                DestroyArrow();
            }
        }
    }

    public void DestroyArrow()
    {
        Destroy(gameObject);
    }
}
