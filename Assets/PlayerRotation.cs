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


    [Header("Debugging")]
    [SerializeField] private bool _rotateWhereWalking;
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!_rotateWhereWalking)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            directionRotation = (mousePos - body.transform.position).normalized;
            float angle = Mathf.Atan2(directionRotation.y, directionRotation.x) * Mathf.Rad2Deg;
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * rotationSpeed);
            Cursor.visible = true;
        }
        else
        {
            float angle = Mathf.Atan2(rb2D.velocity.normalized.y, rb2D.velocity.normalized.x) * Mathf.Rad2Deg;
            body.rotation = Quaternion.Lerp(body.rotation, Quaternion.AngleAxis(angle-90, Vector3.forward), Time.deltaTime * rotationSpeed);
            Cursor.visible = false;
        }

        
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
