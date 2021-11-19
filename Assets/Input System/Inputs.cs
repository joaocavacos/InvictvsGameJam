using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    private CharacterControls _controls;
    // Start is called before the first frame update
    void Awake()
    {
        //Setup
        _controls = new CharacterControls();

        _controls.Character.Movement.Enable();
        _controls.Character.Direction.Enable();
        _controls.Character.Roll.Enable();
        _controls.Character.Block.Enable();
        _controls.Character.Attack.Enable();
        _controls.Character.Style0.Enable();
        _controls.Character.Style1.Enable();
        _controls.Character.Style2.Enable();
        _controls.Character.Style3.Enable();

        _controls.Character.Roll.performed += Roll_performed;
        _controls.Character.Block.performed += Block_performed;
        _controls.Character.Attack.performed += Attack_performed;
        _controls.Character.Style0.performed += Style0_performed;
        _controls.Character.Style1.performed += Style1_performed;
        _controls.Character.Style2.performed += Style2_performed;
        _controls.Character.Style3.performed += Style3_performed;
    }
    private void Update()
    {
        //Direcao e movimento
        Debug.Log(_controls.Character.Direction.ReadValue<Vector2>());
        Debug.Log(_controls.Character.Movement.ReadValue<Vector2>());
    }

    private void Style3_performed(InputAction.CallbackContext obj)
    {
        //Mudar para o style3
        Debug.Log("Style3");
    }

    private void Style2_performed(InputAction.CallbackContext obj)
    {
        //Mudar para o style2
        Debug.Log("Style2");
    }

    private void Style1_performed(InputAction.CallbackContext obj)
    {
        //Mudar para o style1
        Debug.Log("Style1");
    }

    private void Style0_performed(InputAction.CallbackContext obj)
    {
        //Mudar para o style0
        Debug.Log("Style0");
    }

    private void OnDisable()
    {
        _controls.Character.Movement.Disable();
        _controls.Character.Direction.Disable();
        _controls.Character.Roll.Disable();
        _controls.Character.Block.Disable();
        _controls.Character.Attack.Disable();
        _controls.Character.Style0.Disable();
        _controls.Character.Style1.Disable();
        _controls.Character.Style2.Disable();
        _controls.Character.Style3.Disable();
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        //atacar
        Debug.Log("Atacar");
    }

    private void Block_performed(InputAction.CallbackContext obj)
    {
        //acao de bloquear
        Debug.Log("Bloquear");
    }

    private void Roll_performed(InputAction.CallbackContext obj)
    {
        //evento para o roll
        Debug.Log("Roll");
    }
}
