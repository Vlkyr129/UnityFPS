using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed = 400f;
    [SerializeField]
    float decayTime = 6f;
    [SerializeField]
    float damage = 10;

    GameObject target;
    
    

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 aim = (target.transform.position - transform.position).normalized;
        rb.AddForce(aim * projectileSpeed);

        Destroy(this.gameObject, decayTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStates.playerHealth -= damage;
            Destroy(this.gameObject);
        }
    }
}
