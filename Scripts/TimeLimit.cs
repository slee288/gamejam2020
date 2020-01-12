using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public int minute = 5;
    public int secondTime = 0;
    public Text timer;

    private float millisecond;

    // Start is called before the first frame update
    void Start()
    {
        millisecond = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        millisecond -= Time.deltaTime;
        Debug.Log(millisecond);
        if(millisecond < 0)
        {
            if(secondTime == 0)
            {
                minute--;
                secondTime = 60;
            }
            secondTime--;
            millisecond++;
        }

        string secondString = "";

        if(secondTime < 10)
        {
            secondString = "0" + secondTime;
        }
        else
        {
            secondString = secondTime.ToString();
        }
        timer.text = "0" + minute + ":" + secondString;
    }
}
