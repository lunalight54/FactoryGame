using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] Color dayLightColor = Color.white;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] float timeScale = 60f;

    float time;
    private int days = 0;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Light2D globalLight;
    float Hours
    {
        get { return time / 3600f; }
    }
    float Minutes
    {
        get { return time % 3600f / 600f; }
    }

    private void Update()
    {
        int hh = (int)Hours;
        int mm = (int)Minutes;
        time += Time.deltaTime * timeScale;
        text.text = hh.ToString("00") + ":" + mm.ToString("0") + "0";
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if (time > secondsInDay)
        {
            NextDay();
        }
    }
    void NextDay()
    {
        time = 0;
        days += 1;
    }

    void SetTime(float setTime)
    {
        
    }
}
