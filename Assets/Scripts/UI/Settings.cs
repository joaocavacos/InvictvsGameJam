using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Settings : MonoBehaviour
{
    
    [Header("Settings Menu Objects")]
    public GameObject generalMenu;
    public GameObject graphicsMenu;
    public GameObject controlsMenu;
    public GameObject settingsMenu;
    public GameObject rebindMenu;

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

    public void OpenGeneral()
    {
        generalMenu.SetActive(true);
        graphicsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        rebindMenu.SetActive(false);
    }

    public void OpenGraphics()
    {
        graphicsMenu.SetActive(true);
        generalMenu.SetActive(false);
        controlsMenu.SetActive(false);
        rebindMenu.SetActive(false);
    }

    public void OpenControls()
    {
        EventSystem.current.SetSelectedGameObject(transform.Find("ConfirmButton").gameObject);
        controlsMenu.SetActive(true);
        graphicsMenu.SetActive(false);
        generalMenu.SetActive(false);
        rebindMenu.SetActive(false);
    }

    public void OpenRebind()
    {
        rebindMenu.SetActive(true);
        controlsMenu.SetActive(false);
        graphicsMenu.SetActive(false);
        generalMenu.SetActive(false);
    }
    
    public void Close()
    {
        settingsMenu.SetActive(false);
    }

    public void Open()
    {
       
        settingsMenu.SetActive(true);
    }

}
