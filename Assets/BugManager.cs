using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BugStatus  { BugDefault, BugTriggered, BugWillBeFixed,BugFixed};
public class BugManager : Singleton<BugManager>
{
    
    //0 not triggered
    //1 triggered
    public BugStatus[] fixedBugs = new BugStatus[100]; 
    //0 wall no collide
    //1 player rotate when collide
    // 2 door is passable
    //3 flower is on top of player
    //4 move in dialogue
    //5 open chest more than once
    //6 too many inventory
    //7 use inventory that is not exist
    //8 use apple to heal more than max HP
    //9 make hp less than 0 and not kill
    //10 stone keep attacking player for too many times
    
    //11 equip both equipment
//int[] bugsToBattleArea = new int[10] {4,5,};
    // Start is called before the first frame update
    void Start()
    {
    }

        public void fixBug(int id)
        {
        if(fixedBugs[id]!= BugStatus.BugWillBeFixed && fixedBugs[id] != BugStatus.BugFixed)
        {
            fixedBugs[id] = BugStatus.BugWillBeFixed;
        }

    }

    public void triggerBug(int id)
    {
        if(fixedBugs[id] == BugStatus.BugDefault)
        {
            fixedBugs[id] = BugStatus.BugTriggered;
        }

    }

    public void unTriggerBug(int id)
    {
        if (fixedBugs[id] == BugStatus.BugTriggered)
        {
            fixedBugs[id] = BugStatus.BugDefault;
        }
    }

    public void finishDialog()
    {
        for(int i = 0; i < fixedBugs.Length; i++)
        {
            if(fixedBugs[i] == BugStatus.BugWillBeFixed)
            {
                finishFixBug(i);
            }
        }
        
        
        if (BugManager.Instance.fixedBugs[10] == BugStatus.BugTriggered)
        {
            BugManager.Instance.fixedBugs[10] = BugStatus.BugDefault;
        }
    }

    public int fixedBugCount()
    {
        int res = 0;
        foreach (var bug in fixedBugs)
        {
            if (bug == BugStatus.BugFixed)
            {
                res++;
            }
        }

        return res;
    }
    
    public void finishFixBug(int i)
    {

        fixedBugs[i] = BugStatus.BugFixed;
        EventPool.Trigger<int>(EventPool.bugFixed, i);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
