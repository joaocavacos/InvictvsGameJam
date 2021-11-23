using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using Random = UnityEngine;
public class WaveSystem : MonoBehaviour
{
    public static WaveSystem instance;
    
    [Header("Wave")]
    public List<Transform> spawnPoints = new List<Transform>();
    public int currentWave;
    [Header("Enemies")]
    public List<GameObject> typesOfEnemies = new List<GameObject>();
    public List<int> Values = new List<int>();
    [SerializeField] int limitEnemiesAlive;

    [Header("Screens")]
    [SerializeField] private TextMeshProUGUI enemiesAlive;
    [SerializeField] private int bodylimit = 3;
    public GameObject introScreen;
    public GameObject nextWaveScreen;
    bool waiting;
    public List<Enemy> currents = new List<Enemy>();
    private List<Enemy> dead = new List<Enemy>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }

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
        Player.instance.healthSystem.health = Mathf.Min(1, Player.instance.healthSystem.health + ((1 - Player.instance.healthSystem.health) * 0.2f));
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
        if (currents.Count == 0)
        {
            int res;
            for (int i = 0; i < currentWave; i += res)
            {
                res = Values[UnityEngine.Random.Range(0, Values.Count)];
                if (i + res > currentWave)
                {
                    res = Values.Find((int x) => x + i <= currentWave);


                }

                currents.Add(Instantiate(typesOfEnemies[Values.IndexOf(res)], spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)]).GetComponent<Enemy>());
                Debug.Log("Making wave and Adding " + i);
            }
        }
    }

    private IEnumerator CheckAlive()
    {
        yield return new WaitForSeconds(3f);
        dead.AddRange(currents.Where((Enemy x) => x.isDead));
        currents.RemoveAll((Enemy x) => x.isDead);


        if (currents.Count == 0)
        {
            StartCoroutine(NextWave());
            if (dead.Count > bodylimit)
            {
                for (int i = 0; i < dead.Count; i++)
                {
                    GameObject rip = dead[0].gameObject;
                    dead.RemoveAt(0);
                    Destroy(rip);
                    if (dead.Count <= bodylimit)
                    {
                        break;
                    }
                }
            }
        }
        StartCoroutine(CheckAlive());
        enemiesAlive.text = currents.Count().ToString();

    }


}
