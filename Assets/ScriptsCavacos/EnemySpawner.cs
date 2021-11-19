using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemiesObj;
    public Transform[] spawnersObj;
    public float spawnTime;

    private bool isSpawned;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (isSpawned) StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        isSpawned = false;
        int enemyIndex = Random.Range(0, 4);
        int spawnIndex = Random.Range(0, 4);
        Instantiate(enemiesObj[enemyIndex], spawnersObj[spawnIndex].position, Quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        isSpawned = true;
    }
    
}
