using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
       
    public GameObject pauseMenu;

    public AudioSource soundSource;

    public void OpenPause()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void BacktoMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlaySound(AudioClip sClip)
    {
        soundSource.PlayOneShot(sClip);
    }
}
