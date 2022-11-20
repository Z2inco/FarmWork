using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class DayTimeController : MonoBehaviour
{

    const float secondsInDay = 86400f;
    const float phaseLength = 900f; //15min chunk of time

    //��ʼ����ɫ
    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;  //��ɫ�仯����
    [SerializeField] Color dayLightColor = Color.white;
   

    //��ʼ��ʱ��
    [SerializeField]float timeScale = 60f;
    [SerializeField] float startAtTime = 28800f; //in the moring
   
    [SerializeField] Text text;
    [SerializeField]Light2D globalLight;

    float time;
    private int days;

    List<TimeAgent> agents;


    float Hours
    {
        get { return time / 3600f;}
    }
    float Minutes
    {
        get { return time % 3600f / 60f; }
    }

    private void Awake()
    {
        agents = new List<TimeAgent>();
    }

    private void Start()
    {
        time = startAtTime;//strat from moring
    }

    public void Subscribe(TimeAgent timeAgent)
    {
        agents.Add(timeAgent);
    }

    public void Unsubscribe(TimeAgent timeAgent)
    {
        agents.Remove(timeAgent);
    }

    //������Ϸʱ��
    private void Update()
    {
        time += Time.deltaTime * timeScale;

        TimevalueCalculation();

        DayLight();

        if (time > secondsInDay)
        {
            NextDay();
        }

        TimeAgents();
    }

    int oldPhase = 0;
    private void TimeAgents()
    {
        int currentPhase = (int)(time / phaseLength);
        //Debug.Log(currentPhase);
        if (oldPhase != currentPhase)
        {
            oldPhase = currentPhase;
            for (int i = 0; i < agents.Count; i++)
            {
                agents[i].Invoke();
            }
        }

    }

    private void DayLight()
    {
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
    }

    private void TimevalueCalculation()
    {
        int h = (int)Hours;
        int m = (int)Minutes;
        text.text = h.ToString("00") + ":" + m.ToString("00");
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
