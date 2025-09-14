using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WrongSortFlower : BugableObject
{
    void Start()
    {
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        if (id == 3)
        {
            GetComponent<TilemapRenderer>().sortingLayerName = "UI";
            GetComponent<TilemapRenderer>().sortingOrder = 0;
        }
    }

    void OnBugFixed(int id)
    {
        if (id == 3)
        {
            GetComponent<TilemapRenderer>().sortingLayerName = "background";
            GetComponent<TilemapRenderer>().sortingOrder = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override bool DidTap()
    {
        base.DidTap();
        if (BugManager.Instance.fixedBugs[3] == BugStatus.BugTriggered)
        {
            string dialogname = "fixFlowerBug";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(3);
            return true;
        }
        else
        {
            CSDialogManager.Instance.StartConversation("buggableFlower", null, null);
            //normal dialogues
        }
        return false;
    }
}
