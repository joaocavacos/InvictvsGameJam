using System;
using UnityEngine;
using UnityEngine.UI;

namespace Cavacos.ScriptsCavacos
{
    public class PlayerHealth: HealthSystem
    {
        public HealthBarFade _healthbar;
        public GameOver _gameOver;

        void Start()
        {
            health = _healthbar.barImage.fillAmount;
            Time.timeScale = 1;
        }

        void Update()
        {
            _healthbar.barImage.fillAmount = health;
        }

        public override void TakeDamage(float damage)
        {
            if (Player.instance.state == States.BLOCK )
            {
                Debug.Log("Parried");
                Player.instance.parry.ChargeMeter();
            }
            else if (Player.instance.state == States.ROLL)
            {
                Debug.Log("Dogged");
            }
            else
            {
                Debug.Log("Reset Meter"); 
                base.TakeDamage(damage);
                Player.instance.parry.ResetMeter();
                
            }
            
        }

        public override void Die()
        {
            Debug.Log("Died");
            Player.instance.KillPlayer();
            Player.instance.animator.SetBool("Dead", true);
            Player.instance.ChangeState(States.DEAD);
            _gameOver.GameOverActivate();
            Time.timeScale = 0;
            //base.Die();
            //Dead animation
        }
    }
}