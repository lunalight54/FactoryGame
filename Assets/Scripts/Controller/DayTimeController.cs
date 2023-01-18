using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayTimeController : MonoBehaviour
{
    const float secondsInDay = 86400f;
    const float phaseLength = 900f;// 15 mins in seconds
    [SerializeField] Color nightLightColor;
    [SerializeField] Color dayLightColor = Color.white;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] float timeScale = 60f;
    [SerializeField] float startAtTime = 21600f; // 6 am in seconds
    float time;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Light2D globalLight;
    [SerializeField] int hostileMobsANight = 2;
    int days = 0;
    int mobs;
    int currentPhase = 0;
    List<TimeAgent> agents;
    float Hours
    {
        get { return time / 3600f; }
    }
    float Minutes
    {
        get { return time % 3600f / 600f; }
    }
    private void Awake()
    {
        agents = new List<TimeAgent>();
        mobs = hostileMobsANight;
    }
    private void Start()
    {
        time = startAtTime;
    }
    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }
    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
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
        if (hh > 21 && mobs > 0)//night
        {
            MobSpawnManager.instance.SpawnMob(new Vector3(UnityEngine.Random.Range(-30, 30), UnityEngine.Random.Range(-12, 12), 0));
            mobs--;
        }
        if (time > secondsInDay)
        {
            NextDay();
            mobs = hostileMobsANight;
        }
        int phase = (int)(time / phaseLength);
        if (currentPhase != phase)
        {
            currentPhase = phase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }
    }
    void NextDay()
    {
        time = 0;
        days += 1;
    }
    public bool IsNight()
    {
        int hh = (int)Hours;
        if ( hh < 6 || hh > 21)
        {
            return true;
        }
        return false;
    }
}
