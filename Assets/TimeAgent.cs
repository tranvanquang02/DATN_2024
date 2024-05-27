using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    public Action OnTimeTick;
    private void Start()
    {
        GameManager.Instance.DayTimeController.Subscrice(this);

    }
    public void Invoke()
    {
        OnTimeTick?.Invoke();
    }
    private void OnDestroy()
    {
        GameManager.Instance.DayTimeController.UnSubscribe(this);
    }
}
