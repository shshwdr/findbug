using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSDialogManager : Singleton<CSDialogManager>
{
    public bool isInDialogue;
    public Dictionary<string, bool> finishedDialogue = new Dictionary<string, bool>();
    public bool isInBuggyDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDialog()
    {
        if(DialogueManager.lastConversationStarted == "NPCInTown" && BugManager.Instance.fixedBugs[4] != BugStatus.BugFixed)
        {
            isInBuggyDialogue = true;
        }
        else
        {

            isInDialogue = true;
        }
        string test = DialogueManager.lastConversationStarted;
        //Debug.Log(test);
    }
    public void stopDialog()
    {
        isInDialogue = false;
        isInBuggyDialogue = false;
        BugManager.Instance.finishDialog();

        BugManager.Instance.unTriggerBug(4);
    }
}
