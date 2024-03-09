using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBugWhenLeave : MonoBehaviour
{

    public Transform leaveItem;
    public int triggerBugId;
    public string room;
    public bool triggerWhenLeave = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerWhenLeave)
        {

            if (collision.transform == leaveItem && collision.GetComponent<BugablePlayer>().roomName == room)
            {
                BugManager.Instance.triggerBug(triggerBugId);
            }
        }
        else
        {
            if (collision.transform == leaveItem && collision.GetComponent<BugablePlayer>().roomName == room)
            {
                BugManager.Instance.unTriggerBug(triggerBugId);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!triggerWhenLeave)
        {
            if (collision.transform == leaveItem && collision.GetComponent<BugablePlayer>().roomName == room)
            {
                BugManager.Instance.triggerBug(triggerBugId);
            }
        }
        else
        {
            if (collision.transform == leaveItem && collision.GetComponent<BugablePlayer>().roomName == room)
            {
                BugManager.Instance.unTriggerBug(triggerBugId);
            }
        }
    }
}
