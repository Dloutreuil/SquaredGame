using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    float time;
    public float TimerInterval = 5f;
    float tick;

    void Start()
    {
        
    }

    void Update()
    {
        GetComponent<Text>().text = string.Format ("{0:00}:{1:00}",Mathf.Floor(time/60),time%60);
        time = (int)Time.time;    

        if(time == tick)
        {
            tick = time + TimerInterval;
            Debug.Log("Timer");
        }
    }

    void TimerExecute()
    {
        Debug.Log("Timer");
    }
}
