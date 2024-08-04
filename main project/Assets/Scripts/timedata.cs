using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class timedata : MonoBehaviour
{
    static double prevtime = 0;     //���� �ð�
    static int hour;
    static double minute;
    // Start is called before the first frame update
    void Start()        //time, hour, minute�� ���̺� ���� ���� �ٲٱ�
    {
        prevtime = 0;
        hour = 0;
        minute = 0;
    }

    // Update is called once per frame
    void Update()
    {
        minute += (double)Time.time - prevtime;
        if (minute >= 60)
        {
            hour++;
            minute -= 60;
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
