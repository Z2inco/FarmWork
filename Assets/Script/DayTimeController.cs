using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using System;

public class DayTimeController : MonoBehaviour
{

    const float secondsInDay = 86400f;
    
    //初始化颜色
    [SerializeField]
    Color nightLightColor;
    [SerializeField]
    AnimationCurve nightTimeCurve;  //颜色变化曲线
    [SerializeField]
    Color dayLightColor = Color.white;

    //初始化时间
    [SerializeField]
    float timeScale = 6000f;
    float time;
    [SerializeField]
    Text text;
    [SerializeField]
    Light2D globalLight;
    private int days;

    float Hours
    {
        get { return time / 3600f;}
    }
    float Minutes
    {
        get { return time % 3600f / 60f; }
    }
    //更新游戏时间
    private void Update()
    {
        time += Time.deltaTime * timeScale;
        int h = (int)Hours;
        int m = (int)Minutes;
        text.text = h.ToString("00")+":"+m.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;
        if(time > secondsInDay)
        {
            NextDay();
        }
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }
}
