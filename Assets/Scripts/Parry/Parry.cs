using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Parry : PlayerComponent
{
    /// <summary>
    /// O meter só vai de 0 a 4
    /// </summary>
    [SerializeField]private float _meter;
    public float BlockDuration = 0.25f;
    Coroutine blockCoroutine;
    public Slider slider;

    public AudioSource soundSource;
    public AudioClip blockSound, parrySound;
    
    public float Meter
    {
        get
        {
            return _meter;
        }
        set
        {
            if (value > 0f)
                _meter = Mathf.Min(4, value);
            else
                _meter = 0;
        }
    }
    private void Start()
    {
        Player._controls.Character.Block.performed += Block_performed;
    }
    private void Block_performed(InputAction.CallbackContext obj)
    {
        if (Player.instance.state == States.IDLE)
        {
            //acao de bloquear
            soundSource.PlayOneShot(blockSound);
            Player.instance.ChangeState(States.BLOCK);
            Player.instance.animator.SetBool("Block",true);
            blockCoroutine = StartCoroutine(Cooldown(BlockDuration));
        }
    }

    public void ChargeMeter()
    {
        soundSource.PlayOneShot(parrySound, 1);
        Meter += 1;
        slider.value = Meter;
        if (blockCoroutine!=null)
        {
            StopCoroutine(blockCoroutine);
            Player.instance.animator.SetBool("Block", false);
            Player.instance.ChangeState(States.IDLE);
        }
        
    }


    public void ResetMeter()
    {
        Meter = 0;
        slider.value = Meter;
    }
    private IEnumerator Cooldown(float dur)
    {
        yield return new WaitForSeconds(dur);
        Player.instance.ChangeState(States.IDLE);
        Player.instance.animator.SetBool("Block", false);
        blockCoroutine = null;
    }

    public override void OnDie()
    {
        
    }
}
