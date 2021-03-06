using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    
    public GameObject mainMenu;
    public GameObject creditsMenu;
    [SerializeField] private GameObject defaultGameobject;

    private void Start()
    {
        Time.timeScale = 1f;
        EventSystem.current.SetSelectedGameObject(defaultGameobject);
    }
    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject ==null)
        {
            EventSystem.current.SetSelectedGameObject(defaultGameobject);
        }
    }
    public void OpenCredits() //main
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CancelMain() //main
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
    
    
    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }

    public void PlaySound(AudioSource audio)
    {
        audio.Play();
    }

}
