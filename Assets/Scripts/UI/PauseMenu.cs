using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
       
    public GameObject pauseMenu;

    void Update()
    {
        //check for input, and call OpenPause()
    }

    public void OpenPause()
    {
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
    }

    public void BacktoMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
