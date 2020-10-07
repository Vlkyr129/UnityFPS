using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField]
    float enemyDamage = 20f;

    public static float playerMaxHealth = 100;
    public static float playerHealth;

    private void Start()
    {
        playerHealth = playerMaxHealth;
    }

    private void Update()
    {
        if(playerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "healthPotion")
        {
            if(playerHealth + 20f <= playerMaxHealth)
            {
                playerHealth = playerHealth + 20f;
            }
            else
            {
                playerHealth = playerMaxHealth;
            }            
        }
    }
}
