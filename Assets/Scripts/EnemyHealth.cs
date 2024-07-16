using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;
    private RagDollBehaviour enemyRagdoll;

    void Start()
    {
        enemyRagdoll = GetComponent<RagDollBehaviour>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        
    }
}
