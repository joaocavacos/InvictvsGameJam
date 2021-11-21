using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject firstselected;

    public void GameOverActivate()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        EventSystem.current.SetSelectedGameObject(firstselected);
    }

    public void RetryQuit(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


}
