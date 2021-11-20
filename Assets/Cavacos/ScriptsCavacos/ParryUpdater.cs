using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParryUpdater : MonoBehaviour
{

    public Slider parrySlider;
    public Image fillSlider;

    public Color green;
    public Color blue;
    public Color darkBlue;
    public Color purple;


    void Update()
    {
        if (parrySlider.value <= 25)
        {
            fillSlider.color = green;
        }else if (parrySlider.value > 25 && parrySlider.value <= 50)
        {
            fillSlider.color = blue;
        }else if (parrySlider.value > 50 && parrySlider.value <= 75)
        {
            fillSlider.color = darkBlue;
        }else if (parrySlider.value > 75)
        {
            fillSlider.color = purple;
        }
    }
}
