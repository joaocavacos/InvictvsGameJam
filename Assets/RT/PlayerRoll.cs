using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRoll : PlayerComponent
{
    public float distanceRoll;
    public float timeToRoll;
    private float currentLerp;
    bool canRoll;
    Vector2 startPos;
    Vector2 finalPos;
    Vector2 dirRoll;

    [SerializeField] LayerMask wallLayer;
    private void Start()
    {
        Player.OnChangeState.AddListener(CheckCanRoll);
        Player._controls.Character.Roll.performed += TriggerRoll;
    }
    private void Update()
    {
        if (Player._controls.Character.Movement.ReadValue<Vector2>() != Vector2.zero )
        {
            dirRoll = Player._controls.Character.Movement.ReadValue<Vector2>().normalized;
        }
        if (Player.instance.state == States.ROLL)
        {
            //Debug.Log("RollingUpdate");
            currentLerp += Time.deltaTime/timeToRoll;
            

            Player.instance.rb2D.position = Vector2.Lerp(startPos, finalPos, currentLerp);
            if (currentLerp>= 1)
            {
                Player.instance.ChangeState(States.IDLE);
                Player.instance.animator.SetBool("Roll", false);
            }
        }
    }
    private void TriggerRoll(InputAction.CallbackContext obj)
    {
        //Debug.Log("Trigger Roll");
        if (canRoll && Player.instance.state != States.ROLL)
        {
            //Debug.Log("Rolling");
            Player.instance.ChangeState(States.ROLL);
            Player.instance.animator.SetBool("Roll", true);
            currentLerp = 0;
            Player.instance.rb2D.velocity = Vector2.zero;
            
            
            startPos = Player.instance.rb2D.position;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dirRoll.normalized, distanceRoll, wallLayer);
            if (hit)
            {
                finalPos = hit.point;
            }
            else
            {
                finalPos = startPos + (dirRoll * distanceRoll);
            }

            //Locks rotation at that angle
            float angle = Mathf.Atan2(dirRoll.y, dirRoll.x) * Mathf.Rad2Deg;
            Player.instance.body.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);



        }
    }

    private void CheckCanRoll(States s)
    {
        if (s==States.IDLE)
        {
            canRoll = true;
        }
        else
        {
            canRoll = false;
        }
    }

    public override void OnDie()
    {
        
    }
}
