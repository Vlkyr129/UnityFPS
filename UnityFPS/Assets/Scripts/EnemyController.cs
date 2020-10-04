
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float health = 50f;

    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }


}
