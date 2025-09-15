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
    private HPCharacterController controller;
    public bool isDead => GetComponent<HPCharacterController>().isDead;
    public void teleport(Teleporter teleporter)
    {
        SFXManager.Instance.PlaySFX("teleport");
        roomName = teleporter.targetRoomName;
        transform.position = teleporter.teleportTransform.position;
        
        
        var room = teleporter.teleportTransform.GetComponentInParent<Room>();
        if (room)
        {
            room.GetIntoRoom();
        }

        if (roomName != "boss")
        {
            originPosition = teleporter.teleportTransform.position;
        }
    }
   void Awake()
    {
        collider = GetComponent<CapsuleCollider2D>();
        trigger = GetComponent<CircleCollider2D>();
        //collider.isTrigger = true;
        originPosition = transform.position;
        controller = GetComponent<HPCharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        
        if (id == 0)
        {
            //collider.isTrigger = true;
        }if(id == 1)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }
    }


    void OnBugFixed(int id)
    {
        if (id == 0)
        {
            //collider.isTrigger = false;
        }if(id == 1)
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        }

        OnRestart();
    }

    public void OnRestart()
    {
        GetComponent<PlayerHP>().Reset();
        GetComponent<HPCharacterController>().isDead = false;
        CSDialogManager.Instance.isInBuggyDialogue = false;
        CSDialogManager.Instance.isInDialogue = false;
        controller.animator.SetTrigger("reset");
        if (roomName == "boss")
        {
            roomName = "battle";
        }

        foreach (var room in FindObjectsOfType<Room>())
        {
            if (room.name == roomName)
            {
                room.GetIntoRoom();
            }
        }
        
        transform.rotation = Quaternion.identity;
        transform.position = originPosition;
        FindObjectOfType<HudController>().
            HideRestartButton();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        // if (BugManager.Instance.fixedBugs[0] == BugStatus.BugDefault)
        // {
        //     if (collision.GetComponent<BugableWall>())
        //     {
        //         string dialogname = "triggerWallBug";
        //         if (!CSDialogManager.Instance.finishedDialogue.ContainsKey(dialogname))
        //         {
        //             CSDialogManager.Instance.finishedDialogue[dialogname] = true;
        //             DialogueManager.StartConversation(dialogname, null, null);
        //         }
        //     }
        //     BugManager.Instance.fixedBugs[0] = BugStatus.BugTriggered;
        // }
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
        
        if (BugManager.Instance.fixedBugs[0] == BugStatus.BugDefault)
        {
            if (collision.GetComponent<BugableWall>())
            {
                string dialogname = "triggerWallBug";
                if (!CSDialogManager.Instance.finishedDialogue.ContainsKey(dialogname))
                {
                    CSDialogManager.Instance.StartConversation(dialogname, null, null);
                }
            }
            BugManager.Instance.fixedBugs[0] = BugStatus.BugTriggered;
        }
    }


    public override bool DidTap()
    {
        base.DidTap();
        if (BugManager.Instance.fixedBugs[9] == BugStatus.BugDefault && GameManager.Instance.player.GetComponent<PlayerHP>().currentHP<0)
        {
                
            string dialogname = "killedButStillAlive";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(9);
                
            return true;
        }
        if (BugManager.Instance.fixedBugs[10] == BugStatus.BugTriggered)
        {
            string dialogname = "StoneAttackTooManyTimes";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(10);
            return true;
        }
        if (BugManager.Instance.fixedBugs[0] == BugStatus.BugTriggered)
        {
            string dialogname = "fixWallBug";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(0);
            return true;
        }
        else if (BugManager.Instance.fixedBugs[1] == BugStatus.BugDefault && transform.eulerAngles.z!=0)
        {
            string dialogname = "fixRotationOnCollide";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(1);
            return true;
        }else if (BugManager.Instance.fixedBugs[2] == BugStatus.BugTriggered)
        {
            string dialogname = "fixDoorBug";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(2);
            return true;
        }
        else if (BugManager.Instance.fixedBugs[3] == BugStatus.BugTriggered)
        {
            string dialogname = "fixFlowerBug";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
            BugManager.Instance.fixBug(3);
            return true;
        }
        else if (BugManager.Instance.fixedBugs[4] == BugStatus.BugTriggered)
        {
            string dialogname = "moveInDialogue";
            CSDialogManager.Instance.StartConversation(dialogname, null, null);
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
    
    public  void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("test");
    }
}
