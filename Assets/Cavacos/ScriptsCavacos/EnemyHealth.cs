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

    public override void Die()
    {
        //base.Die();
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
