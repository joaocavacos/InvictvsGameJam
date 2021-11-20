﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ParryMeter : MonoBehaviour
{
    /// <summary>
    /// O meter só vai de 0 a 1
    /// </summary>
    [Range(0f, 1f)]
    private float _meter;

    public float BlockDuration = 0.25f;

    public float Meter
    {
        get
        {
            return _meter;
        }

        set
        {
            if (value > 0f)
                _meter = Mathf.Min(1, value);
            else
                _meter = 0;
        }
    }
    private void Awake()
    {

        Player._controls.Character.Block.performed += Block_performed;
    }
    private void Block_performed(InputAction.CallbackContext obj)
    {
        if (Player.state == States.IDLE)
        {
            //acao de bloquear
            Debug.Log("Bloquear");
            Player.ChangeState(States.BLOCK);
            StartCoroutine(Cooldown(BlockDuration));
        }
    }

    public void ChargeMeter(float charge)
    {
        Meter += charge;
    }

    public void DepleteMeter(float charge)
    {
        Meter -= charge;
    }

    private IEnumerator Cooldown(float dur)
    {
        yield return new WaitForSeconds(dur);
        Player.ChangeState(States.IDLE);
    }
}