using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhoneTimer : MonoBehaviour
{
    public float roundTime;
    public float baseTime;
    private float lastTick;
    private TextMeshPro phoneTimerDisplay;
    
    void Start()
    {
        baseTime = 6 * 60 + 29;
        baseTime = baseTime * 60;
        lastTick = 0;
        phoneTimerDisplay = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        roundTime += (Time.time - lastTick);
        lastTick = Time.time;
        //Debug.Log(roundTime);
        string newTime = (((roundTime + baseTime) / 3600)%24).ToString("00");
        newTime += ":";
        newTime += (((roundTime + baseTime) / 60)%60).ToString("00");
        phoneTimerDisplay.text = newTime;
        

    }

    public void ResetTime()
    {
        lastTick = Time.time;
        roundTime = 0;
    }
    public void ResetTime(float hour,float min)
    {
        baseTime = 60 * hour + min;
        baseTime = baseTime * 60;
        //Debug.Log(baseTime);
        lastTick = Time.time;
        roundTime = 0;
    }
}
