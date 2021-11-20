using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 directionRotation;
    public float rotationSpeed;
    private void Update()
    {
        if (Player._controls.Character.Movement.ReadValue<Vector2>()!=Vector2.zero && Player.state != States.ROLL)
        {
            float angle = Mathf.Atan2(Player.instance.rb2D.velocity.normalized.y, Player.instance.rb2D.velocity.normalized.x) * Mathf.Rad2Deg;
            Player.instance.body.rotation = Quaternion.Lerp(Player.instance.body.rotation, Quaternion.AngleAxis(angle - 90, Vector3.forward), Time.deltaTime * rotationSpeed);
        }
        
        Cursor.visible = false;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mousePos, 1f);
        Gizmos.DrawLine(Player.instance.body.transform.position, mousePos);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Player.instance.body.transform.position, Player.instance.body.transform.position + directionRotation * 2);
    }
}
