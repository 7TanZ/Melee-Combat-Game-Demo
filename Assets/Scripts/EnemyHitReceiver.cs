using UnityEngine;

public class EnemyHitReceiver : MonoBehaviour
{
    public Health health;

    public void TakeHit(int damage)
    {
        Debug.Log("Enemy TakeHit Called → Damage = " + damage);

        if (health != null)
            health.TakeDamage(damage);
    }

}
