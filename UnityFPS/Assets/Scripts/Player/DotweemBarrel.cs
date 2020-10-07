using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DotweemBarrel : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            transform.DORewind();
            transform.DOPunchScale(new UnityEngine.Vector3 (1, 0, .5f), .25f);
        }
    }
 
}
