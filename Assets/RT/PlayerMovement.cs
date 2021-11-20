using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerComponent
{
    public float movementSpeed;
    private Vector2 movementDir;
    public float lerpTime;
    Vector2 input;
    bool canMove;

    private void Awake()
    {
        movementDir = Vector2.zero;
        Player.OnChangeState.AddListener(ChangedState);
    }
    private void Update()
    {
       
        if (canMove)
        {
            //Get input
            input = Player._controls.Character.Movement.ReadValue<Vector2>();

            //Change de movement direction for smoother movement
            movementDir = Vector2.Lerp(movementDir, input, Time.deltaTime * lerpTime);
            //change velocity to the rigidbody lerping for not snapping movement
            Player.instance.rb2D.velocity = movementSpeed * movementDir;
        }
        
    }
    private void ChangedState(States s)
    {
        if (s == States.ROLL || s==States.ATK)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }

    public override void OnDie()
    {
        
    }
}
