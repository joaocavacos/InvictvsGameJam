using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    
    [Header("Menu Objects")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject generalMenu;
    public GameObject graphicsMenu;

    [Header("Sound/Music Settings")]
    public Slider soundSlider;
    public Slider musicSlider;
    [SerializeField] private string soundVolume = "SoundVolume";
    [SerializeField] private AudioMixer soundMixer;
    [SerializeField] private string musicVolume = "MusicVolume";
    [SerializeField] private AudioMixer musicMixer;
    [SerializeField] private float multiplier = 30f;
    
    private Resolution[] resolutions;
    [SerializeField] private TMP_Dropdown resDropdown;
    [SerializeField] private TMP_Dropdown qualityDropdown;

    private void Awake()
    {
        soundSlider.onValueChanged.AddListener(SoundSliderChanged);
        musicSlider.onValueChanged.AddListener(MusicSliderChanged);
    }
    
    private void Start()
    {
        //Sounds
        soundSlider.value = PlayerPrefs.GetFloat(soundVolume, soundSlider.value);
        musicSlider.value = PlayerPrefs.GetFloat(musicVolume, musicSlider.value);
        
        //Graphics
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        
        //Resolution
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        
        List<string> options = new List<string>();
        int currentResIndex = 0;
        
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();
        
        DontDestroyOnLoad(this);
    }

    private void SoundSliderChanged(float volume)
    {
        soundMixer.SetFloat(soundVolume, Mathf.Log10(volume) * multiplier);
    }

    private void MusicSliderChanged(float volume)
    {
        musicMixer.SetFloat(musicVolume, Mathf.Log10(volume) * multiplier);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(soundVolume, soundSlider.value);
        PlayerPrefs.SetFloat(musicVolume, musicSlider.value);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }

    public void StartGame(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void CancelMain()
    {
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        creditsMenu.SetActive(false);
    }

    public void OpenGeneral()
    {
        generalMenu.SetActive(true);
        graphicsMenu.SetActive(false);
    }

    public void OpenGraphics()
    {
        graphicsMenu.SetActive(true);
        generalMenu.SetActive(false);
    }
    
    
}
