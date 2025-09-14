using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BugableWall : BugableObject
{
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        if(id == 0)
        {
            collider.isTrigger = true;
        }
    }

    void OnBugFixed(int id)
    {
         if(id == 0)
         {
             collider.isTrigger = false;
         }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool DidTap()
    {
        base.DidTap();
        if (BugManager.Instance.fixedBugs[0] == BugStatus.BugTriggered)
        {
            string dialogname = "fixWallBug";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(0);
            return true;
        }
        else
        {
            CSDialogManager.Instance.StartConversation("buggableWall", null, null);
            //normal dialogues
        }
        return false;
    }
}
