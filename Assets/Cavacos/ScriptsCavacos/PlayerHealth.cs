using UnityEngine;
namespace Cavacos.ScriptsCavacos
{
    public class PlayerHealth: HealthSystem
    {
        public override void TakeDamage(float damage)
        {
            if (Player.instance.state == States.BLOCK )
            {
                Debug.Log("Parried");
                Player.instance.parry.ChargeMeter(damage);
            }
            else if (Player.instance.state == States.ROLL)
            {
                Debug.Log("Dogged");
            }
            else
            {
                Player.instance.parry.ResetMeter();
                base.TakeDamage(damage);
            }
            
        }

        public override void Die()
        {
            Player.instance.KillPlayer();
            Player.instance.animator.SetBool("Dead", true);
            Player.instance.ChangeState(States.DEAD);
            //base.Die();
            //Dead animation
        }
    }
}