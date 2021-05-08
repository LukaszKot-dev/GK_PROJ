using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timeCounter;
    public GameObject timeCounterObject;

    private TimeSpan timePlaying;
    private bool timerGoing;
    private float elapsedTime;

    public void Awake()
    {
        
            instance = this;
    }

    void Start()
    {

    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void ResumeTimer()
    {
        timerGoing = true;
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = " " + timePlaying.ToString("mm' : 'ss'.'ff");
            timeCounter.text = timePlayingStr;

            yield return null;
       
        }
    }

}
