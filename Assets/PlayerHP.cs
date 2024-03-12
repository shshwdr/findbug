using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private int maxHP = 6;

    public int currentHP = 6;
    // Start is called before the first frame update
    public void AddHP(int amount)
    {
        currentHP += amount;

        if (BugManager.Instance.fixedBugs[8] == BugStatus.BugFixed)
        {
            currentHP = math.min(currentHP, maxHP);
        }
        
        HudController.Instance.SetHP(currentHP);
    }

    public void Reset()
    {
        currentHP = maxHP;
        HudController.Instance.SetHP(currentHP);
        
    }
}
