using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugableDoor : BugableObject
{
    public GameObject doorBlocker;
    void Start()
    {
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        
        if (id == 2)
        {
            doorBlocker.SetActive(false);
        }
    }

    void OnBugFixed(int id)
    {
        if (id == 2)
        {
            doorBlocker.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
    public override bool DidTap()
    {
        base.DidTap();
        if (BugManager.Instance.fixedBugs[2] == BugStatus.BugTriggered)
        {
            string dialogname = "fixDoorBug";
            CSDialogManager.Instance.StartConversation(dialogname);
            BugManager.Instance.fixBug(2);
            return true;
        }
        else
        {
            CSDialogManager.Instance.StartConversation("buggableDoor", null, null);
            //normal dialogues
        }
        return false;
    }
}
