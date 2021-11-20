using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    //trocar depois para a classe do inimigo

    public float atkDuration;
    public LayerMask collidingLayers = 9;
    // Start is called before the first frame update
    void Start()
    {
        Player._controls.Character.Attack.performed += Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        if (Player.state == States.IDLE)
        {
            //atacar
            Debug.Log("Atacar");
            Player.instance.ChangeState(States.ATK);
            StartCoroutine(Cooldown(atkDuration));
            Atk(10, 0.5f);
        }
    }

    public void Atk(float size, float Damage)
    {
        RaycastHit2D result = Physics2D.BoxCast(transform.position, Player._controls.Character.Direction.ReadValue<Vector2>().normalized * size, 30, transform.up, size, collidingLayers);
        Debug.DrawRay(transform.position, Player._controls.Character.Direction.ReadValue<Vector2>().normalized * size, Color.red, 1f);
        if (result.collider != null)
        {
            result.transform.gameObject.GetComponent<Enemy>().health -= Damage;
        }
    }

    private IEnumerator Cooldown(float dur)
    {
        yield return new WaitForSeconds(dur);
        Player.instance.ChangeState(States.IDLE);
    }

}
