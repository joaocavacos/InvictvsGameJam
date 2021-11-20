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
    void Awake()
    {
        Player._controls.Character.Attack.performed += Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        if (Player.state == States.IDLE)
        {
            //atacar
            Debug.Log("Atacar");
            Player.ChangeState(States.ATK);
            StartCoroutine(Cooldown(atkDuration));

        }
    }

    private void Atk(float size, float Damage)
    {
        if (Physics2D.BoxCast(transform.position, Vector2.one * size, 30, transform.up, size, collidingLayers))
        {

        }

    }

    private IEnumerator Cooldown(float dur)
    {
        yield return new WaitForSeconds(dur);
        Player.ChangeState(States.IDLE);
    }

}
