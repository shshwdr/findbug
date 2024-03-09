using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : InteractiveBase
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
        Destroy(gameObject);
    }
}
