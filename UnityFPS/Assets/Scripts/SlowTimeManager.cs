using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTimeManager : MonoBehaviour
{
    [SerializeField]
    float slowDownAmount = 0.05f;
    [SerializeField]
    float slowDownDuration = 6f;

    private void Update()
    {
        //Sets the max speed limit and give a progressive speed buildup.
        Time.timeScale += (1f / slowDownDuration) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Time.timeScale = slowDownAmount;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
    }
}
