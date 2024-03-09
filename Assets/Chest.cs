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
            Inventory.Instance.addItem(item);
            if (onlyTriggerOnce)
            {
                triggered = true;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
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
