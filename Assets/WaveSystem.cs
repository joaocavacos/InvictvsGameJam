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
    public List<int> Values = new List<int>();
    [SerializeField] int limitEnemiesAlive;

    [Header("Screens")]
    [SerializeField] private TextMeshProUGUI enemiesAlive;
    public GameObject introScreen;
    public GameObject nextWaveScreen;
    bool waiting;
    public List<Enemy> currents = new List<Enemy>();

    private void Start()
    {
        currentWave = 0;
        //Show Intro
        StartCoroutine(ShowIntro());
    }


    private IEnumerator ShowIntro()
    {
        //Show intro
        enemiesAlive.gameObject.SetActive(false);
        nextWaveScreen.SetActive(false);
        introScreen.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        introScreen.SetActive(false);
        //Hide intro

        //Show wave
        StartCoroutine(NextWave());
        StartCoroutine(CheckAlive());
    }
    private IEnumerator NextWave()
    {
        waiting = true;
        currentWave += 1;
        if (currentWave % 5 == 0)
        {
            limitEnemiesAlive++;
        }

        //Show wave
        enemiesAlive.gameObject.SetActive(false);
        nextWaveScreen.SetActive(true);
        nextWaveScreen.transform.Find("text").GetComponent<TextMeshProUGUI>().text = $"WAVE {currentWave}";
        yield return new WaitForSecondsRealtime(3f);
        enemiesAlive.gameObject.SetActive(true);
        nextWaveScreen.SetActive(false);
        MakeWave();
        waiting = false;

    }

    private void MakeWave()
    {
        int res = Values[UnityEngine.Random.Range(0, Values.Count)];
        for (int i = 0; i < currentWave; i += res)
        {
            res = Values[UnityEngine.Random.Range(0, Values.Count)];
            if (i + res > currentWave)
            {
                res = Values.Find((int x) => x + i <= currentWave);


            }

            currents.Add(Instantiate(typesOfEnemies[Values.IndexOf(res)], spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)]).GetComponent<Enemy>());

        }
    }

    private IEnumerator CheckAlive()
    {
        yield return new WaitForSeconds(3f);

        currents.RemoveAll((Enemy x) => x.isDead);

        if (currents.Count == 0)
        {
            StartCoroutine(NextWave());
        }
        StartCoroutine(CheckAlive());
        enemiesAlive.text = currents.Count().ToString();

    }


}
