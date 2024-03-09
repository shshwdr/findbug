using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BugableWall : BugableObject
{
    // Start is called before the first frame update
    void Start()
    {
        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
    }

    void OnBugFixed(int id)
    {
        if(id == 0)
        {
            GetComponent<TilemapCollider2D>().isTrigger = false;
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
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(0);
            return true;
        }
        else
        {
            DialogueManager.StartConversation("buggableWall", null, null);
            //normal dialogues
        }
        return false;
    }
}
