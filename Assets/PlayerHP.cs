using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerHP : HPCharacterController
{
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
    
    public override void updateHP()
    {
        HudController.Instance.SetHP(currentHP);
        // currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        // hpBar.SetHP(currentHP);
    }

    public void Reset()
    {
        currentHP = maxHP;
        HudController.Instance.SetHP(currentHP);
        
    }

    protected override void Awake()
    {
        base.Awake();
        hpBar = HudController.Instance.hPsHandler;
    }

    protected override void Die()
    {
        if (BugManager.Instance.fixedBugs[9] == BugStatus.BugFixed)
        {
            base.Die();
            animator.SetTrigger("die");
            if (BugManager.Instance.fixedBugs[10] == BugStatus.BugFixed)
            {
                HudController.Instance.ShowRestartButton();
            }
        }
    }
}
