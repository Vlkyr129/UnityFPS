using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttack : MonoBehaviour
{
    [SerializeField]
    float damage = 10;

    private void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStates.playerHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
