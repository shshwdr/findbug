using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupMenu : MonoBehaviour
{
    public TMP_Text text;

    public Button button1;
    public Button button2;
    public GameObject menu;
    private Action action;
    private void Start()
    {
        button2.onClick.AddListener(() =>
        {
            Hide();
        });
        button1.onClick.AddListener(() =>
        {
            Hide();
            action();
        });
    }

    public void Show(string text)
    {
        this.text.text = text;
        button1.gameObject.SetActive(false);
        menu.SetActive(true);
    }

    public void Show(string text, Action action)
    {
        this.action = action;
        this.text.text = text;
        button1.gameObject.SetActive(true);
        menu.SetActive(true);
    }
    
    public void Hide()
    {
        menu.SetActive(false);
    }

}
