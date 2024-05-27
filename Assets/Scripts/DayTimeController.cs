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
    const float PhaseLeght = 900f;
    
    [SerializeField] Color DayLightColor = Color.white;
    [SerializeField] Color NightLightColor;
    [SerializeField] AnimationCurve NightTimeCurve;
    float time;
    private float days;
    [SerializeField] float TimeScale = 60f;
    [SerializeField] float StartAtTime = 28800f; //in Second
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
    public void Subscrice(TimeAgent TimeAgent)
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
    }
    int OldPhase = 0;
    private void TimeAgent()
    {
        int CurrentPhase = (int)(time / PhaseLeght);
        if(OldPhase != CurrentPhase)
        {
            OldPhase = CurrentPhase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
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
        Clock.text = hh.ToString("00") + ":" + mm.ToString("00");
    }

    private void NextDay()
    {
        time = 0;
        days +=1;
    }
}
