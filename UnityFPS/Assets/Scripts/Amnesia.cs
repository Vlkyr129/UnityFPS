using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amnesia : MonoBehaviour
{
    //Trigger Rewind Ability
    [SerializeField]
    float maxTimeRewind = 5; 
    bool isRewinding = false;

    List<PointInTime> pointsInTime;

    Rigidbody rb;

    private void Start()
    {
        pointsInTime = new List<PointInTime>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        while (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isRewinding = true;
        }

    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            rb.isKinematic = true;

            if (pointsInTime.Count > 0)
            {
                PointInTime pointInTime = pointsInTime[0];
                transform.position = pointInTime.position;
                transform.rotation = pointInTime.rotation;
                pointsInTime.RemoveAt(0);
            }
            else
            {
                isRewinding = false;
            }
        }
        else
        {
            rb.isKinematic = false;

            if (pointsInTime.Count > (maxTimeRewind / Time.fixedDeltaTime))
            {
                pointsInTime.RemoveAt(pointsInTime.Count - 1);
            }
            pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
        }
    }
}
