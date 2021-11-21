using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFade : MonoBehaviour
{
    private const float DAMAGED_HEALTH_FADE_TIMER_MAX = 1f; //fade time
    public Image barImage;
    private Image damageBarImage;
    private Color damageColor;
    private float fadeTime;

    void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        damageBarImage = transform.Find("DamageBar").GetComponent<Image>();
        damageColor = damageBarImage.color;
        damageColor.a = 0f;
        damageBarImage.color = damageColor;
    }

    private void Update()
    {
        if (damageColor.a > 0)
        {
            fadeTime -= Time.deltaTime;
            if (fadeTime < 0)
            {
                float fadeAmount = 2.5f;
                damageColor.a = fadeAmount * Time.deltaTime;
                damageBarImage.color = damageColor;
            }
        }
        else
        {
            damageBarImage.fillAmount = barImage.fillAmount;
            damageColor.a = 1;
            damageBarImage.color = damageColor;
            fadeTime = DAMAGED_HEALTH_FADE_TIMER_MAX;
        }
    }

}
