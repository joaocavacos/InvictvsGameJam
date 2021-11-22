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
        if (parrySlider.value == 1)
        {
            fillSlider.color = green;
        }else if (parrySlider.value ==2)
        {
            fillSlider.color = blue;
        }else if (parrySlider.value ==3)
        {
            fillSlider.color = darkBlue;
        }else if (parrySlider.value == 4)
        {
            fillSlider.color = purple;
        }
    }
}
