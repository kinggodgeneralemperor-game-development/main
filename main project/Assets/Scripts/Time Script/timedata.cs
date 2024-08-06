using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timedata : MonoBehaviour
{
    static double prevtime = 0;     //직전 시간
    static int hour;
    static double minute;
    static int day;
    // Start is called before the first frame update
    void Start()        //time, hour, minute는 세이브 파일 따라서 바꾸기
    {
        prevtime = 0;
        hour = 0;
        minute = 0;
        day = 0;
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        minute += (double)Time.time - prevtime;
        if (minute >= 60)
        {
            while (minute >= 60)
            {
                hour++;
                minute -= 60;
            }
        }
        if(hour >= 24)
        {
            while(hour >= 24)
            {
                day++;
                hour -= 24;
            }
        }
        prevtime = (double)Time.time;
    }

    public static double Gettime()
    {
        return (double)Time.time;
    }

    public static int Gethour()
    {
        return hour;
    }

    public static int Getminute()
    {
        return (int)minute;
    }
}
