using System;
using UnityEngine;
using UnityEngine.UI;

namespace Cavacos.ScriptsCavacos
{
    public class PlayerHealth: HealthSystem
    {
        public Slider hpSlider;

        void Start()
        {
            hpSlider.value = hpSlider.maxValue;
            health = hpSlider.value;
        }

        void Update()
        {
            hpSlider.value = health;
        }

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
                Debug.Log("Reset Meter");
                Player.instance.parry.ResetMeter();
                base.TakeDamage(damage);
            }
            
        }

        public override void Die()
        {
            Debug.Log("Died");
            Player.instance.KillPlayer();
            Player.instance.animator.SetBool("Dead", true);
            Player.instance.ChangeState(States.DEAD);
            //base.Die();
            //Dead animation
        }
    }
}