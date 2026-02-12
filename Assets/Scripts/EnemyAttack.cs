using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 20;
    public float attackCooldown = 2f;

    public Animator animator;
    public LayerMask playerLayer;

    private float lastAttackTime;

    private Health myHealth;

    void Start()
    {
        myHealth = GetComponentInParent<Health>();
    }

    void Update()
    {
        // Stop if game ended
        if (GameManager.GameEnded)
            return;

        // Stop if enemy is dead
        if (myHealth != null && myHealth.isDead)
            return;

        // Cooldown check
        if (Time.time < lastAttackTime + attackCooldown)
            return;

        TryStartAttack();
    }

    void TryStartAttack()
    {
        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            attackRange,
            playerLayer
        );

        if (hits.Length > 0)
        {
            if (animator != null)
                animator.SetTrigger("Punch");

            lastAttackTime = Time.time;
        }
    }

    // ⭐ Called from Animation Event
    public void DealDamage()
    {
        // Stop if game ended
        if (GameManager.GameEnded)
            return;

        // Stop if enemy is dead
        if (myHealth != null && myHealth.isDead)
            return;

        Collider[] hits = Physics.OverlapSphere(
            transform.position,
            attackRange,
            playerLayer
        );

        foreach (Collider hit in hits)
        {
            Health playerHealth =
                hit.GetComponentInParent<Health>();

            if (playerHealth != null && !playerHealth.isDead)
            {
                playerHealth.TakeDamage(damage);
                Debug.Log("Enemy dealt damage to player!");
            }
        }
    }
}
