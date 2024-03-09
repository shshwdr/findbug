using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour
{
    public GameObject closedDoor;
    public GameObject openedDoor;
    public GameObject roomBuggyNPC;
    void Start()
    {

        EventPool.OptIn<int>(EventPool.bugFixed, OnBugFixed);
    }


    void OnBugFixed(int id)
    {
        if(id == 1)
        {
            closedDoor.SetActive(false);
            openedDoor.SetActive(true);
            roomBuggyNPC.SetActive(true);
        }
    }
}
