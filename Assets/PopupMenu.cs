using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupMenu : MonoBehaviour
{
    public TMP_Text text;

    public Button button;
    public GameObject menu;

    private void Start()
    {
        button.onClick.AddListener(() =>
        {
            Hide();
        });
    }

    public void Show(string text)
    {
        this.text.text = text;
        menu.SetActive(true);
    }
    public void Hide()
    {
        menu.SetActive(false);
    }

}
