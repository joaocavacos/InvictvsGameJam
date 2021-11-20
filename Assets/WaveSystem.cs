using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class WaveSystem : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    private int currentWave;
    public List<Enemy> typesOfEnemies = new List<Enemy>();
    private List<Enemy> enemiesAlive = new List<Enemy>();
    private int limitEnemiesAlive;

    private void Start()
    {
        currentWave = 0;
        //Show Intro
        StartCoroutine(ShowIntro());
    }
    private void Update()
    {
        if (enemiesAlive.Count(d=> !d.isDead)<=0)
        {
            //All dead
        }
    }

    private IEnumerator ShowIntro()
    {
        //Show intro
        yield return new WaitForSeconds(1f);
        //Hide intro

        //Show wave
        StartCoroutine(NextWave());
    }
    private IEnumerator NextWave()
    {
        currentWave += 1;
        if (currentWave % 5 ==0)
        {
            limitEnemiesAlive++;
        }
        //Show wave

        yield return new WaitForSeconds(4f);

        //Disable Wave and Spawn
    }
    private void Spawn()
    {

    }
}
