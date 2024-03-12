using PixelCrushers.DialogueSystem;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugablePlayer : BugableObject
{
    CapsuleCollider2D collider;
    CircleCollider2D trigger;
    Vector3 originPosition;
    public string roomName = "room";

    public void teleport(Teleporter teleporter)
    {
        roomName = teleporter.targetRoomName;
        transform.position = teleporter.teleportTransform.position;
        originPosition = teleporter.teleportTransform.position;
    }
   void Awake()
    {
        collider = GetComponent<CapsuleCollider2D>();
        trigger = GetComponent<CircleCollider2D>();
        collider.enabled = false;
        originPosition = transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
    }


    void OnBugFixed(int id)
    {
        if (id == 0)
        {
            collider.enabled = true;
        }if(id == 1)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        transform.rotation = Quaternion.identity;
        transform.position = originPosition;
        GetComponent<PlayerHP>().Reset();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (BugManager.Instance.fixedBugs[0] == BugStatus.BugDefault)
        {
            if (collision.GetComponent<BugableWall>())
            {
                string dialogname = "triggerWallBug";
                if (!CSDialogManager.Instance.finishedDialogue.ContainsKey(dialogname))
                {
                    CSDialogManager.Instance.finishedDialogue[dialogname] = true;
                    DialogueManager.StartConversation(dialogname, null, null);
                }
            }
            BugManager.Instance.fixedBugs[0] = BugStatus.BugTriggered;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (BugManager.Instance.fixedBugs[0] == BugStatus.BugTriggered)
        {
            if (collision.GetComponent<BugableWall>())
            {

                BugManager.Instance.fixedBugs[0] = BugStatus.BugDefault;
            }
        }
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
        else if (BugManager.Instance.fixedBugs[1] == BugStatus.BugDefault && transform.eulerAngles.z!=0)
        {
            string dialogname = "fixRotationOnCollide";
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(1);
            return true;
        }else if (BugManager.Instance.fixedBugs[2] == BugStatus.BugTriggered)
        {
            string dialogname = "fixDoorBug";
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(2);
            return true;
        }
        else if (BugManager.Instance.fixedBugs[3] == BugStatus.BugTriggered)
        {
            string dialogname = "fixFlowerBug";
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(3);
            return true;
        }
        else if (BugManager.Instance.fixedBugs[4] == BugStatus.BugTriggered)
        {
            string dialogname = "moveInDialogue";
            DialogueManager.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(4);
            return true;
        }
        else
        {
            DialogueManager.StartConversation("buggablePlayer", null, null);
            //normal dialogues
        }
        return false;
    }
}
