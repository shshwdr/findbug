using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    List<InteractiveChild> interactives = new List<InteractiveChild>();
    InteractiveChild lastClosest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //void Update()
    //{
    //    if (interactives.Count == 0)
    //    {
    //        if (lastClosest)
    //        {
    //            lastClosest.hidePickupUI();
    //        }
    //        return;
    //    }
    //    int closestIndex = Utils.findClosestIndex(transform, collectables);
    //    collectables[closestIndex].showPickupUI();
    //    if (lastClosest && lastClosest != collectables[closestIndex])
    //    {
    //        lastClosest.hidePickupUI();
    //    }
    //    lastClosest = collectables[closestIndex];

    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        if (lastClosest)
    //        {
    //            GetComponent<PlayerMove>().testFlip(lastClosest.transform.position - transform.position);
    //            lastClosest.interact(this);
    //            //lastClosest.startPicking(this);
    //            //StartCoroutine(pickupItem());
    //        }
    //    }
    //}
}
