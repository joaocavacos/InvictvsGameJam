using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 movementDir;
    private Rigidbody2D rb2d;
    public float lerpTime;
    Vector2 input;
    bool canMove;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementDir = Vector2.zero;
        Player.OnChangeState.AddListener(ChangedState);
    }

   

    private void Update()
    {
        /* //Old input System

        //Get input
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Change de movement direction for smoother movement
        movementDir = Vector2.Lerp(movementDir, input, Time.deltaTime * lerpTime);
        //change velocity to the rigidbody lerping for not snapping movement
        rb2d.velocity = movementSpeed * movementDir;
        
        */
        if (canMove)
        {
            //Get input
            input = Player._controls.Character.Movement.ReadValue<Vector2>();

            //Change de movement direction for smoother movement
            movementDir = Vector2.Lerp(movementDir, input, Time.deltaTime * lerpTime);
            //change velocity to the rigidbody lerping for not snapping movement
            rb2d.velocity = movementSpeed * movementDir;
        }
        
    }
    private void ChangedState(StateDebug s)
    {
        if (s == StateDebug.Rolling || s==StateDebug.Attack)
        {
            canMove = false;
        }
        else
        {
            canMove = true;
        }
    }
}
