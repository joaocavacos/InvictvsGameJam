using System;
using System.Collections;
using System.Collections.Generic;
using Cavacos.ScriptsCavacos;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarFade : MonoBehaviour
{
    public float maxFadeTimer = 1f; //fade time
    public Image barImage;
    public Image damageBarImage;
    public Color damageColor;
    public float fadeTimer;
    public PlayerHealth hp;

    void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();
        damageBarImage = transform.Find("DamageBar").GetComponent<Image>();

        damageColor = damageBarImage.color;
        damageColor.a = 0f;
        damageBarImage.color = damageColor;
    }

    private void Start()
    {
        SetHealth(hp.health);
    }

    private void Update()
    {
        if (damageColor.a > 0f)
        {
            fadeTimer -= Time.deltaTime;
            if (fadeTimer < 0)
            {
                damageColor.a -= 5f * Time.deltaTime;
                damageBarImage.color = damageColor;
            }
        }
    }

    public void SetHealth(float hp)
    {
        barImage.fillAmount = hp;
    }
    

}
