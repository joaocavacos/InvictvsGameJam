using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour
{
    public static States State = States.IDLE;

    public float atkDuration = 0.25f;
    public float RollDuration = 1f;
    public float BlockDuration = 0.1f;
    private void Awake()
    {

        Player._controls.Character.Attack.performed += Attack_performed;
        Player._controls.Character.Roll.performed += Roll_performed;
        Player._controls.Character.Block.performed += Block_performed;
    }
    private void Attack_performed(InputAction.CallbackContext obj)
    {
        if (State == States.IDLE)
        {
            //atacar
            Debug.Log("Atacar");
            State = States.ATK;
            StartCoroutine(Cooldown(atkDuration));

        }
    }

    private void Block_performed(InputAction.CallbackContext obj)
    {
        if (State == States.IDLE)
        {
            //acao de bloquear
            Debug.Log("Bloquear");
            State = States.BLOCK;
            StartCoroutine(Cooldown(BlockDuration));
        }
    }

    private void Roll_performed(InputAction.CallbackContext obj)
    {
        if (State == States.IDLE)
        {
            //evento para o roll
            Debug.Log("Roll");
            State = States.ROLL;
            StartCoroutine(Cooldown(RollDuration));
        }
    }


    private IEnumerator Cooldown(float dur)
    {
        yield return new WaitForSeconds(dur);
        State = States.IDLE;
    }

    private void Update()
    {
        Debug.Log(State);
    }
}
