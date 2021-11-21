using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Enemy enemy;
    private Rigidbody2D rb;
    private Collider2D collider;
    private Vector2 moveDirection;
    
    public float arrowSpeed;
    public float disappearTime;
    public float distance;
    public LayerMask isPlayer;
    private bool gaveDamage;
    private float currentTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }
    public void Setup(Vector2 dir, Enemy e)
    {
        enemy = e;
        moveDirection = dir.normalized * arrowSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        currentTime = 0f;
    }

    void Update()
    {
        if (!gaveDamage)
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, moveDirection.normalized, distance, isPlayer);
            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.GetComponent<Player>() && hitInfo.collider != null)
                {
                    
                    Debug.Log($"Player State: {Player.instance.state}");
                    if (Player.instance.state == States.BLOCK || Player.instance.state == States.ROLL)
                    {
                        DestroyArrow();                        
                    }
                    else if(Player.instance.state == States.IDLE || Player.instance.state == States.ATK)
                    {
                        transform.parent = Player.instance.body.transform;
                        rb.velocity = Vector2.zero;
                        rb.isKinematic = true;
                        collider.enabled = false;
                        gaveDamage = true;
                        currentTime = 0f;
                    }
                    Player.instance.healthSystem.TakeDamage(enemy.damage);
                    //DestroyArrow();
                }
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
