using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : MonoBehaviour
{
    public float distanceRoll;
    public float timeToRoll;
    private float currentLerp;
    bool canRoll;
    Vector2 startPos;
    Vector2 dirRoll;
    Vector2 dirRolling;
    Rigidbody2D rb2D;
    /*
    [Header("Debugging")]
    [SerializeField] private Transform indicatorDir;
    */
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Player.OnChangeState.AddListener(CheckCanRoll);
        Player._controls.Character.Roll.performed += TriggerRoll;
    }
    private void Update()
    {
        if (Player._controls.Character.Direction.ReadValue<Vector2>() != Vector2.zero )
        {
            dirRoll = Player._controls.Character.Direction.ReadValue<Vector2>().normalized;
            /*
            float angle = Mathf.Atan2(dirRoll.y, dirRoll.x) * Mathf.Rad2Deg;
            indicatorDir.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            */
        }
        if (Player.state == States.ROLL)
        {
            Debug.Log("RollingUpdate");
            currentLerp += Time.deltaTime/timeToRoll;
            rb2D.position = Vector2.Lerp(startPos, startPos + (dirRolling * distanceRoll), currentLerp);
            if (currentLerp>= timeToRoll)
            {
                Player.ChangeState(States.IDLE);
            }
        }
    }
    private void TriggerRoll(InputAction.CallbackContext obj)
    {
        Debug.Log("Trigger Roll");
        if (canRoll)
        {
            Debug.Log("Rolling");
            Player.ChangeState(States.ROLL);
            currentLerp = 0;
            rb2D.velocity = Vector2.zero;
            
            
            startPos = rb2D.position;
            dirRolling = dirRoll;
        }
    }

    private void CheckCanRoll(States s)
    {
        if (s!= States.ATK || s!= States.BLOCK || s!= States.ROLL)
        {
            canRoll = true;
        }
        else
        {
            canRoll = false;
        }
    }
}
