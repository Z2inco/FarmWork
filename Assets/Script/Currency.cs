using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Currency : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        amount = 10000;
        UpdateText();
    }

    private void UpdateText()
    {
        text.text = amount.ToString();
    }

    public void Add(int moneyGain)
    {
        Debug.Log("+1");
        amount += moneyGain;
        UpdateText();
    }
}
