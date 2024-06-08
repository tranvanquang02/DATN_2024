using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float SecondsInDay = 86400f;
    const float PhaseLeght = 900f; // 15 min 1 Tick
    const float phasesInDay = 96f; //secondss in day divided by phaseLeght
    
    [SerializeField] Color DayLightColor = Color.white;
    [SerializeField] Color NightLightColor;
    [SerializeField] AnimationCurve NightTimeCurve;
    float time;
    private float days;
    [SerializeField] float TimeScale = 60f;
    [SerializeField] float StartAtTime = 28800f; //in Second
    [SerializeField] float morningTime = 28800f;
    [SerializeField] TextMeshProUGUI Clock;

    [SerializeField] Light2D GlobalLight;

    List<TimeAgent> agents;

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }
    private void Start()
    {
        time = StartAtTime;
    }
    public void SubscriBe(TimeAgent TimeAgent)
    {
        agents.Add(TimeAgent);
    }
    public void UnSubscribe(TimeAgent TimeAgent)
    { agents.Remove(TimeAgent); }
    float hour
    {
        get { return time / 3600f; }
    }
    float minutes
    {
        get { return time % 3600f / 60f; }
    }
    private void Update()
    {
        time += Time.deltaTime * TimeScale;
        TimeValueCalculation();
        DayNight();
        if (time > SecondsInDay)
        {
            NextDay();
        }
        TimeAgent();
        if(Input.GetKeyDown(KeyCode.T))
        {
            SkipTime(hours : 4);
        }
    }
    int OldPhase = -1;
    private void TimeAgent()
    {
        if(OldPhase == -1)
        {
            OldPhase = CalculatePhase();
        }
        int CurrentPhase = CalculatePhase();

        while(OldPhase < CurrentPhase)
        {
            OldPhase += 1;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
    }

    private int CalculatePhase()
    {
        return (int)(time / PhaseLeght) + (int)(days * phasesInDay);
    }

    private void DayNight()
    {
        float v = NightTimeCurve.Evaluate(hour);
        Color c = Color.Lerp(DayLightColor, NightLightColor, v);
        GlobalLight.color = c;
    }

    private void TimeValueCalculation()
    {
        int hh = (int)hour;
        int mm = (int)minutes;
        Clock.text = "Day"+ days.ToString() +"    "+ hh.ToString("00") + ":" + mm.ToString("00");

    }

    private void NextDay()
    {
        time -= SecondsInDay;
        days +=1;
    }
    public void SkipTime(float seconds = 0, float minute = 0, float hours = 0 )
    {
        float timeToSkip = seconds;
        timeToSkip += minute * 60f;
        timeToSkip += hours * 3600f;

        time += timeToSkip;
    }

    internal void SkipToMorning()
    {
        float secondToSkip = 0f;

        if(time > morningTime)
        {
            secondToSkip += SecondsInDay - time + morningTime;
        }
        else
        {
            secondToSkip += morningTime - time;
        }
        SkipTime(secondToSkip);
    }
}
