using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    public Action OnTimeTick;
       

    // template method pattern
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        GameManager.Instance.DayTimeController.SubscriBe(this);
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
