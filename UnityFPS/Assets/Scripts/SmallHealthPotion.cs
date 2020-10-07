using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallHealthPotion : MonoBehaviour
{
    [SerializeField]
    float healPlayerAmount;

    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (PlayerStates.playerHealth + healPlayerAmount <= PlayerStates.playerMaxHealth)
            {
                PlayerStates.playerHealth += healPlayerAmount;
            }
            else
            {
                PlayerStates.playerHealth = PlayerStates.playerMaxHealth;
            }

            Destroy(this.gameObject);
        }
    }
}
