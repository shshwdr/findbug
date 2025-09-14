using System;
using System.Collections;
using System.Collections.Generic;
using Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPopup : Singleton<ErrorPopup>
{
    public GameObject canvas;
    public TMP_Text textLabel;

    private void Start()
    {
        canvas.SetActive(false);
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        
    }

    public void ShowError(string error)
    {
        canvas.SetActive(true);
        textLabel.text = error;
    }

    void OnBugFixed(int id)
    {
        canvas.SetActive(false);
    }
}
