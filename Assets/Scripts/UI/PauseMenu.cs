using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
       
    public GameObject pauseMenu;
    
    public void OpenPause()
    {
        pauseMenu.SetActive(true);
    }

    public void ClosePause()
    {
        pauseMenu.SetActive(false);
    }

    public void BacktoMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
