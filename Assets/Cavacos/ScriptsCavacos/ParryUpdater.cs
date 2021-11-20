using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParryUpdater : MonoBehaviour
{

    public Slider parrySlider;
    public Image fillSlider;

    void Start()
    {
        fillSlider.color = Color.white;
    }

    void Update()
    {
        if (parrySlider.value <= 25)
        {
            fillSlider.color = Color.green;
        }else if (parrySlider.value > 25 && parrySlider.value <= 50)
        {
            fillSlider.color = Color.blue;
        }else if (parrySlider.value > 50 && parrySlider.value <= 75)
        {
            fillSlider.color = Color.red;
        }else if (parrySlider.value > 75)
        {
            fillSlider.color = Color.magenta;
        }
    }
}
