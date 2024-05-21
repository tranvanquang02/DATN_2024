using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTimeController : MonoBehaviour
{
    const float SecondsInDay = 86400f;
    [SerializeField] Color DayLightColor = Color.white;
    [SerializeField] Color NightLightColor;
    [SerializeField] AnimationCurve NightTimeCurve;
    float time;


}
