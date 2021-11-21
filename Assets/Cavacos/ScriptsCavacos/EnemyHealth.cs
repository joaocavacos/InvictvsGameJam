using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    [SerializeField] Enemy enemy;
    [SerializeField] private float minimumDamage;

    private AudioSource soundSource;
    public AudioClip dieSound;

    private void Start()
    {
        soundSource = GameObject.Find("fx").GetComponent<AudioSource>();
    }

    public override void Die(float damage)
    {
        enemy.rb.isKinematic = false;
        enemy.rb.freezeRotation = true;
        enemy.rb.drag = 5f;
        enemy.rb.gravityScale = 0;
        enemy.rb.AddForce((enemy.rb.position-Player.instance.rb2D.position).normalized * ((damage-(minimumDamage+1))*10f), ForceMode2D.Impulse);
        
        soundSource.PlayOneShot(dieSound);
        enemy.Kill();
        
    }
    public override void TakeDamage(float damage)
    {
        if (damage>=minimumDamage)
        {
            base.TakeDamage(damage);
        }
        
    }
}
