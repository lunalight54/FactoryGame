using Newtonsoft.Json.Bson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeAgent : MonoBehaviour
{
    public Action onTimeTick;
    private void Start()
    {
        GameManager.instance.dayTimeController.Subscribe(this);
    }
    public void Invoke()
    {
        onTimeTick?.Invoke();
    }
    private void OnDestroy()
    {
        GameManager.instance.dayTimeController.Unsubscribe(this);
    }
}
