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
    [SerializeField] Color DayLightColor = Color.white;
    [SerializeField] Color NightLightColor;
    [SerializeField] AnimationCurve NightTimeCurve;
    float time = 3600 * 5;
    private float days;
    [SerializeField] float TimeScale = 60f;
    [SerializeField] TextMeshProUGUI Clock;

    [SerializeField] Light2D GlobalLight;
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
        int hh = (int) hour;
        int mm = (int) minutes;
        Clock.text = hh.ToString("00") +":" + mm.ToString("00");
        float v = NightTimeCurve.Evaluate(hour);
        Color c = Color.Lerp(DayLightColor, NightLightColor, v);
        GlobalLight.color = c;
        if(time > SecondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days +=1;
    }
}
