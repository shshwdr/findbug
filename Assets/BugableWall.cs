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
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        
    }

    void OnBugFixed(int id)
    {
        // if(id == 0)
        // {
        //     foreach (var box in GetComponentsInChildren<BoxCollider2D>())
        //     {
        //         box.gameObject.SetActive(false);
        //     }
        //     //GetComponent<TilemapCollider2D>().isTrigger = false;
        //    // GetComponent<TilemapCollider2D>().enabled = false;
        //     StartCoroutine(test());
        // }
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(0.1f);
        foreach (var box in GetComponentsInChildren<BoxCollider2D>(true))
        {
            box.gameObject.SetActive(true);
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
