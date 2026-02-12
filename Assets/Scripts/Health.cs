using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Animator animator;
    public bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;

        Debug.Log(gameObject.name + " HP = " + currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;

            if (animator != null)
                animator.SetTrigger("Dead");
        }
    }




    void Die()
    {
        isDead = true;

        Debug.Log(gameObject.name + " DIED");

        if (animator != null)
            animator.SetTrigger("Dead");
    }

}
