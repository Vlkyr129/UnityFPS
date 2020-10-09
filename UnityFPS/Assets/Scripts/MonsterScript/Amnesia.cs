using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amnesia : MonoBehaviour
{
    
    ////Trigger Rewind Ability
    //[SerializeField]
    //float maxTimeRewind = 5; 
    //bool isRewinding = false;

    //List<pointInTime> pastPositions;

    //Rigidbody rb;

    //private void Start()
    //{
    //    pastPositions = new List<pointInTime>();
    //    rb = GetComponent<Rigidbody>();
    //}

    //private void Update()
    //{
    //    while (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        isRewinding = true;
    //    }

    //}

    //private void FixedUpdate()
    //{
    //    if (isRewinding)
    //    {
    //        rb.isKinematic = true;

    //        if (pastPositions.Count > 0)
    //        {
    //            pointInTime pointInTime = pastPositions[0];
    //            transform.position = pointInTime.position;
    //            pastPositions.RemoveAt(0);
    //        }
    //        else
    //        {
    //            isRewinding = false;
    //        }
    //    }
    //    else
    //    {
    //        rb.isKinematic = false;

    //        if (pastPositions.Count > (maxTimeRewind / Time.fixedDeltaTime))
    //        {
    //            pastPositions.RemoveAt(pastPositions.Count - 1);
    //        }
    //        pastPositions.Insert(0, new pointInTime(transform.position));
    //    }
    //}
    
}
