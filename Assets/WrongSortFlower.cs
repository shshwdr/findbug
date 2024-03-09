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
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(3);
            return true;
        }
        else
        {
            DialogueManager.StartConversation("buggableFlower", null, null);
            //normal dialogues
        }
        return false;
    }
}
