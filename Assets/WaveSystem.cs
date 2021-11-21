using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Random = UnityEngine;
public class WaveSystem : MonoBehaviour
{
    [Header("Wave")]
    public List<Transform> spawnPoints = new List<Transform>();
    private int currentWave;
    [Header("Enemies")]
    public List<GameObject> typesOfEnemies = new List<GameObject>();
    private int amountToSpawn;
    private List<Enemy> enemiesSpawned = new List<Enemy>();
    [SerializeField] int limitEnemiesAlive;
    bool canSpawn;

    [Header("Screens")]
    [SerializeField] private TextMeshProUGUI enemiesAlive;
    public GameObject introScreen;
    public GameObject nextWaveScreen;
    

    private void Start()
    {
        currentWave = 0;
        //Show Intro
        StartCoroutine(ShowIntro());
    }
    private void Update()
    {
        if (canSpawn)
        {
            Spawn();
            Checker();
            enemiesAlive.text = enemiesSpawned.Count(e => !e.isDead).ToString();
        }
    }

    private IEnumerator ShowIntro()
    {
        //Show intro
        enemiesAlive.gameObject.SetActive(false);
        nextWaveScreen.SetActive(false);
        introScreen.SetActive(true);
        yield return new WaitForSeconds(1f);
        introScreen.SetActive(false);
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
        amountToSpawn = currentWave + Mathf.RoundToInt( currentWave * 0.5f);
        //Show wave
        enemiesAlive.gameObject.SetActive(false);
        nextWaveScreen.SetActive(true);
        nextWaveScreen.transform.Find("text").GetComponent<TextMeshProUGUI>().text = $"WAVE {currentWave}";
        yield return new WaitForSeconds(4f);
        enemiesAlive.gameObject.SetActive(true);
        nextWaveScreen.SetActive(false);


        //Disable Wave and Spawn
        canSpawn = true;
    }
    private void Spawn()
    {
        if (enemiesSpawned.Count(e=> !e.isDead)<limitEnemiesAlive && enemiesSpawned.Count()< amountToSpawn)
        {
            var enemie = Instantiate(typesOfEnemies[UnityEngine.Random.Range(0, Mathf.Min(typesOfEnemies.Count-1,(int)(currentWave/2)))]).GetComponent<Enemy>();
            enemie.transform.position = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)].position;
            enemiesSpawned.Add(enemie);            
        }
    }
    private void Checker()
    {
        if (enemiesSpawned.Count(e=>e.isDead)>=amountToSpawn)
        {
            canSpawn = false;
            StartCoroutine(NextWave());
        }
    }
}
