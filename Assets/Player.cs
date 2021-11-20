using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{
   
    public static StateDebug state { get; private set; }
    public static Player instance { get; private set; }
    public static CharacterControls _controls { get; private set; }
    public static UnityEvent<StateDebug> OnChangeState;
    private void Awake()
    {
        if (instance!=null)
        {
            Destroy(gameObject);
        }
        instance = this;
        _controls = new CharacterControls();
    }
    public static void ChangeState(StateDebug state)
    {
        OnChangeState?.Invoke(state);
    }
    private void OnEnable()
    {
        _controls.Character.Movement.Enable();
        _controls.Character.Direction.Enable();
        _controls.Character.Roll.Enable();
        _controls.Character.Block.Enable();
        _controls.Character.Attack.Enable();
        _controls.Character.Style0.Enable();
        _controls.Character.Style1.Enable();
        _controls.Character.Style2.Enable();
        _controls.Character.Style3.Enable();
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
   
}
public enum StateDebug
{
    Idle,
    Rolling,
    Parry,
    Attack
}
