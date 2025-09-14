using PixelCrushers.DialogueSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSDialogManager : Singleton<CSDialogManager>
{
    public bool isInDialogue;
    public Dictionary<string, bool> finishedDialogue = new Dictionary<string, bool>();
    public bool isInBuggyDialogue;

    private string lastDialogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartConversation(string dialogname,Transform actor = null, Transform conversation = null)
    {
        if (!CSDialogManager.Instance.finishedDialogue.ContainsKey(dialogname))
        {
            lastDialogue = dialogname;
            CSDialogManager.Instance.finishedDialogue[dialogname] = true;
            DialogueManager.StartConversation(dialogname, null, null);
        }
    }
    public void startDialog()
    {
        FindObjectOfType<HudController>().hud.SetActive(false);
        
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
        FindObjectOfType<HudController>().hud.SetActive(true);
        isInDialogue = false;
        isInBuggyDialogue = false;
        BugManager.Instance.finishDialog();

        BugManager.Instance.unTriggerBug(4);

        if (lastDialogue =="BossLose")
        {
            FindObjectOfType<BugablePlayer>().OnRestart();
        }

        lastDialogue = "";
    }
}
