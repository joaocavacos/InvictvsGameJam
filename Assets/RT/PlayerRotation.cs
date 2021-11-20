using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 directionRotation;
    public float rotationSpeed;
    public Transform body;
    private Rigidbody2D rb2D;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        //OLHAR PARA O RATO
        /*
        if (!_rotateWhereWalking) 
        {
            directionRotation = Player._controls.Character.Direction.ReadValue<Vector2>();
            float angle = Mathf.Atan2(directionRotation.y, directionRotation.x) * Mathf.Rad2Deg;
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * rotationSpeed);
            Cursor.visible = true;
        }
        */
        if (Player._controls.Character.Movement.ReadValue<Vector2>()!=Vector2.zero)
        {
            float angle = Mathf.Atan2(rb2D.velocity.normalized.y, rb2D.velocity.normalized.x) * Mathf.Rad2Deg;
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        
        Cursor.visible = false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mousePos, 1f);
        Gizmos.DrawLine(body.transform.position, mousePos);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(body.transform.position, body.transform.position + directionRotation * 2);
    }
}
