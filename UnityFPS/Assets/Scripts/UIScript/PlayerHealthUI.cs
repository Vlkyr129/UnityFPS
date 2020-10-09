using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField]
    Text healthNumber;

    private void Update()
    {
        healthNumber.text = "" + PlayerStates.playerHealth;
    }
}
