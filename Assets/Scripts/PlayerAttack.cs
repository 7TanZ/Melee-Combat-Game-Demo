using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public LayerMask enemyLayer;

    public int lightDamage = 10;
    public int heavyDamage = 20;

    Vector3 GetAttackPoint()
    {
        return transform.position + Vector3.up * 1f;
    }

    // Animation Event → Punch
    public void DealLightDamage()
    {
        Debug.Log("Damage Frame! LIGHT = " + lightDamage);
        DealDamage(lightDamage);
    }


    // Animation Event → Heavy
    public void DealHeavyDamage()
    {
        Debug.Log("Damage Frame! HEAVY = " + heavyDamage);
        DealDamage(heavyDamage);
    }


    void DealDamage(int damage)
    {
        Vector3 attackPoint =
            transform.position +
            transform.forward * 1.2f +
            Vector3.up * 1f;

        Collider[] hits =
            Physics.OverlapSphere(attackPoint, attackRange, enemyLayer);

        Debug.Log("Hits Count = " + hits.Length);

        foreach (Collider hit in hits)
        {
            EnemyHitReceiver enemy =
                hit.GetComponentInParent<EnemyHitReceiver>();

            if (enemy != null)
            {
                Debug.Log("Enemy Found → Sending Damage");
                enemy.TakeHit(damage);
            }
        }
    }



    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireSphere(GetAttackPoint(), attackRange);
    // }

}
