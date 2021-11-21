using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    public void GameOverActivate()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void RetryQuit(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    
}
