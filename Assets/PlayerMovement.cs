using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 movementDir;
    private Rigidbody2D rb2d;
    public float lerpTime;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        movementDir = Vector2.zero;
    }
    private void Update()
    {
        //Get input
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //Change de movement direction for smoother movement
        movementDir = Vector2.Lerp(movementDir, input, Time.deltaTime * lerpTime);

        rb2d.velocity = movementSpeed * movementDir;
        
        //change velocity to the rigidbody lerping for not snapping movement
    }
}
