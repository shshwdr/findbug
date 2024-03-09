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
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(2);
            return true;
        }
        else
        {
            DialogueManager.StartConversation("buggableDoor", null, null);
            //normal dialogues
        }
        return false;
    }
}
