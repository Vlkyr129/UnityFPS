using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float health = 50f;
    [SerializeField]
    float pullRadius = 20f;
    [SerializeField]
    float shootRange = 12f;
    [SerializeField]
    float attackIntervals = 1.5f;
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float dropChance = .2f;

    bool alreadyAttacked = false;

    public GameObject potion;
    public GameObject projectile;
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceFromPlayer < pullRadius && distanceFromPlayer > shootRange)
        {
            transform.LookAt(player.position);
            transform.position = Vector3.MoveTowards(this.transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= shootRange && !alreadyAttacked)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);

            //attack cooldown
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), attackIntervals);
        }
    }
    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, pullRadius);
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    //Damaging the enemy
    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        if (health <= 0f)
        {
            if(Random.Range(0f, 1f) <= dropChance)
            {
                Instantiate(potion, transform.position, Quaternion.identity);
            }

            GameManager.highScore++;
            Destroy(gameObject);
        }
    }
}
