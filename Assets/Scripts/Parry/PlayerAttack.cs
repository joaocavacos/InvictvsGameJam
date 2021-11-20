using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : PlayerComponent
{
    //trocar depois para a classe do inimigo

    public float atkDuration;
    public LayerMask collidingLayers = 9;
    [SerializeField] float attackCost;
    public float damage;
    public float attackRange;
    // Start is called before the first frame update
    void Start()
    {
        Player._controls.Character.Attack.performed += Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        if (Player.instance.state == States.IDLE && Player.instance.parry.Meter>= attackCost)
        {
            //atacar
            Player.instance.ChangeState(States.ATK);
            Player.instance.animator.SetBool("Damage", true);
            Atk(attackRange, damage);
            StartCoroutine(Cooldown(atkDuration));
        }
    }

    public void Atk(float size, float Damage)
    {
        //RaycastHit2D result = Physics2D.BoxCast(transform.position, Player._controls.Character.Direction.ReadValue<Vector2>().normalized * size, 0, transform.up, size, collidingLayers);
        RaycastHit2D result = Physics2D.CircleCast(transform.position, size, Vector2.up, size, collidingLayers);
        Debug.DrawRay(transform.position, Player._controls.Character.Direction.ReadValue<Vector2>().normalized * size, Color.red, 1f);
        if (result.collider != null)
        {
            result.transform.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
            
        }
        Player.instance.parry.DepleteMeter(attackCost);

    }

    private IEnumerator Cooldown(float dur)
    {
        yield return new WaitForSeconds(dur);
        if (!Player.instance.isDead)
        {
            Player.instance.ChangeState(States.IDLE);
            Player.instance.animator.SetBool("Damage", false);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public override void OnDie()
    {
        
    }
}
