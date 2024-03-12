using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public BugablePlayer player;
    public bool isInFindBugMode;
    void Start()
    {
        
        player = GameObject.FindObjectOfType<BugablePlayer>();
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
    }
    void OnBugFixed(int id)
    {
        GetIntoPlayMode();
    }
    public void GetIntoFindBugMode()
    {
        isInFindBugMode = true;
        HudController.Instance.UpdateUI();
    }

    public void GetIntoPlayMode()
    {
        isInFindBugMode = false;
        HudController.Instance.UpdateUI();
    }
}
