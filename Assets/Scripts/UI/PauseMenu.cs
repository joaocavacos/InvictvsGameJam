using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
       
    public GameObject pauseMenu;
    public AudioSource soundSource;

    public void OpenPause()
    {
        if (!pauseMenu.activeSelf && !Player.instance.isDead)
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
        }
        else if (pauseMenu.activeSelf && !Player.instance.isDead)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
        }
        
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
