using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : InteractiveBase
{
    public string item;
    public bool onlyTriggerOnce;
    public bool triggered;
    public override void Interact(PlayerMove player)
    {
        base.Interact(player);
        if (!triggered)
        {
            if (onlyTriggerOnce)
            {
                if (!Inventory.Instance.itemList.Contains("sword"))
                {
                    Inventory.Instance.addItem(item);
                    triggered = true;
                }
            }
            else
            {
                
                Inventory.Instance.addItem(item);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
        EventPool.OptIn<int>(EventPool.bugBack, OnBugBack);
    }
    void OnBugBack(int id)
    {
        if (id == 5)
        {
            onlyTriggerOnce = false;
            return;
        }
    }
    void OnBugFixed(int id)
    {
        if (id == 5)
        {
            onlyTriggerOnce = true;
            return;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
