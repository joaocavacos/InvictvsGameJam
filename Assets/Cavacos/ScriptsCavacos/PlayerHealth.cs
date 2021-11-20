namespace Cavacos.ScriptsCavacos
{
    public class PlayerHealth: HealthSystem
    {
        public override void TakeDamage(float damage)
        {
            base.TakeDamage(damage);
        }

        public override void Die()
        {
            Player.instance.KillPlayer();
            //base.Die();
            //Dead animation
        }
    }
}